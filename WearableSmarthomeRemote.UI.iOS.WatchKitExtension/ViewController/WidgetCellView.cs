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
			this.CreateBinding(WidgetLabel).To((WidgetCellViewModel vm) => vm.WidgetName).Apply();
		}
	}
}