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
	[Register("SwitchCellView")]
	partial class SwitchCellView
	{
		[Outlet]
		public WatchKit.WKInterfaceSwitch WidgetSwitch { get; private set; }

		[Action("OnSwitchStateChanged:")]
		partial void OnSwitchStateChanged(System.Boolean value);

		void ReleaseDesignerOutlets()
		{
			if (WidgetSwitch != null)
			{
				WidgetSwitch.Dispose();
				WidgetSwitch = null;
			}
		}
	}
}
