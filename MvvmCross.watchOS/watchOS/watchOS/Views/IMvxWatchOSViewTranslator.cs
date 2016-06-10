namespace MvvmCross.watchOS.Views
{
	using System;
	using MvvmCross.Core.ViewModels;

	public interface IMvxWatchOSViewTranslator : IMvxCurrentRequest
	{
		Type GetViewTypeFromViewModelRequest(MvxViewModelRequest request);
	}
}