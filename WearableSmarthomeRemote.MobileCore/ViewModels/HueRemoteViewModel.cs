using System;
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

		private List<SwitchItemCellViewModel> _items;
		public List<SwitchItemCellViewModel> Items
		{
			get { return _items; }
			set
			{
				_items = new List<SwitchItemCellViewModel>();
				foreach (SwitchItemCellViewModel item in value)
				{
					if (item.Type != "GroupItem")
					{
						_items.Add(item);
					}
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

			var viewModels = new List<SwitchItemCellViewModel>();
			foreach (Item item in items)
			{
				var itemVM = new SwitchItemCellViewModel(_openHab, item.name, item.state, item.type);
				viewModels.Add(itemVM);
			}
			Items = new List<SwitchItemCellViewModel>(viewModels);
		}
	}
}

