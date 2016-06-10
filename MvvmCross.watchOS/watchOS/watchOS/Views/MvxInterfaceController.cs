namespace MvvmCross.watchOS.Views
{
	using System;
	using Foundation;

	using MvvmCross.Binding.BindingContext;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Platform.watchOS.Views;

	public class MvxInterfaceController
		: MvxEventSourceInterfaceController
		  , IMvxWatchOSView
	{
		public MvxInterfaceController()
		{
			//this.AdaptForBinding();
		}

		public MvxInterfaceController(IntPtr handle)
			: base(handle)
		{
			//this.AdaptForBinding();
		}

		protected MvxInterfaceController(NSObjectFlag flag)
			: base(flag)
		{
			//this.AdaptForBinding();
		}

		public object DataContext
		{
			get { return this.BindingContext.DataContext; }
			set { this.BindingContext.DataContext = value; }
		}

		public IMvxViewModel ViewModel
		{
			get { return this.DataContext as IMvxViewModel; }
			set { this.DataContext = value; }
		}

		public MvxViewModelRequest Request { get; set; }

		public IMvxBindingContext BindingContext { get; set; }
	}

	public class MvxInterfaceController<TViewModel>
		: MvxInterfaceController
		  , IMvxWatchOSView<TViewModel> where TViewModel : class, IMvxViewModel
	{
		public MvxInterfaceController()
		{
		}

		public MvxInterfaceController(IntPtr handle)
			: base(handle)
		{
		}

		protected MvxInterfaceController(NSObjectFlag flag)
			: base(flag)
		{
		}

		public new TViewModel ViewModel
		{
			get { return (TViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}
	}
}

