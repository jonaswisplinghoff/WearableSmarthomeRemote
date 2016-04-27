// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	[Register ("SmarthomeRemoteView")]
	partial class SmarthomeRemoteView
	{
		[Outlet]
		WatchKit.WKInterfaceLabel HeadingLabel { get; set; }

		[Outlet]
		WatchKit.WKInterfaceTable WidgetList { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (WidgetList != null) {
				WidgetList.Dispose ();
				WidgetList = null;
			}

			if (HeadingLabel != null) {
				HeadingLabel.Dispose ();
				HeadingLabel = null;
			}
		}
	}
}
