using System;
using Foundation;
using MvvmCross.watchOS;
using MvvmCross.Binding.BindingContext;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.Core.ViewModels;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class WidgetCellView : MvxRowController
	{
		public WidgetCellView()
		{
			this.BindingContext = new MvxBindingContext();
		}

		public override void SetupBindingWithViewModel(MvxViewModel viewModel)
		{
			this.ViewModel = viewModel;

			var set = this.CreateBindingSet<WidgetCellView, WidgetCellViewModel>();
			set.Bind(WidgetLabel).To(vm => vm.WidgetName);
			set.Apply();
		}
	}
}