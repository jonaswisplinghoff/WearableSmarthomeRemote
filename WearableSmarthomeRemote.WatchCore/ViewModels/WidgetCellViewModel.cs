using System;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;
namespace WearableSmarthomeRemote.WatchCore
{
	public class WidgetCellViewModel : MvxViewModel
	{
		private Widget _widget;

		public WidgetCellViewModel(Widget widget)
		{
			_widget = widget;
			_widgetName = widget.label;
		}

		private string _widgetName;
		public string WidgetName
		{
			get { return _widgetName; }
			set
			{
				_widgetName = value;
				RaisePropertyChanged(() => WidgetName);
			}
		}

		public string WidgetId
		{
			get { return _widget.widgetId; }
		}
	}
}
