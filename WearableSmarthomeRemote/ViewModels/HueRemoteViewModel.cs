using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace WearableSmarthomeRemote.Core
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
			_lampOn = true;
		}

		private bool _lampOn;
		public bool LampOn
		{
			get { return _lampOn; }
			set { _lampOn = value; RaisePropertyChanged(() => LampOn); }
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

		private void Update()
		{
			
			System.Diagnostics.Debug.WriteLine("update");
			string lampState = _openHab.GetLampState();
			if (lampState == "ON")
			{
				LampOn = true;
			}
			else 
			{
				LampOn = false;
			}
		}
	}
}

