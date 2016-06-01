using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using WatchKit;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Foundation;
using System.Linq;
using MvvmCross.Binding.BindingContext;

namespace MvvmCross.watchOS.Binding
{
	public class MvxWKInterfaceTableTargetBinding<T> : MvxTargetBinding where T : MvxViewModel
	{
		public MvxWKInterfaceTableTargetBinding(WKInterfaceTable target)
			: base(target)
		{
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - WKInterfaceTable is null in MvxWKInterfaceTableTargetBinding");
			}
		}

		public override Type TargetType => typeof(List<T>);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public override void SetValue(object value)
		{

			var table = Target as WKInterfaceTable;
			var list = value as List<T>;
			if (table == null || list == null)
			{
				return;
			}

			table.SetNumberOfRows(list.Count, "WidgetItem");

			for (var i = 0; i < list.Count; i++)
			{
				var view = table.GetRowController(i) as MvxRowController;

				view.BindingContext = new MvxBindingContext();
				view.ViewModel = list.ElementAt(i);

				view.SetupBinding();
			}
		}
	}
}