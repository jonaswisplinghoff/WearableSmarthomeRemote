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
	[Register ("StateCellRowController")]
	partial class StateCellRowController
	{
		[Outlet]
		public WatchKit.WKInterfaceLabel WidgetLabel { get; private set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (WidgetLabel != null) {
				WidgetLabel.Dispose ();
				WidgetLabel = null;
			}
		}
	}
}
