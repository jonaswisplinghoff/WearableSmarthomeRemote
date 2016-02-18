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

		private bool _lamp1On;
		public bool Lamp1On
		{
			get { return _lamp1On; }
			set
			{
				if (value != _lamp1On)
				{
					_openHab.SetLampState(1, value);
				}
				_lamp1On = value;
				RaisePropertyChanged(() => Lamp1On);
			}
		}

		private bool _lamp2On;
		public bool Lamp2On
		{
			get { return _lamp2On; }
			set
			{
				if (value != _lamp2On)
				{
					_openHab.SetLampState(2, value);
				}
				_lamp2On = value;
				RaisePropertyChanged(() => Lamp2On);
			}
		}

		private bool _lamp3On;
		public bool Lamp3On
		{
			get { return _lamp3On; }
			set
			{
				if (value != _lamp3On)
				{
					_openHab.SetLampState(3, value);
				}
				_lamp3On = value;
				RaisePropertyChanged(() => Lamp3On);
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
			Items = new List<Item>(items);

			foreach (Item item in items)
			{
				switch (item.name)
				{
					case "Toggle_1":
						Lamp1On = item.state == "ON";
						break;
					case "Toggle_2":
						Lamp2On = item.state == "ON";
						break;
					case "Toggle_3":
						Lamp3On = item.state == "ON";
						break;
					default:
						break;
				}
			}
		}
	}
}

