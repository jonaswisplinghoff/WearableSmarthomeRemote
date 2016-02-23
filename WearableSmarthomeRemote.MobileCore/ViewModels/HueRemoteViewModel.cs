﻿using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
using System.Collections.Generic;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.MobileCore
{
	public class HueRemoteViewModel : MvxViewModel
	{
		private readonly IOpenHab _openHab;
		public HueRemoteViewModel(IOpenHab openHab)
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

		private MvxCommand _updateCommand;
		public ICommand UpdateCommand
		{
			get
			{
				_updateCommand = _updateCommand ?? new MvxCommand(() => Update());
				return _updateCommand;
			}
		}

		async void Update()
		{
			var items = await _openHab.GetItems();

			var viewModels = new List<ItemCellViewModel>();
			foreach (Item item in items)
			{
				ItemCellViewModel itemVM;
				switch (item.type)
				{
					case "SwitchItem":
						itemVM = new SwitchItemCellViewModel(_openHab, item.name, item.state);
						break;
					default:
						itemVM = new StateItemCellViewModel(item.name, item.state);
						break;
				}
				viewModels.Add(itemVM);
			}
			Items = new List<ItemCellViewModel>(viewModels);
		}
	}
}

