using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
using System.Collections.Generic;
using WearableSmarthomeRemote.Core;
using MvvmCross.Binding.Bindings;

namespace WearableSmarthomeRemote.WatchCore
{
	public class SmarthomeRemoteViewModel : MvxViewModel
	{
		private readonly IOpenHab _openHab;
		public SmarthomeRemoteViewModel(IOpenHab openHab)
		{
			_openHab = openHab;
		}

		public override void Start()
		{
			Update();
		}

		private List<WidgetCellViewModel> _widgets;
		public List<WidgetCellViewModel> Widgets
		{
			get
			{
				return _widgets;
			}
			set
			{
				_widgets = value;
				RaisePropertyChanged(() => Widgets);
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
			this.ShowViewModel<ItemListViewModel>();
		}

		private MvxCommand<WidgetCellViewModel> _widgetSelectedCommand;
		public ICommand WidgetSelectedCommand
		{
			get
			{
				_widgetSelectedCommand = _widgetSelectedCommand ?? new MvxCommand<WidgetCellViewModel>(WidgetSelected);
				return _widgetSelectedCommand;
			}
		}

		void WidgetSelected(WidgetCellViewModel widgetVM)
		{
			ShowViewModel<WidgetListViewModel>(new WidgetListParameters() { WidgetId = widgetVM.Widget.widgetId });
		}

		async void Update()
		{
			var sitemap = await _openHab.GetSitemapWithName();

			Widgets = new List<WidgetCellViewModel>();
			foreach (Widget widget in sitemap.homepage.widgets)
			{
				Widgets.Add(new WidgetCellViewModel(widget));
			}
		}
	}
}