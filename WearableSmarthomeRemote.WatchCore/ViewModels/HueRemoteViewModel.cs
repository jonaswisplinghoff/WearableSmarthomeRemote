using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
using System.Collections.Generic;
using WearableSmarthomeRemote.Core;
using MvvmCross.Binding.Bindings;

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

		private string _sitemap;
		public string Sitemap
		{
			get
			{
				return _sitemap;
			}
			set
			{
				_sitemap = value;
				RaisePropertyChanged(() => Sitemap);
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

		async void Update()
		{
			var sitemap = await _openHab.GetSitemapWithName();
			Sitemap = sitemap.name;
		}
	}
}