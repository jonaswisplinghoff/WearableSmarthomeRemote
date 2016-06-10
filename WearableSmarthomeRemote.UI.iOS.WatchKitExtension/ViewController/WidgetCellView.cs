namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	using MvvmCross.Binding.BindingContext;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.watchOS.Views;
	using WearableSmarthomeRemote.WatchCore;

	public partial class WidgetCellView : MvxRowController
	{
		public override void SetupBindingWithViewModel(MvxViewModel viewModel)
		{
			this.ViewModel = viewModel;

			var set = this.CreateBindingSet<WidgetCellView, WidgetCellViewModel>();
			set.Bind(WidgetLabel).To(vm => vm.WidgetName);
			set.Apply();
		}
	}
}