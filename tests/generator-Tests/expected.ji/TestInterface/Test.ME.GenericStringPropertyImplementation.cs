using System;
using System.Collections.Generic;
using Java.Interop;

namespace Test.ME {

	// Metadata.xml XPath class reference: path="/api/package[@name='test.me']/class[@name='GenericStringPropertyImplementation']"
	[global::Java.Interop.JniTypeSignature ("test/me/GenericStringPropertyImplementation", GenerateJavaPeer=false)]
	public partial class GenericStringPropertyImplementation : global::Java.Lang.Object, global::Test.ME.IGenericPropertyInterface {
		static readonly JniPeerMembers _members = new JniPeerMembers ("test/me/GenericStringPropertyImplementation", typeof (GenericStringPropertyImplementation));

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		protected GenericStringPropertyImplementation (ref JniObjectReference reference, JniObjectReferenceOptions options) : base (ref reference, options)
		{
		}

		// Metadata.xml XPath constructor reference: path="/api/package[@name='test.me']/class[@name='GenericStringPropertyImplementation']/constructor[@name='GenericStringPropertyImplementation' and count(parameter)=0]"
		public unsafe GenericStringPropertyImplementation () : base (ref *InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			const string __id = "()V";

			if (PeerReference.IsValid)
				return;

			try {
				var __r = _members.InstanceMethods.StartCreateInstance (__id, ((object) this).GetType (), null);
				Construct (ref __r, JniObjectReferenceOptions.CopyAndDispose);
				_members.InstanceMethods.FinishCreateInstance (__id, this, null);
			} finally {
			}
		}

		public virtual unsafe string Object {
			// Metadata.xml XPath method reference: path="/api/package[@name='test.me']/class[@name='GenericStringPropertyImplementation']/method[@name='getObject' and count(parameter)=0]"
			get {
				const string __id = "getObject.()Ljava/lang/String;";
				try {
					var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, null);
					return global::Java.Interop.JniEnvironment.Strings.ToString (ref __rm, JniObjectReferenceOptions.CopyAndDispose);
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='test.me']/class[@name='GenericStringPropertyImplementation']/method[@name='SetObject' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			set {
				const string __id = "SetObject.(Ljava/lang/String;)V";
				var native_value = global::Java.Interop.JniEnvironment.Strings.NewString (value);
				try {
					JniArgumentValue* __args = stackalloc JniArgumentValue [1];
					__args [0] = new JniArgumentValue (native_value);
					_members.InstanceMethods.InvokeVirtualVoidMethod (__id, this, __args);
				} finally {
					global::Java.Interop.JniObjectReference.Dispose (ref native_value);
				}
			}
		}

		// This method is explicitly implemented as a member of an instantiated Test.ME.IGenericPropertyInterface
		global::Java.Lang.Object global::Test.ME.IGenericPropertyInterface.Object {
			// Metadata.xml XPath method reference: path="/api/package[@name='test.me']/interface[@name='GenericPropertyInterface']/method[@name='getObject' and count(parameter)=0]"
			[Register ("getObject", "()Ljava/lang/Object;", "GetGetObjectHandler:Test.ME.IGenericPropertyInterfaceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
			get { return Object; }
			// Metadata.xml XPath method reference: path="/api/package[@name='test.me']/interface[@name='GenericPropertyInterface']/method[@name='setObject' and count(parameter)=1 and parameter[1][@type='T']]"
			[Register ("setObject", "(Ljava/lang/Object;)V", "GetSetObject_Ljava_lang_Object_Handler:Test.ME.IGenericPropertyInterfaceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
			set { Object = value.ToString (); }
		}

	}
}
