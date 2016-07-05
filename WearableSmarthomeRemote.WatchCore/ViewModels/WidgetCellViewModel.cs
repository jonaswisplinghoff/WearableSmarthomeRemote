using System;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;
namespace WearableSmarthomeRemote.WatchCore
{
	public class WidgetCellViewModel : MvxViewModel
	{
		public WidgetCellViewModel(Widget widget)
		{
			Widget = widget;
			_widgetName = widget.Label;
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

		public Widget Widget
		{
			get; set;
		}
	}
}
