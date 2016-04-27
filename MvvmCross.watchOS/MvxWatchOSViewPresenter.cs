using UIKit;
using WatchKit;

namespace MvvmCross.watchOS
{
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform.Exceptions;
	using MvvmCross.Platform.Platform;

	using UIKit;

	public class MvxWatchOSViewPresenter
		: MvxBaseWatchOSViewPresenter
	{

		private MvxInterfaceController _currentInterfaceController;

		public MvxWatchOSViewPresenter(MvxInterfaceController controller)
		{
			_currentInterfaceController = controller;
		}

		public override void Show(MvxViewModelRequest request)
		{
			var view = this.CreateInterfaceControllerFor(request);

#warning Need to reinsert ClearTop type functionality here
			//if (request.ClearTop)
			//    ClearBackStack();
			this.Show(view);
		}

		public override void ChangePresentation(MvxPresentationHint hint)
		{
			base.ChangePresentation(hint);

			if (hint is MvxClosePresentationHint)
			{
				this.Close((hint as MvxClosePresentationHint).ViewModelToClose);
				return;
			}
		}

		public virtual void Show(IMvxWatchOSView view)
		{
			var interfaceController = view as MvxInterfaceController;
			if (interfaceController == null)
				throw new MvxException("Passed in IMvxWatchOSView is not a WKInterfaceController");

			var viewName = view.Request.GetType().ToString();

			_currentInterfaceController.PushController("SmarthomeRemoteView", "");

			_currentInterfaceController = interfaceController;
		}

		public virtual void CloseModalViewController()
		{
			this._currentInterfaceController.PopController();
		}

		public virtual void Close(IMvxViewModel toClose)
		{
			/*var topViewController = this.MasterNavigationController.TopViewController;

			if (topViewController == null)
			{
				MvxTrace.Warning("Don't know how to close this viewmodel - no topmost");
				return;
			}

			var topView = topViewController as IMvxWatchOSView;
			if (topView == null)
			{
				MvxTrace.Warning(
							   "Don't know how to close this viewmodel - topmost is not a touchview");
				return;
			}

			var viewModel = topView.ReflectionGetViewModel();
			if (viewModel != toClose)
			{
				MvxTrace.Warning(
							   "Don't know how to close this viewmodel - topmost view does not present this viewmodel");
				return;
			}

			this.MasterNavigationController.PopViewController(true);*/
		}
	}
}