using System;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using WearableSmarthomeRemote.Core;
using UIKit;

namespace WearableSmarthomeRemote.iOS
{
	public partial class HueRemoteView : MvxViewController<HueRemoteViewModel>
	{
		public new HueRemoteViewModel ViewModel 
		{ 
			get { return (HueRemoteViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public HueRemoteView() : base("HueRemoteView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			this.CreateBinding(LightSwitch).To((HueRemoteViewModel vm) => vm.LampOn).Apply();
			this.CreateBinding(UpdateButton).To((HueRemoteViewModel vm) => vm.UpdateCommand).Apply();

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

	}
}


