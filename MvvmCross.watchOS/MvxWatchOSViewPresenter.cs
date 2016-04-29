using UIKit;
using WatchKit;
using System.Linq;

namespace MvvmCross.watchOS
{
	using System.Collections.Generic;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform;
	using MvvmCross.Platform.Exceptions;
	using MvvmCross.Platform.Platform;

	using UIKit;

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
			//var view = this.CreateInterfaceControllerFor(request);

			var modelName = viewType.ToString();
			this.Show(modelName);
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

		public virtual void Show(string viewPath)
		{
			/*var interfaceController = view as MvxInterfaceController;
			if (interfaceController == null)
				throw new MvxException("Passed in IMvxWatchOSView is not a WKInterfaceController");*/
			var viewName = viewPath.Split('.').Last();

			_interfaceControllers.Last().PushController(viewName, "");
		}

		public virtual void CloseModalViewController()
		{
			_interfaceControllers.Last().PopController();
		}

		public virtual void Close(IMvxViewModel toClose)
		{
			var topInterfaceController = this._interfaceControllers.Last();

			{
				if (topInterfaceController == null)
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