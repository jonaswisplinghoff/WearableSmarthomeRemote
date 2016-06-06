﻿using System;
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
		public MvxWKInterfaceTableTargetBinding(WKInterfaceTable target)
					: base(target)
		{
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

			var rowIdentifiers = new List<string>();
			foreach (TViewModel vm in list)
			{
				var viewModelName = vm.GetType().Name;
				var rowId = IdentifierFromViewModelName(viewModelName);
				rowIdentifiers.Add(rowId);
			};
			table.SetRowTypes(rowIdentifiers.ToArray());

			for (var i = 0; i < list.Count; i++)
			{
				var view = table.GetRowController(i) as MvxRowController;
				view.SetupBindingWithViewModel(list[i]);
			}
		}

		private string IdentifierFromViewModelName(string vmName)
		{
			return vmName.Replace("Model", "");
		}
	}
}