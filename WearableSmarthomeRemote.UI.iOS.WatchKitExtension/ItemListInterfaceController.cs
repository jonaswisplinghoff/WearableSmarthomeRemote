using System;
using WatchKit;
using UIKit;
using Foundation;
using WearableSmarthomeRemote.Core;
using System.Collections.Generic;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class ItemListInterfaceController : WKInterfaceController
	{
		public ItemListInterfaceController (IntPtr handle) : base (handle)
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

			var items = new List<Item>();
			items = await oh.GetItems();

			var viewModels = new List<ItemCellViewModel>();
			var rowTypes = new List<string> ();
			foreach (Item item in items)
			{
				switch (item.type)
				{
				case "SwitchItem":
					viewModels.Add (new SwitchItemCellViewModel (oh, item.name, item.state));
					rowTypes.Add ("SwitchItem");
					break;
				case "GroupItem":
					break;
				case "ColorItem":
					viewModels.Add (new ColorItemCellViewModel (item.name, item.state));
					rowTypes.Add ("ColorItem");
					break;
				default:
					viewModels.Add (new StateItemCellViewModel (item.name, item.state));
					rowTypes.Add ("StateItem");
					break;
				}
			}

			var rows = new List<string>();

			foreach (var i in viewModels) {
				rows.Add (i.ItemName);
			}

			ItemList.SetRowTypes (rowTypes.ToArray());

			for (var i = 0; i < ItemList.NumberOfRows; i++) {
				if (rowTypes [i] == "StateItem") {
					var widgetCell = (StateCellRowController)ItemList.GetRowController (i);
					if (widgetCell != null) {
						widgetCell.WidgetLabel.SetText (rows [i]);
					}
				} else if (rowTypes [i] == "SwitchItem") {
					var widgetCell = (SwitchCellRowController)ItemList.GetRowController (i);
					if (widgetCell != null) {
						widgetCell.WidgetSwitch.SetTitle (rows [i]);
					}
				} else if (rowTypes [i] == "ColorItem") {
					var widgetCell = (ColorCellRowController)ItemList.GetRowController (i);
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


