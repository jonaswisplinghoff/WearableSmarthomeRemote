using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;

namespace MvvmCross.watchOS
{
	public class MvxRowController : NSObject, IMvxBindable
	{
		public MvxRowController()
		{

		}

		public IMvxBindingContext BindingContext { get; set; }


		public object DataContext
		{
			get { return this.BindingContext.DataContext; }
			set { this.BindingContext.DataContext = value; }
		}
	}
}

