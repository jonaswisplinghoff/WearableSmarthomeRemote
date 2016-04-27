using Foundation;
namespace MvvmCross.watchOS
{
	using System;

	using MvvmCross.Platform.Core;

	using WatchKit;

	public class MvxBaseInterfaceControllerAdapter
	{
		private readonly IMvxEventSourceInterfaceController _eventSource;

		protected WKInterfaceController InterfaceController => this._eventSource as WKInterfaceController;

		public MvxBaseInterfaceControllerAdapter(IMvxEventSourceInterfaceController eventSource)
		{
			if (eventSource == null)
				throw new ArgumentException("eventSource - eventSource should not be null");

			if (!(eventSource is WKInterfaceController))
				throw new ArgumentException("eventSource - eventSource should be a WKInterfaceController");

			this._eventSource = eventSource;
			this._eventSource.AwakeCalled += this.HandleAwakeCalled;
			this._eventSource.DisposeCalled += this.HandleDisposeCalled;
		}

		public virtual void HandleDisposeCalled(object sender, EventArgs e)
		{
		}

		public virtual void HandleAwakeCalled(object sender, MvxValueEventArgs<NSObject> e)
		{
		}
	}
}