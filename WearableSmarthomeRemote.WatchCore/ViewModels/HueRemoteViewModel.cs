using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
using System.Collections.Generic;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.WatchCore
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
			foreach (Item item in items)
			{

			}
		}

		private MvxCommand _nextPageCommand;
		public ICommand NextPageCommand
		{
			get
			{
				_nextPageCommand = _nextPageCommand ?? new MvxCommand(() => NextPage());
				return _nextPageCommand;
			}
		}

		void NextPage()
		{
			this.ShowViewModel<OverviewViewModel>();
		}

	}
}

