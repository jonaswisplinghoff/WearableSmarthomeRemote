namespace MvvmCross.watchOS.Views
{
	using System;
	using System.Reflection;

	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform.Exceptions;

	public class MvxWatchOSViewsContainer
		: MvxViewsContainer
		, IMvxWatchOSViewsContainer
	{
		public MvxViewModelRequest CurrentRequest { get; private set; }

		public virtual Type GetViewTypeFromViewModelRequest(MvxViewModelRequest request)
		{
			this.CurrentRequest = request;
			return this.GetViewType(request.ViewModelType);
		}
	}
}