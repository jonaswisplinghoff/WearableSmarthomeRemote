using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.watchOS;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class SwitchCellView : MvxRowController
	{
		public override void SetupBindingWithViewModel(MvxViewModel viewModel)
		{
			this.ViewModel = viewModel;

			var set = this.CreateBindingSet<SwitchCellView, SwitchCellViewModel>();
			//set.Bind(this.WidgetSwitch).For(v => v.SetOn).To(vm => vm.On);
			//set.Bind(this.WidgetSwitch).For(v => v.SetTitle).To(vm => vm.ItemName);
			set.Apply();
		}
	}
}