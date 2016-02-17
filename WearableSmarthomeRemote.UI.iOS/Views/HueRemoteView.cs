using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.UI.iOS
{
	public partial class HueRemoteView : MvxViewController<HueRemoteViewModel>
	{
		public HueRemoteView() : base("HueRemoteView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			//this.CreateBinding(StateLabel).To((HueRemoteViewModel vm) => vm.LampState).Apply();
			this.CreateBinding(RefreshButton).To((HueRemoteViewModel vm) => vm.UpdateCommand).Apply();

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


