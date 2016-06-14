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
	[Register("StateCellView")]
	partial class StateCellView
	{
		[Outlet]
		public WatchKit.WKInterfaceLabel ItemNameLabel { get; set; }

		[Outlet]
		public WatchKit.WKInterfaceLabel ItemStateLabel { get; set; }

		void ReleaseDesignerOutlets()
		{
			if (ItemNameLabel != null)
			{
				ItemNameLabel.Dispose();
				ItemNameLabel = null;
			}

			if (ItemStateLabel != null)
			{
				ItemStateLabel.Dispose();
				ItemStateLabel = null;
			}
		}
	}
}
