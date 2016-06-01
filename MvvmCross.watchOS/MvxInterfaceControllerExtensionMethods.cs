using System;
using System.Runtime.CompilerServices;
namespace MvvmCross.watchOS
{
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform;
	using MvvmCross.Platform.Exceptions;
	using MvvmCross.Platform.Platform;

	public static class MvxInterfaceControllerExtensionMethods
	{
		public static void OnViewCreate(this IMvxWatchOSView watchosView)
		{
			watchosView.OnViewCreate(watchosView.LoadViewModel);
		}

		private static IMvxViewModel LoadViewModel(this IMvxWatchOSView watchosView)
		{
#warning NullViewModel needed?
			// how to do N
			//if (typeof (TViewModel) == typeof (MvxNullViewModel))
			//    return new MvxNullViewModel() as TViewModel;

			if (watchosView.Request == null)
			{
				MvxTrace.Trace(
					"Request is null - assuming this is a TabBar type situation where ViewDidLoad is called during construction... patching the request now - but watch out for problems with virtual calls during construction");
				watchosView.Request = Mvx.Resolve<IMvxCurrentRequest>().CurrentRequest;
			}

			var instanceRequest = watchosView.Request as MvxViewModelInstanceRequest;
			if (instanceRequest != null)
			{
				return instanceRequest.ViewModelInstance;
			}

			var loader = Mvx.Resolve<IMvxViewModelLoader>();
			var viewModel = loader.LoadViewModel(watchosView.Request, null /* no saved state on iOS currently */);
			if (viewModel == null)
				throw new MvxException("ViewModel not loaded for " + watchosView.Request.ViewModelType);
			return viewModel;
		}
	}
}

