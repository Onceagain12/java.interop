using System;
using System.Collections.Generic;
using CodeGenerationTarget = Xamarin.Android.Binder.CodeGenerationTarget;

namespace MonoDroid.Generation {

	public class CharSequenceSymbol : ISymbol {

		public string DefaultValue {
			get { return "IntPtr.Zero"; }
		}

		public string FullName {
			get { return "Java.Lang.ICharSequence"; }
		}

		public bool IsGeneric {
			get { return false; }
		}

		public string JavaName {
			get { return "java.lang.CharSequence"; }
		}

		public string JniName {
			get { return "Ljava/lang/CharSequence;"; }
		}

		public string NativeType {
			get { return "IntPtr"; }
		}

		public bool IsEnum {
			get { return false; }
		}

		public bool IsArray {
			get { return false; }
		}

		public string ElementType {
			get { return null; }
		}

		public string ReturnCast => string.Empty;

		public string GetObjectHandleProperty (CodeGenerationOptions opt, string variable)
		{
			if (opt.CodeGenerationTarget == CodeGenerationTarget.JavaInterop1) {
				return $"{variable}.PeerReference";
			}
			return $"((global::Java.Lang.Object) {variable}).Handle";
		}

		public string GetGenericType (Dictionary<string, string> mappings)
		{
			return null;
		}

		public string FromNative (CodeGenerationOptions opt, string var_name, bool owned)
		{
			if (opt.CodeGenerationTarget == CodeGenerationTarget.JavaInterop1) {
				return "global::Java.Interop.JniEnvironment.Runtime.ValueManager.GetValue<Java.Lang.ICharSequence>(" +
					$"ref {var_name}, JniObjectReferenceOptions.{(owned ? "CopyAndDispose" : "Copy")})";
			}
			return String.Format ("global::Java.Lang.Object.GetObject<Java.Lang.ICharSequence> ({0}, {1})", var_name, owned ? "JniHandleOwnership.TransferLocalRef" : "JniHandleOwnership.DoNotTransfer");
		}

		public string ToNative (CodeGenerationOptions opt, string var_name, Dictionary<string, string> mappings = null)
		{
			if (opt.CodeGenerationTarget == CodeGenerationTarget.JavaInterop1) {
				return $"({var_name}?.PeerReference ?? default)";
			}
			return String.Format ("CharSequence.ToLocalJniHandle ({0})", var_name);
		}

		public bool Validate (CodeGenerationOptions opt, GenericParameterDefinitionList type_params, CodeGeneratorContext context)
		{
			return true;
		}

		public string Call (CodeGenerationOptions opt, string var_name)
		{
			if (opt.CodeGenerationTarget == CodeGenerationTarget.JavaInterop1) {
				return var_name;
			}
			return opt.GetSafeIdentifier (TypeNameUtilities.GetNativeName (var_name));
		}

		public string[] PostCallback (CodeGenerationOptions opt, string var_name)
		{
			return new string [0];
		}

		public string[] PostCall (CodeGenerationOptions opt, string var_name)
		{
			if (opt.CodeGenerationTarget == CodeGenerationTarget.JavaInterop1) {
				return Array.Empty<string>();
			}
			return new string[]{
				string.Format ("JNIEnv.DeleteLocalRef ({0});", opt.GetSafeIdentifier (TypeNameUtilities.GetNativeName (var_name))),
			};
		}

		public string[] PreCallback (CodeGenerationOptions opt, string var_name, bool owned)
		{
			if (opt.CodeGenerationTarget == CodeGenerationTarget.JavaInterop1) {
				return new[]{
					$"var {var_name} = global::Java.Interop.JniEnvironment.Runtime.ValueManager.GetValue<Java.Lang.ICharSequence>(" +
						$"ref {TypeNameUtilities.GetNativeName (var_name)}, JniObjectReferenceOptions.Copy)",
				};
			}
			return new string[] { String.Format ("var {0} = global::Java.Lang.Object.GetObject<global::Java.Lang.ICharSequence> ({1}, JniHandleOwnership.DoNotTransfer);", var_name, TypeNameUtilities.GetNativeName (var_name)) };
		}

		public string[] PreCall (CodeGenerationOptions opt, string var_name)
		{
			if (opt.CodeGenerationTarget == CodeGenerationTarget.JavaInterop1) {
				return Array.Empty<string> ();
			}
			return new string[] { String.Format ("IntPtr {0} = CharSequence.ToLocalJniHandle ({1});", opt.GetSafeIdentifier (TypeNameUtilities.GetNativeName (var_name)), opt.GetSafeIdentifier (var_name)) };
		}

		public bool NeedsPrep { get { return true; } }
	}
}

