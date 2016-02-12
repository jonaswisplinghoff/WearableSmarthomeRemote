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
			Update();
		}

		private bool _lamp1On;
		public bool Lamp1On
		{
			get { return _lamp1On; }
			set { 
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
			set {
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
			set { 
				if (value != _lamp3On)
				{
					_openHab.SetLampState(3, value);
				}
				_lamp3On = value; 
				RaisePropertyChanged(() => Lamp3On);
			}
		}

		private string _lampState;
		public string LampState
		{
			get { return _lampState; }
			set { _lampState = value; RaisePropertyChanged(() => LampState); }
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

			var lamp1 = await _openHab.GetLampState(1);
			var lamp2 = await _openHab.GetLampState(2);
			var lamp3 = await _openHab.GetLampState(3);

			Lamp1On = lamp1 == "ON" ? true : false;
			Lamp2On = lamp2 == "ON" ? true : false;
			Lamp3On = lamp3 == "ON" ? true : false;

			string lampState = "Lamp 1: " + lamp1;
				lampState += " - Lamp 2: " + lamp2;
				lampState += " - Lamp 3: " + lamp3;
			LampState = lampState;
		}
	}
}

