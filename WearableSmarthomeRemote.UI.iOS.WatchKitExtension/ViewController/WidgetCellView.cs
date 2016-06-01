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
		}

		public override void SetupBinding()
		{
			//this.Request = new MvxViewModelRequest<WidgetCellViewModel>(new MvxBundle(null), null, MvxRequestedBy.Unknown);
			this.OnViewCreate();



			//TODO: viewModel erst später binden
			var set = this.CreateBindingSet<WidgetCellView, WidgetCellViewModel>();
			set.Bind(WidgetLabel).To(vm => vm.WidgetName);
			set.Apply();
		}
	}
}