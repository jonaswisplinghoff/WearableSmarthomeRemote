using System;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Input;

namespace WearableSmarthomeRemote.WatchCore
{
	public class OverviewViewModel : MvxViewModel
	{
		private readonly IOpenHab _openHab;
		public OverviewViewModel(IOpenHab openHab)
		{
			_openHab = openHab;
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
			var items = await _openHab.GetItems();

			var viewModels = new List<ItemCellViewModel>();
			foreach (Item item in items)
			{
				Debug.WriteLine("Item: " + item.name + ", state: " + item.state);
				switch (item.type)
				{
					case "SwitchItem":
						viewModels.Add(new SwitchItemCellViewModel(_openHab, item.name, item.state));
						break;
					case "GroupItem":
						break;
					case "ColorItem":
						viewModels.Add(new ColorItemCellViewModel(item.name, item.state));
						break;
					default:
						viewModels.Add(new StateItemCellViewModel(item.name, item.state));
						break;
				}
			}
			Items = new List<ItemCellViewModel>(viewModels);
		}

	}
}

