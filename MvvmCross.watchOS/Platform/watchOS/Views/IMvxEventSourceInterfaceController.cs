namespace MvvmCross.Platform.watchOS.Views
{
	using System;
	using Foundation;
	using MvvmCross.Platform.Core;

	public interface IMvxEventSourceInterfaceController : IMvxDisposeSource
	{
		event EventHandler<MvxValueEventArgs<NSObject>> AwakeCalled;
	}
}

