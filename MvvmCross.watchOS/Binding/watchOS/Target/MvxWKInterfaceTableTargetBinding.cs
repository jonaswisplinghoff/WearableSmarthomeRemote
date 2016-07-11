namespace MvvmCross.Binding.watchOS.Target
{
	using System;
	using System.Collections.Generic;
	using MvvmCross.Binding;
	using MvvmCross.Binding.Bindings.Target;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Platform.Platform;
	using MvvmCross.watchOS.Views;
	using WatchKit;

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
			var vms = value as List<TViewModel>;
			if (table == null || vms == null)
			{
				return;
			}

			var rowIdentifiers = new List<string>();
			foreach (TViewModel vm in vms)
			{
				var viewModelName = vm.GetType().Name;
				var rowId = IdentifierFromViewModelName(viewModelName);
				rowIdentifiers.Add(rowId);
			}
			table.SetRowTypes(rowIdentifiers.ToArray());

			for (var i = 0; i < vms.Count; i++)
			{
				var view = table.GetRowController(i) as MvxRowController;
				view.SetupBindingWithViewModel(vms[i]);
			}
		}

		private string IdentifierFromViewModelName(string vmName)
		{
			return vmName.Replace("Model", "");
		}
	}
}