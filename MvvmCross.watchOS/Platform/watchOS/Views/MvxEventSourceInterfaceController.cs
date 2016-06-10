namespace MvvmCross.Platform.watchOS.Views
{
	using System;
	using Foundation;
	using MvvmCross.Platform.Core;
	using WatchKit;

	public class MvxEventSourceInterfaceController
		: WKInterfaceController
		  , IMvxEventSourceInterfaceController
	{
		protected MvxEventSourceInterfaceController()
		{
		}

		protected MvxEventSourceInterfaceController(IntPtr handle)
			: base(handle)
		{
		}

		protected MvxEventSourceInterfaceController(NSObjectFlag flag)
			: base(flag)
		{
		}

		public override void Awake(NSObject context)
		{
			base.Awake(context);
			this.AwakeCalled.Raise(this, context);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.DisposeCalled.Raise(this);
			}
			base.Dispose(disposing);
		}

		public event EventHandler<MvxValueEventArgs<NSObject>> AwakeCalled;

		public event EventHandler DisposeCalled;
	}
}

