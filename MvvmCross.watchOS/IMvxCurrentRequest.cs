using System;
namespace MvvmCross.watchOS
{
	using MvvmCross.Core.ViewModels;

	public interface IMvxCurrentRequest
	{
		MvxViewModelRequest CurrentRequest { get; }
	}
}

