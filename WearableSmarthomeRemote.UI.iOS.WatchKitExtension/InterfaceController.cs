﻿using System;

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

		List<WidgetCellViewModel> Widgets;

		public override async void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);

			//TODO: this.Bind(WidgetList).To((vm) => vm.Widgets).Apply();

			var oh = new OpenHab ();
			var sitemap = await oh.GetSitemapWithName();
			Widgets = new List<WidgetCellViewModel>();
			foreach (Widget widget in sitemap.homepage.widgets)
			{
				Widgets.Add(new WidgetCellViewModel(widget));
			}

			List<string> rows = new List<string>();

			foreach (var w in Widgets) {
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

		public override NSObject GetContextForSegue (string segueIdentifier, WKInterfaceTable table, nint rowIndex)
		{
			if (segueIdentifier == "showItems") {
				//var widget = ((WidgetCellViewModel)Widgets [(int)rowIndex]).Widget;
				//return new NSString (widget.widgets[0].item.name);
			}
			return null;
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}
	}
}

