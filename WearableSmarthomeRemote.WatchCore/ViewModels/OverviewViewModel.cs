using System;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;
using System.Diagnostics;
using System.Collections.Generic;


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

		private List<Item> _items;
		public List<Item> Items
		{
			get { return _items; }
			set
			{
				_items = new List<Item>();
				foreach (Item item in value)
				{
					if (item.type != "GroupItem")
					{
						_items.Add(item);
					}
				}

				RaisePropertyChanged(() => Items);
				Debug.WriteLine("Items updated: " + _items.Count.ToString());
			}
		}

		async void Update()
		{
			var items = await _openHab.GetItems();
			Items = new List<Item>(items);
		}
	}
}

