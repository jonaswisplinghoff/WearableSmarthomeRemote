// WARNING
//
// This file has been generated automatically by Xamarin Studio Business to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	[Register ("WidgetListInterfaceController")]
	partial class WidgetListInterfaceController
	{
		[Outlet]
		WatchKit.WKInterfaceTable WidgetList { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (WidgetList != null) {
				WidgetList.Dispose ();
				WidgetList = null;
			}
		}
	}
}
