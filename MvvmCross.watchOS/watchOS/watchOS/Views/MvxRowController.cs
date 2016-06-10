namespace MvvmCross.watchOS.Views
{
	using Foundation;
	using MvvmCross.Binding.BindingContext;
	using MvvmCross.Core.ViewModels;

	public abstract class MvxRowController : NSObject, IMvxWatchOSView
	{
		public MvxRowController()
		{
			this.BindingContext = new MvxBindingContext();
		}

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

		public abstract void SetupBindingWithViewModel(MvxViewModel viewModel);
	}
}

