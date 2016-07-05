using System;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Input;

namespace WearableSmarthomeRemote.WatchCore
{
	public class ItemListViewModel : MvxViewModel
	{
		private readonly IOpenHab _openHab;
		public ItemListViewModel(IOpenHab openHab)
		{
			_openHab = openHab;
		}

		private string _itemName = null;
		public void Init(ItemListParameters parameters)
		{
			_itemName = parameters.Name;
		}

		public override void Start()
		{
			Update();
		}


		private List<ItemCellViewModel> _items;
		public List<ItemCellViewModel> Items
		{
			get { return _items; }
			set
			{
				_items = new List<ItemCellViewModel>();
				foreach (ItemCellViewModel item in value)
				{
					_items.Add(item);
				}

				RaisePropertyChanged(() => Items);
			}
		}

		async void Update()
		{
			var items = new List<Item>();

			if (_itemName == null)
			{
				items = await _openHab.GetItems();
			}
			else {
				var item = await _openHab.GetItemWithName(_itemName);
				items.Add(item);
			}

			var viewModels = new List<ItemCellViewModel>();
			foreach (Item item in items)
			{
				Debug.WriteLine("Item: " + item.Name + ", state: " + item.State);
				switch (item.Type)
				{
					case "SwitchItem":
						viewModels.Add(new SwitchCellViewModel(_openHab, item.Name, item.State));
						break;
					case "GroupItem":
						break;
					case "ColorItem":
						viewModels.Add(new ColorCellViewModel(item.Name, item.State));
						break;
					default:
						viewModels.Add(new StateCellViewModel(item.Name, item.State));
						break;
				}
			}
			Items = viewModels;
		}
	}

	public class ItemListParameters
	{
		public string Name { get; set; }
	}
}

