using System;
namespace MvvmCross.watchOS
{
	using MvvmCross.Core.Views;

	public interface IMvxWatchOSViewsContainer
		: IMvxViewsContainer
		  , IMvxWatchOSViewCreator
	{ }
}

