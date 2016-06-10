namespace MvvmCross.watchOS.Views
{
	using System;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform.Platform;
	using MvvmCross.watchOS.Views.Presenters;

	public class MvxWatchOSViewDispatcher
		: MvxWatchOSUIThreadDispatcher
		  , IMvxViewDispatcher
	{
		private readonly IMvxWatchOSViewPresenter _presenter;

		public MvxWatchOSViewDispatcher(IMvxWatchOSViewPresenter presenter)
		{
			this._presenter = presenter;
		}

		public bool ShowViewModel(MvxViewModelRequest request)
		{
			Action action = () =>
				{
					MvxTrace.TaggedTrace("iOSNavigation", "Navigate requested");
					this._presenter.Show(request);
				};
			return this.RequestMainThreadAction(action);
		}

		public bool ChangePresentation(MvxPresentationHint hint)
		{
			return this.RequestMainThreadAction(() => this._presenter.ChangePresentation(hint));
		}
	}
}