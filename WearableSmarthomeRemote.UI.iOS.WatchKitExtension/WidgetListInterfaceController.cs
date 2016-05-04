using System;
using WatchKit;
using UIKit;
using Foundation;
using WearableSmarthomeRemote.Core;
using System.Collections.Generic;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class WidgetListInterfaceController : WKInterfaceController
	{
		public WidgetListInterfaceController (IntPtr handle) : base (handle)
		{
		}

		List<WidgetCellViewModel> Widgets;

		public override async void Awake (NSObject context)
		{
			base.Awake (context);

			// Configure interface objects here.
			Console.WriteLine ("{0} awake with context: {1}", this, context);

			var _widgetId = (NSString)context;

			//TODO: this.Bind(WidgetList).To((vm) => vm.Items).Apply();

			var oh = new OpenHab ();
			var sitemap = await oh.GetSitemapWithName();

			Widget result = null;
			foreach (Widget widget in sitemap.homepage.widgets)
			{
				result = FindWidgetWithId(widget, _widgetId);
				if (result != null)
				{
					break;
				}
			}

			Widgets = new List<WidgetCellViewModel>();
			foreach (Widget w in result.widgets)
			{
				Widgets.Add(new WidgetCellViewModel(w));
			}

			List<string> rows = new List<string>();

			foreach (var w in Widgets) {
				rows.Add (w.WidgetName);
			}

			WidgetList.SetNumberOfRows (rows.Count, "WidgetItem");

			for (var i = 0; i < WidgetList.NumberOfRows; i++) {
				var widgetCell = (WidgetCellView)WidgetList.GetRowController (i);
				if (widgetCell != null) {
					widgetCell.WidgetLabel.SetText (rows [i]);
				}
			}
		}

		public override void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);

		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}

		public override NSObject GetContextForSegue (string segueIdentifier, WKInterfaceTable table, nint rowIndex)
		{
			if (segueIdentifier == "showItems") {
				var widget = ((WidgetCellViewModel)Widgets [(int)rowIndex]).Widget;
				return new NSString (widget.item.name);
			}
			return null;
		}

		private Widget FindWidgetWithId(Widget widget, string id)
		{
			if (widget.widgetId == id)
			{
				return widget;
			}
			foreach (Widget w in widget.widgets)
			{
				FindWidgetWithId(w, id);
			}
			return null;
		}
	}
}


