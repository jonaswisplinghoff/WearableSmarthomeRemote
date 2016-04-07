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

		public override void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);

			//TODO: WidgetList.addBinding(...)

			var rows = new List<string>();

			rows.Add ("asd");
			rows.Add ("fdig");
			rows.Add ("dog");
			rows.Add ("adjn");

			var rowTypes = new [] { "WidgetItem", "StateItem", "SwitchItem", "ColorItem" };

			WidgetList.SetRowTypes (rowTypes);

			for (var i = 0; i < WidgetList.NumberOfRows; i++) {
				if (rowTypes [i] == "WidgetItem") {
					var widgetCell = (WidgetCellRowController)WidgetList.GetRowController (i);
					if (widgetCell != null) {
						widgetCell.WidgetLabel.SetText (rows [i]);
					}
				} else if (rowTypes [i] == "StateItem") {
					var widgetCell = (StateCellRowController)WidgetList.GetRowController (i);
					if (widgetCell != null) {
						widgetCell.WidgetLabel.SetText (rows [i]);
					}
				} else if (rowTypes [i] == "SwitchItem") {
					var widgetCell = (SwitchCellRowController)WidgetList.GetRowController (i);
					if (widgetCell != null) {
						widgetCell.WidgetSwitch.SetTitle (rows [i]);
					}
				} else if (rowTypes [i] == "ColorItem") {
					var widgetCell = (ColorCellRowController)WidgetList.GetRowController (i);
					if (widgetCell != null) {
						widgetCell.WidgetLabel.SetText (rows [i]);
						widgetCell.WidgetColor.SetBackgroundColor(UIColor.Red);
					}
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

