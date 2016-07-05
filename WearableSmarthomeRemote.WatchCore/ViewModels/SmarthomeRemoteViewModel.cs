using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using WearableSmarthomeRemote.Core;

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

		private string _heading;
		public string Heading
		{
			get
			{
				return _heading;
			}
			set
			{
				_heading = value;
				RaisePropertyChanged(() => Heading);
			}
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
				_nextPageCommand = _nextPageCommand ?? new MvxCommand(NextPage);
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
			ShowViewModel<WidgetListViewModel>(new WidgetListParameters() { WidgetId = widgetVM.Widget.WidgetId });
		}

		async void Update()
		{
			var sitemap = await _openHab.GetSitemapWithName();

			Heading = sitemap.Label;

			var v = new List<WidgetCellViewModel>();
			foreach (Widget widget in sitemap.Homepage.Widgets)
			{
				v.Add(new WidgetCellViewModel(widget));
			}

			Widgets = v;
		}
	}
}