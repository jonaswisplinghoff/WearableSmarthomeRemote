using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.watchOS;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class StateCellView : MvxRowController
	{
		public override void SetupBindingWithViewModel(MvxViewModel viewModel)
		{
			this.ViewModel = viewModel;

			var set = this.CreateBindingSet<StateCellView, StateCellViewModel>();
			set.Bind(ItemNameLabel).To(vm => vm.ItemName);
			set.Bind(ItemStateLabel).To(vm => vm.State);
			set.Apply();
		}
	}
}