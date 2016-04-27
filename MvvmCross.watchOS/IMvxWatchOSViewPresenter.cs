﻿namespace MvvmCross.watchOS
{
	using MvvmCross.Core.Views;
	using MvvmCross.Platform.iOS.Views;

	public interface IMvxWatchOSViewPresenter
		: IMvxViewPresenter
		, IMvxCanCreateWatchOSView
		, IMvxIosModalHost
	{
	}
}