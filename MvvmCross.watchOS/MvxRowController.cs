using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;

namespace MvvmCross.watchOS
{
	public abstract class MvxRowController : NSObject, IMvxWatchOSView
	{
		public MvxViewModelRequest Request { get; set; }

		public IMvxBindingContext BindingContext { get; set; }

		public IMvxViewModel ViewModel
		{
			get { return this.DataContext as IMvxViewModel; }
			set { this.DataContext = value; }
		}

		public object DataContext
		{
			get { return this.BindingContext.DataContext; }
			set { this.BindingContext.DataContext = value; }
		}

		public abstract void SetupBinding();
	}
}

