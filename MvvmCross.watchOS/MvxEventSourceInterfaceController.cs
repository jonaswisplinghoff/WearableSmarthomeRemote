namespace MvvmCross.watchOS
{
	using System;

	using Foundation;
	using WatchKit;
	using MvvmCross.Platform.Core;

	using UIKit;

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

