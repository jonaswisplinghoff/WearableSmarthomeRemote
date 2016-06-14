// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WearableSmarthomeRemote.UI.iOS.WatchAppExtension
{
	[Register("SmarthomeRemoteView")]
	partial class SmarthomeRemoteView
	{
		[Outlet]
		WatchKit.WKInterfaceLabel HeadingLabel { get; set; }

		[Outlet]
		WatchKit.WKInterfaceButton ShowAllButton { get; set; }

		[Outlet]
		WatchKit.WKInterfaceTable WidgetList { get; set; }

		[Action("OnShowAllButtonPressed")]
		partial void OnShowAllButtonPressed();

		void ReleaseDesignerOutlets()
		{
			if (HeadingLabel != null)
			{
				HeadingLabel.Dispose();
				HeadingLabel = null;
			}

			if (ShowAllButton != null)
			{
				ShowAllButton.Dispose();
				ShowAllButton = null;
			}

			if (WidgetList != null)
			{
				WidgetList.Dispose();
				WidgetList = null;
			}
		}
	}
}
