namespace MvvmCross.watchOS.Views
{
	using System;
	using Foundation;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform.Core;
	using MvvmCross.Platform.watchOS.Views;

	public class MvxInterfaceControllerAdapter : MvxBaseInterfaceControllerAdapter
	{
		protected IMvxWatchOSView WatchOSView => base.InterfaceController as IMvxWatchOSView;

		public MvxInterfaceControllerAdapter(IMvxEventSourceInterfaceController eventSource)
			: base(eventSource)
		{
			if (!(eventSource is IMvxWatchOSView))
				throw new ArgumentException("eventSource", "eventSource should be a IMvxWatchOSView");
		}

		public override void HandleAwakeCalled(object sender, MvxValueEventArgs<NSObject> e)
		{
			this.WatchOSView.OnViewCreate();
			base.HandleAwakeCalled(sender, e);
		}

		public override void HandleDisposeCalled(object sender, EventArgs e)
		{
			this.WatchOSView.OnViewDestroy();
			base.HandleDisposeCalled(sender, e);
		}
	}
}