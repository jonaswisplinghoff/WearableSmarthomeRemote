using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;
using System.Windows.Input;
using System.Diagnostics;

namespace WearableSmarthomeRemote.WatchCore
{
	public class WidgetListViewModel : MvxViewModel
	{

		private string _widgetId;
		private readonly IOpenHab _openHab;
		public WidgetListViewModel(IOpenHab openHab)
		{
			_openHab = openHab;
		}

		public void Init(WidgetListParameters parameters)
		{
			Debug.WriteLine(parameters.WidgetId);
			_widgetId = parameters.WidgetId;
		}

		public override void Start()
		{
			Update();
		}

		async void Update()
		{
			var sitemap = await _openHab.GetSitemapWithName();

			Widget result = null;
			foreach (Widget widget in sitemap.homepage.widgets)
			{

				result = FindWidgetWithId(widget, _widgetId);
				if (result != null)
				{
					break;
				}
			}

			Widgets = new List<WidgetCellViewModel>();
			foreach (Widget w in result.widgets)
			{
				Widgets.Add(new WidgetCellViewModel(w));
			}
		}

		private Widget FindWidgetWithId(Widget widget, string id)
		{
			if (widget.widgetId == id)
			{
				return widget;
			}
			foreach (Widget w in widget.widgets)
			{
				FindWidgetWithId(w, id);
			}
			return null;
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
			Debug.WriteLine(widgetVM.Widget.widgetId);
			if (widgetVM.Widget.item != null)
			{
				ShowViewModel<ItemListViewModel>(new ItemListParameters() { Name = widgetVM.Widget.item.name });
			}
		}
	}

	public class WidgetListParameters
	{
		public string WidgetId { get; set; }
	}
}

