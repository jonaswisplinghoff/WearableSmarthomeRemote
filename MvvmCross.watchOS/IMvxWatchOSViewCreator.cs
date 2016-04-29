namespace MvvmCross.watchOS
{
	using System;
	using MvvmCross.Core.ViewModels;

	public interface IMvxWatchOSViewCreator : IMvxCurrentRequest
	{
		IMvxWatchOSView CreateView(MvxViewModelRequest request);

		IMvxWatchOSView CreateView(IMvxViewModel viewModel);

		Type GetViewTypeFromViewModelRequest(MvxViewModelRequest request);
	}
}