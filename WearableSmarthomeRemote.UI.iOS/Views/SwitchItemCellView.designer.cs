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
    [Register ("SwitchItemCellView")]
    partial class SwitchItemCellView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch SwitchItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NameLabel != null) {
                NameLabel.Dispose ();
                NameLabel = null;
            }

            if (StateLabel != null) {
                StateLabel.Dispose ();
                StateLabel = null;
            }

            if (SwitchItem != null) {
                SwitchItem.Dispose ();
                SwitchItem = null;
            }
        }
    }
}