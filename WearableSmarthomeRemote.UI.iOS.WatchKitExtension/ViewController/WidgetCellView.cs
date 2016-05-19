using System;
using Foundation;
using MvvmCross.watchOS;
using MvvmCross.Binding.BindingContext;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class WidgetCellView : MvxRowController
	{
		public WidgetCellView()
		{
			var set = this.CreateBindingSet<WidgetCellView, WidgetCellViewModel>();
			set.Bind(WidgetLabel).To(vm => vm.WidgetName);
			set.Apply();
		}
	}
}