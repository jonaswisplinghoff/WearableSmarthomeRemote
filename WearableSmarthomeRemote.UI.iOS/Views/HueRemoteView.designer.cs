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
        UIKit.UITableView ItemList { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RefreshButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch Switch1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch Switch2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch Switch3 { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ItemList != null) {
                ItemList.Dispose ();
                ItemList = null;
            }

            if (RefreshButton != null) {
                RefreshButton.Dispose ();
                RefreshButton = null;
            }

            if (Switch1 != null) {
                Switch1.Dispose ();
                Switch1 = null;
            }

            if (Switch2 != null) {
                Switch2.Dispose ();
                Switch2 = null;
            }

            if (Switch3 != null) {
                Switch3.Dispose ();
                Switch3 = null;
            }
        }
    }
}