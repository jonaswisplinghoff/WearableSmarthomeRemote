namespace WearableSmarthomeRemote.UI.iOS.WatchAppExtension
{
	using MvvmCross.Binding.BindingContext;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.watchOS.Views;
	using WearableSmarthomeRemote.WatchCore;

	public partial class ColorCellView : MvxRowController
	{
		public override void SetupBindingWithViewModel(MvxViewModel viewModel)
		{
			this.ViewModel = viewModel;

			var set = this.CreateBindingSet<ColorCellView, ColorCellViewModel>();
			set.Bind(this.WidgetLabel).To(vm => vm.ItemName);
			//set.Bind(this.WidgetColor).For(v => v.SetBackgroundColor).To(vm => vm.Color);
			set.Apply();
		}
	}
}