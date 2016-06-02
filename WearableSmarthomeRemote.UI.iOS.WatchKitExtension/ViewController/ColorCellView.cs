using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.watchOS;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
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