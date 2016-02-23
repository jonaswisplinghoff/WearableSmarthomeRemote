using System;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.MobileCore
{
	public class StateItemCellViewModel : ItemCellViewModel
	{
		public StateItemCellViewModel(string name, string state)
		{
			_itemName = name;
			_state = state;
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
	}
}

