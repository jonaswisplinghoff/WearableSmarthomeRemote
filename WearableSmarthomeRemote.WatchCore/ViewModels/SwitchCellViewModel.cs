using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.WatchCore
{
	public class SwitchCellViewModel : ItemCellViewModel
	{
		protected readonly IOpenHab _openHab;
		public SwitchCellViewModel(IOpenHab openHab, string name, string state) : base(name, state)
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
				base.State = value ? "ON" : "OFF";
				RaisePropertyChanged(() => On);
			}
		}

		private MvxCommand<bool> _switchStateChangedCommand;
		public ICommand SwitchStateChangedCommand
		{
			get
			{
				_switchStateChangedCommand = _switchStateChangedCommand ?? new MvxCommand<bool>(UpdateSwitchState);
				return _switchStateChangedCommand;
			}
		}

		void UpdateSwitchState(bool value)
		{
			this._on = value;
		}
	}
}

