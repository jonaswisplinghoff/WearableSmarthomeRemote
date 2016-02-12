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
			_lampOn = "Lamp on";
		}

		private string _lampOn;
		public string LampOn
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

		async void Update()
		{
			System.Diagnostics.Debug.WriteLine("update");
			string lampState = await _openHab.GetLampState();
			LampOn = lampState;
		}
	}
}

