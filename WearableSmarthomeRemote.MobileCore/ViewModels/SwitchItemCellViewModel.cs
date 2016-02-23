using System;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.MobileCore
{
	public class SwitchItemCellViewModel : ItemCellViewModel
	{
		protected readonly IOpenHab _openHab;
		public SwitchItemCellViewModel(IOpenHab openHab, string name, string state) : base(name, state)
		{
			_openHab = openHab;
			_on = state == "ON";
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

