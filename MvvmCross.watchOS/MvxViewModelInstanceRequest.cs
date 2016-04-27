﻿using System;
namespace MvvmCross.watchOS
{
	using MvvmCross.Core.ViewModels;

#warning Move to shared PCL code

	public class MvxViewModelInstanceRequest : MvxViewModelRequest
	{
		private readonly IMvxViewModel _viewModelInstance;

		public IMvxViewModel ViewModelInstance => this._viewModelInstance;

		public MvxViewModelInstanceRequest(IMvxViewModel viewModelInstance)
			: base(viewModelInstance.GetType(), null, null, MvxRequestedBy.Unknown)
		{
			this._viewModelInstance = viewModelInstance;
		}
	}
}

