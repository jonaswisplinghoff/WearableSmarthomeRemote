namespace MvvmCross.watchOS.Views.Presenters
{
	using System.Collections.Generic;
	using System.Linq;
	using Foundation;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform;
	using MvvmCross.Platform.Platform;

	public class MvxWatchOSViewPresenter
		: MvxBaseWatchOSViewPresenter
	{

		private List<MvxInterfaceController> _interfaceControllers = new List<MvxInterfaceController>();

		public MvxWatchOSViewPresenter(MvxInterfaceController controller)
		{
			_interfaceControllers.Add(controller);
		}

		public override void Show(MvxViewModelRequest request)
		{
			var viewType = Mvx.Resolve<IMvxWatchOSViewCreator>().GetViewTypeFromViewModelRequest(request);
			var modelPath = viewType.ToString();
			var viewName = modelPath.Split('.').Last();
			this.Show(viewName);
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

		public virtual void Show(string viewName)
		{
			_interfaceControllers.Last().PushController(viewName, (NSObject)null);
		}

		public virtual void CloseModalViewController()
		{
			_interfaceControllers.Last().PopController();
		}

		public virtual void Close(IMvxViewModel toClose)
		{
			var topInterfaceController = this._interfaceControllers.Last();

			if (topInterfaceController == null)
			{
				MvxTrace.Warning("Don't know how to close this viewmodel - no topmost");
				return;
			}

			var topView = topInterfaceController as IMvxWatchOSView;
			if (topView == null)
			{
				MvxTrace.Warning(
							   "Don't know how to close this viewmodel - topmost is not a watchOSView");
				return;
			}

			var viewModel = topView.ReflectionGetViewModel();
			if (viewModel != toClose)
			{
				MvxTrace.Warning(
							   "Don't know how to close this viewmodel - topmost view does not present this viewmodel");
				return;
			}

			topInterfaceController.PopController();
		}
	}
}