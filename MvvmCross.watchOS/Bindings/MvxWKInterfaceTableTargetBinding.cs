using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using WatchKit;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace MvvmCross.watchOS.Binding
{
	public class MvxWKInterfaceTableTargetBinding : MvxTargetBinding
	{
		public MvxWKInterfaceTableTargetBinding(WKInterfaceTable target)
			: base(target)
		{
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error,
									  "Error - WKInterfaceTable is null in MvxWKInterfaceTableTargetBinding");
			}
		}

		public override void SetValue(object value)
		{
			var table = Target as WKInterfaceTable;
			var list = value as List<MvxViewModel>;
			if (table == null || list == null)
			{
				//return;
			}

			table.SetNumberOfRows(3, "WidgetItem");
		}

		public override Type TargetType
		{
			get
			{
				return typeof(List<MvxViewModel>);
			}
		}

		public override MvxBindingMode DefaultMode
		{
			get
			{
				return MvxBindingMode.OneWay;
			}
		}
	}
}

