using System;
using MvvmCross.Core.ViewModels;
namespace WearableSmarthomeRemote.WatchCore
{
	public class WidgetCellViewModel : MvxViewModel
	{
		public WidgetCellViewModel(string name)
		{
			_widgetName = name;
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
	}
}
