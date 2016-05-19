﻿using System;
using WatchKit;
using UIKit;
using Foundation;
using WearableSmarthomeRemote.Core;
using System.Collections.Generic;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.watchOS;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class ItemListView : MvxInterfaceController<ItemListViewModel>
	{
		public ItemListView(IntPtr handle) : base(handle)
		{
		}

		public override async void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context: {1}", this, context);

			//TODO: this.Bind(ItemList).To((vm) => vm.Items).Apply();
			this.AdaptForBinding();


			var oh = new OpenHab();

			var items = new List<Item>();

			if (context == null)
			{
				items = await oh.GetItems();
			}
			else {
				var item = await oh.GetItemWithName((NSString)context);
				items.Add(item);
			}

			var viewModels = new List<ItemCellViewModel>();
			var rowTypes = new List<string>();
			foreach (Item item in items)
			{
				switch (item.type)
				{
					case "SwitchItem":
						viewModels.Add(new SwitchItemCellViewModel(oh, item.name, item.state));
						rowTypes.Add("SwitchItem");
						break;
					case "GroupItem":
						break;
					case "ColorItem":
						viewModels.Add(new ColorItemCellViewModel(item.name, item.state));
						rowTypes.Add("ColorItem");
						break;
					default:
						viewModels.Add(new StateItemCellViewModel(item.name, item.state));
						rowTypes.Add("StateItem");
						break;
				}
			}

			ItemList.SetRowTypes(rowTypes.ToArray());

			for (var i = 0; i < ItemList.NumberOfRows; i++)
			{
				if (rowTypes[i] == "StateItem")
				{
					var widgetCell = (StateCellRowController)ItemList.GetRowController(i);
					if (widgetCell != null)
					{
						widgetCell.ItemNameLabel.SetText(viewModels[i].ItemName);
						widgetCell.ItemStateLabel.SetText(((StateItemCellViewModel)viewModels[i]).State);
					}
				}
				else if (rowTypes[i] == "SwitchItem")
				{
					var widgetCell = (SwitchCellRowController)ItemList.GetRowController(i);
					if (widgetCell != null)
					{
						widgetCell.WidgetSwitch.SetTitle(viewModels[i].ItemName);
						widgetCell.WidgetSwitch.SetOn(((SwitchItemCellViewModel)viewModels[i]).On);
					}
				}
				else if (rowTypes[i] == "ColorItem")
				{
					var widgetCell = (ColorCellRowController)ItemList.GetRowController(i);
					if (widgetCell != null)
					{
						widgetCell.WidgetLabel.SetText(viewModels[i].ItemName);
						widgetCell.WidgetColor.SetBackgroundColor(UIColor.Red);
					}
				}
			}

		}

		public override void WillActivate()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine("{0} will activate", this);

		}

		public override void DidDeactivate()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine("{0} did deactivate", this);
		}
	}
}

