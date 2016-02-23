using System;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.MobileCore
{
	public class SwitchItemCellViewModel : MvxViewModel
	{
		protected readonly IOpenHab _openHab;
		public SwitchItemCellViewModel(IOpenHab openHab, string name, string state, string type)
		{
			_openHab = openHab;
			_itemName = name;
			_type = type;
			_state = state;
			_on = state == "ON";
		}

		private string _itemName;
		public string ItemName
		{
			get { return _itemName; }
			set
			{
				_itemName = value;
				RaisePropertyChanged(() => ItemName);
			}

		}

		private string _type;
		public string Type
		{
			get { return _type; }
			set
			{
				_type = value;
				RaisePropertyChanged(() => Type);
			}
		}

		private string _state;
		public string State
		{
			get { return _state; }
			set
			{
				_state = value;
				RaisePropertyChanged(() => State);
			}
		}

		private bool _on;
		public bool On
		{
			get { return _on; }
			set
			{
				_openHab.SetSwitchState(ItemName, value);
				_on = value;
				RaisePropertyChanged(() => On);
			}
		}


	}
}

