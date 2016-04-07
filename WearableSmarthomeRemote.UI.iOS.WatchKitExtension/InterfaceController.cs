using System;

using WatchKit;
using Foundation;
using System.Diagnostics;
using System.Collections.Generic;
using UIKit;
using WearableSmarthomeRemote.Core;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class InterfaceController : WKInterfaceController
	{
		public InterfaceController (IntPtr handle) : base (handle)
		{
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			// Configure interface objects here.
			Console.WriteLine ("{0} awake with context", this);
		}

		public override async void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);

			//TODO: this.Bind(WidgetList).To((vm) => vm.Widgets).Apply();

			var oh = new OpenHab ();
			var sitemap = await oh.GetSitemapWithName();

			var widgets = new List<WidgetCellViewModel>();
			foreach (Widget widget in sitemap.homepage.widgets)
			{
				widgets.Add(new WidgetCellViewModel(widget));
			}
			var rows = new List<string>();

			foreach (var w in widgets) {
				rows.Add (w.WidgetName);
			}

			WidgetList.SetNumberOfRows (rows.Count, "WidgetItem");

			for (var i = 0; i < WidgetList.NumberOfRows; i++) {
				var widgetCell = (WidgetCellRowController)WidgetList.GetRowController (i);
				if (widgetCell != null) {
					widgetCell.WidgetLabel.SetText (rows [i]);
				}
			}
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}
	}
}

