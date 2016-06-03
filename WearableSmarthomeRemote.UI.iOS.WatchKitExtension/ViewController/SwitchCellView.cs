using System;
using System.Diagnostics;
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
			set.Bind(this.WidgetSwitch).To(vm => vm.On);
			set.Bind(this).For(v => v.SwitchStateChanged).To(vm => vm.SwitchStateChangedCommand);
			set.Bind(this.WidgetSwitch).For("Title").To(vm => vm.ItemName);
			set.Apply();
		}

		public event EventHandler<SwitchStateChangedEventArgs> SwitchStateChanged = delegate { };
		partial void OnSwitchStateChanged(bool value)
		{
			Debug.WriteLine(value);

			SwitchStateChanged(this, new SwitchStateChangedEventArgs(value));
		}
	}

	public class SwitchStateChangedEventArgs : EventArgs
	{
		public SwitchStateChangedEventArgs(bool on)
		{
			this.On = on;
		}
		public bool On { get; set; }
	}
}