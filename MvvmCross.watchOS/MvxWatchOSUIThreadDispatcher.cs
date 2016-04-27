namespace MvvmCross.watchOS
{
	using System;
	using System.Threading;

	using MvvmCross.Platform.Core;

	using UIKit;

	public abstract class MvxWatchOSUIThreadDispatcher
		: MvxMainThreadDispatcher
	{
		private readonly SynchronizationContext _uiSynchronizationContext;

		protected MvxWatchOSUIThreadDispatcher()
		{
			this._uiSynchronizationContext = SynchronizationContext.Current;
		}

		public bool RequestMainThreadAction(Action action)
		{
			if (this._uiSynchronizationContext == SynchronizationContext.Current)
				action();
			else
				UIApplication.SharedApplication.BeginInvokeOnMainThread(() => ExceptionMaskedAction(action));
			return true;
		}
	}
}