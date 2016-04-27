namespace MvvmCross.watchOS
{
	using System;

	using MvvmCross.Binding.BindingContext;
	using MvvmCross.Platform.Platform;
	using MvvmCross.Platform.iOS.Views;

	public class MvxBindingInterfaceControllerAdapter : MvxBaseInterfaceControllerAdapter
	{
		protected IMvxWatchOSView WatchOSView => this.InterfaceController as IMvxWatchOSView;

		public MvxBindingInterfaceControllerAdapter(IMvxEventSourceInterfaceController eventSource)
			: base(eventSource)
		{
			if (!(eventSource is IMvxWatchOSView))
				throw new ArgumentException("eventSource", "eventSource should be a IMvxWatchOSView");

			this.WatchOSView.BindingContext = new MvxBindingContext();
		}

		public override void HandleDisposeCalled(object sender, EventArgs e)
		{
			if (this.WatchOSView == null)
			{
				MvxTrace.Warning("iosView is null for clearup of bindings in type {0}",
							   this.WatchOSView?.GetType().Name);
				return;
			}
			this.WatchOSView.ClearAllBindings();
			base.HandleDisposeCalled(sender, e);
		}
	}
}