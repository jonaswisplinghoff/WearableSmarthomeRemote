using System;
namespace MvvmCross.watchOS.Views
{
	using MvvmCross.Core.ViewModels;

	public interface IMvxCurrentRequest
	{
		MvxViewModelRequest CurrentRequest { get; }
	}
}

