// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Gst.RtspServer {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public partial class RTSPMountPoints : GLib.Object {

		public RTSPMountPoints (IntPtr raw) : base(raw) {}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_rtsp_mount_points_new();

		public RTSPMountPoints () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (RTSPMountPoints)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = gst_rtsp_mount_points_new();
		}

		static MakePathNativeDelegate MakePath_cb_delegate;
		static MakePathNativeDelegate MakePathVMCallback {
			get {
				if (MakePath_cb_delegate == null)
					MakePath_cb_delegate = new MakePathNativeDelegate (MakePath_cb);
				return MakePath_cb_delegate;
			}
		}

		static void OverrideMakePath (GLib.GType gtype)
		{
			OverrideMakePath (gtype, MakePathVMCallback);
		}

		static void OverrideMakePath (GLib.GType gtype, MakePathNativeDelegate callback)
		{
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) gtype.GetClassPtr()) + (long) class_abi.GetFieldOffset("make_path"));
				*raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate) callback);
			}
		}

		[UnmanagedFunctionPointer (CallingConvention.Cdecl)]
		delegate IntPtr MakePathNativeDelegate (IntPtr inst, IntPtr url);

		static IntPtr MakePath_cb (IntPtr inst, IntPtr url)
		{
			try {
				RTSPMountPoints __obj = GLib.Object.GetObject (inst, false) as RTSPMountPoints;
				string __result;
				__result = __obj.OnMakePath (Gst.Rtsp.RTSPUrl.New (url));
				return GLib.Marshaller.StringToPtrGStrdup(__result);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, true);
				// NOTREACHED: above call does not return.
				throw e;
			}
		}

		[GLib.DefaultSignalHandler(Type=typeof(Gst.RtspServer.RTSPMountPoints), ConnectionMethod="OverrideMakePath")]
		protected virtual string OnMakePath (Gst.Rtsp.RTSPUrl url)
		{
			return InternalMakePath (url);
		}

		private string InternalMakePath (Gst.Rtsp.RTSPUrl url)
		{
			MakePathNativeDelegate unmanaged = null;
			unsafe {
				IntPtr* raw_ptr = (IntPtr*)(((long) this.LookupGType().GetThresholdType().GetClassPtr()) + (long) class_abi.GetFieldOffset("make_path"));
				unmanaged = (MakePathNativeDelegate) Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(MakePathNativeDelegate));
			}
			if (unmanaged == null) return null;

			IntPtr native_url = GLib.Marshaller.StructureToPtrAlloc (url);
			IntPtr __result = unmanaged (this.Handle, native_url);
			Marshal.FreeHGlobal (native_url);
			return GLib.Marshaller.PtrToStringGFree(__result);
		}


		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _class_abi = null;
		static public new GLib.AbiStruct class_abi {
			get {
				if (_class_abi == null)
					_class_abi = new GLib.AbiStruct (new List<GLib.AbiField>{ 
						new GLib.AbiField("make_path"
							, GLib.Object.class_abi.Fields
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // make_path
							, null
							, "_gst_reserved"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("_gst_reserved"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) * 4 // _gst_reserved
							, "make_path"
							, null
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
					});

				return _class_abi;
			}
		}


		// End of the ABI representation.

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_rtsp_mount_points_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = gst_rtsp_mount_points_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_rtsp_mount_points_add_factory(IntPtr raw, IntPtr path, IntPtr factory);

		public void AddFactory(string path, Gst.RtspServer.RTSPMediaFactory factory) {
			IntPtr native_path = GLib.Marshaller.StringToPtrGStrdup (path);
			gst_rtsp_mount_points_add_factory(Handle, native_path, factory == null ? IntPtr.Zero : factory.OwnedHandle);
			GLib.Marshaller.Free (native_path);
		}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_rtsp_mount_points_make_path(IntPtr raw, IntPtr url);

		public string MakePath(Gst.Rtsp.RTSPUrl url) {
			IntPtr native_url = GLib.Marshaller.StructureToPtrAlloc (url);
			IntPtr raw_ret = gst_rtsp_mount_points_make_path(Handle, native_url);
			string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
			Marshal.FreeHGlobal (native_url);
			return ret;
		}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern IntPtr gst_rtsp_mount_points_match(IntPtr raw, IntPtr path, out int matched);

		public Gst.RtspServer.RTSPMediaFactory Match(string path, out int matched) {
			IntPtr native_path = GLib.Marshaller.StringToPtrGStrdup (path);
			IntPtr raw_ret = gst_rtsp_mount_points_match(Handle, native_path, out matched);
			Gst.RtspServer.RTSPMediaFactory ret = GLib.Object.GetObject(raw_ret, true) as Gst.RtspServer.RTSPMediaFactory;
			GLib.Marshaller.Free (native_path);
			return ret;
		}

		[DllImport("gstrtspserver-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
		static extern void gst_rtsp_mount_points_remove_factory(IntPtr raw, IntPtr path);

		public void RemoveFactory(string path) {
			IntPtr native_path = GLib.Marshaller.StringToPtrGStrdup (path);
			gst_rtsp_mount_points_remove_factory(Handle, native_path);
			GLib.Marshaller.Free (native_path);
		}


		static RTSPMountPoints ()
		{
			GtkSharp.GstreamerSharp.ObjectManager.Initialize ();
		}

		// Internal representation of the wrapped structure ABI.
		static GLib.AbiStruct _abi_info = null;
		static public new GLib.AbiStruct abi_info {
			get {
				if (_abi_info == null)
					_abi_info = new GLib.AbiStruct (new List<GLib.AbiField>{ 
						new GLib.AbiField("priv"
							, GLib.Object.abi_info.Fields
							, (uint) Marshal.SizeOf(typeof(IntPtr)) // priv
							, null
							, "_gst_reserved"
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
						new GLib.AbiField("_gst_reserved"
							, -1
							, (uint) Marshal.SizeOf(typeof(IntPtr)) * 4 // _gst_reserved
							, "priv"
							, null
							, (uint) Marshal.SizeOf(typeof(IntPtr))
							, 0
							),
					});

				return _abi_info;
			}
		}


		// End of the ABI representation.

#endregion
	}
}