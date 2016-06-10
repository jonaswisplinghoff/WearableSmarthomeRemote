namespace MvvmCross.watchOS.Views
{
	using System.Collections.Generic;

	using MvvmCross.Core.Platform;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Platform;

	public static class MvxCanCreateWatchOSViewExtensionMethods
	{
		public static IMvxWatchOSView CreateViewControllerFor<TTargetViewModel>(this IMvxCanCreateWatchOSView view,
																			  object parameterObject)
			where TTargetViewModel : class, IMvxViewModel
		{
			return
				view.CreateViewControllerFor<TTargetViewModel>(parameterObject?.ToSimplePropertyDictionary());
		}

#warning TODO - could this move down to IMvxView level?

		public static IMvxWatchOSView CreateViewControllerFor<TTargetViewModel>(
			this IMvxCanCreateWatchOSView view,
			IDictionary<string, string> parameterValues = null)
			where TTargetViewModel : class, IMvxViewModel
		{
			var parameterBundle = new MvxBundle(parameterValues);
			var request = new MvxViewModelRequest<TTargetViewModel>(parameterBundle, null,
																	MvxRequestedBy.UserAction);
			return view.CreateInterfaceControllerFor(request);
		}

		public static IMvxWatchOSView CreateViewControllerFor<TTargetViewModel>(
			this IMvxCanCreateWatchOSView view,
			MvxViewModelRequest request)
			where TTargetViewModel : class, IMvxViewModel
		{
			return Mvx.Resolve<IMvxWatchOSViewCreator>().CreateView(request);
		}

		public static IMvxWatchOSView CreateInterfaceControllerFor(
			this IMvxCanCreateWatchOSView view,
			MvxViewModelRequest request)
		{
			return Mvx.Resolve<IMvxWatchOSViewCreator>().CreateView(request);
		}

		public static IMvxWatchOSView CreateInterfaceControllerFor(
			this IMvxCanCreateWatchOSView view,
			IMvxViewModel viewModel)
		{
			return Mvx.Resolve<IMvxWatchOSViewCreator>().CreateView(viewModel);
		}
	}
}

