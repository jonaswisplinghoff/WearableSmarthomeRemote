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

namespace WearableSmarthomeRemote.UI.iOS
{
    [Register ("HueRemoteView")]
    partial class HueRemoteView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RefreshButton { get; set; }
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StateLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (RefreshButton != null) {
                RefreshButton.Dispose ();
                RefreshButton = null;
            }

            if (StateLabel != null) {
                StateLabel.Dispose ();
                StateLabel = null;
            }
        }
    }
}