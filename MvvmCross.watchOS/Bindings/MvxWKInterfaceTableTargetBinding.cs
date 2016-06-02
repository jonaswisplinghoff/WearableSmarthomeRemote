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
	public class MvxWKInterfaceTableTargetBinding<TViewModel> : MvxTargetBinding where TViewModel : MvxViewModel
	{
		string _identifier;

		public MvxWKInterfaceTableTargetBinding(WKInterfaceTable target, string identifier = "default")
			: base(target)
		{
			this._identifier = identifier;
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - WKInterfaceTable is null in MvxWKInterfaceTableTargetBinding");
			}
		}

		public override Type TargetType => typeof(List<TViewModel>);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public override void SetValue(object value)
		{
			var table = Target as WKInterfaceTable;
			var list = value as List<TViewModel>;
			if (table == null || list == null)
			{
				return;
			}

			if (_identifier != "default")
			{
				table.SetNumberOfRows(list.Count, _identifier);
			}
			else {
				var types = new List<string>();
				foreach (TViewModel vm in list)
				{
					//TODO: receive Identifiers
					types.Add("StateCellView");
				};
				table.SetRowTypes(types.ToArray());
			}

			for (var i = 0; i < list.Count; i++)
			{
				var view = table.GetRowController(i) as MvxRowController;
				view.SetupBindingWithViewModel(list.ElementAt(i));
			}
		}
	}
}