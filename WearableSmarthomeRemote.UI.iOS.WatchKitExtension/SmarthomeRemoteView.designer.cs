// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
    [Register ("SmarthomeRemoteView")]
    partial class SmarthomeRemoteView
    {
        [Outlet]
        WatchKit.WKInterfaceLabel HeadingLabel { get; set; }


        [Outlet]
        WatchKit.WKInterfaceButton ShowAllButton { get; set; }


        [Outlet]
        WatchKit.WKInterfaceTable WidgetList { get; set; }


        [Action ("ShowAllButtonPressed")]
        partial void ShowAllButtonPressed ();

        void ReleaseDesignerOutlets ()
        {
            if (HeadingLabel != null) {
                HeadingLabel.Dispose ();
                HeadingLabel = null;
            }

            if (ShowAllButton != null) {
                ShowAllButton.Dispose ();
                ShowAllButton = null;
            }

            if (WidgetList != null) {
                WidgetList.Dispose ();
                WidgetList = null;
            }
        }
    }
}