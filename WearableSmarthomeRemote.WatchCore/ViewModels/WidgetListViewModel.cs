using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using WearableSmarthomeRemote.Core;
using MvvmCross.Binding.Bindings;
using System.Windows.Input;
using System.Diagnostics;

namespace WearableSmarthomeRemote.WatchCore
{
	public class WidgetListViewModel : MvxViewModel
	{
		private List<Widget> _widgetList;

		private readonly IOpenHab _openHab;
		public WidgetListViewModel(IOpenHab openHab)
		{
			_openHab = openHab;
		}

		public void Init(WidgetListParameters parameters)
		{
			Debug.WriteLine(parameters.WidgetId);
		}

		public override void Start()
		{
			Update();
		}

		void Update()
		{
			/*Widgets = new List<WidgetCellViewModel>();
			foreach (Widget widget in _widgetList)
			{
				Widgets.Add(new WidgetCellViewModel(widget));
			}*/
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
			Debug.WriteLine(widgetVM.WidgetName);

		}
	}

	public class WidgetListParameters
	{
		public string WidgetId { get; set; }
	}
}

