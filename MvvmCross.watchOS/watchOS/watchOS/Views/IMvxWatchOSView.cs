namespace MvvmCross.watchOS.Views
{
	using System;
	using MvvmCross.Binding.BindingContext;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;

	public interface IMvxWatchOSView
		: IMvxView
		, IMvxCanCreateWatchOSView
		, IMvxBindingContextOwner
	{
		MvxViewModelRequest Request { get; set; }
	}

	public interface IMvxWatchOSView<TViewModel>
		: IMvxWatchOSView
		, IMvxView<TViewModel> where TViewModel : class, IMvxViewModel
	{
	}
}

