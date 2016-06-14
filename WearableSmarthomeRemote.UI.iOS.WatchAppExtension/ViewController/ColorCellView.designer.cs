// WARNING
//
// This file has been generated automatically by Xamarin Studio Business to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WearableSmarthomeRemote.UI.iOS.WatchAppExtension
{
	[Register("ColorCellView")]
	partial class ColorCellView
	{
		[Outlet]
		public WatchKit.WKInterfaceGroup WidgetColor { get; private set; }

		[Outlet]
		public WatchKit.WKInterfaceLabel WidgetLabel { get; private set; }

		void ReleaseDesignerOutlets()
		{
			if (WidgetColor != null)
			{
				WidgetColor.Dispose();
				WidgetColor = null;
			}

			if (WidgetLabel != null)
			{
				WidgetLabel.Dispose();
				WidgetLabel = null;
			}
		}
	}
}
