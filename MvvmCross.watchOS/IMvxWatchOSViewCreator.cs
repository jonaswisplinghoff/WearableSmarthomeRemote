namespace MvvmCross.watchOS
{
	using MvvmCross.Core.ViewModels;

	public interface IMvxWatchOSViewCreator : IMvxCurrentRequest
	{
		IMvxWatchOSView CreateView(MvxViewModelRequest request);

		IMvxWatchOSView CreateView(IMvxViewModel viewModel);
	}
}