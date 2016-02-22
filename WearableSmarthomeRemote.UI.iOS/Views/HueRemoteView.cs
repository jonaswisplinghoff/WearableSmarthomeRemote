using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using WearableSmarthomeRemote.MobileCore;
using MvvmCross.Binding.iOS.Views;
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
			this.CreateBinding(RefreshButton).To((HueRemoteViewModel vm) => vm.UpdateCommand).Apply();
			this.CreateBinding(Switch1).To((HueRemoteViewModel vm) => vm.Lamp1On).Apply();
			this.CreateBinding(Switch2).To((HueRemoteViewModel vm) => vm.Lamp2On).Apply();
			this.CreateBinding(Switch3).To((HueRemoteViewModel vm) => vm.Lamp3On).Apply();

			var Source = new MvxSimpleTableViewSource(ItemList, ItemCellView.Key, ItemCellView.Key);
			ItemList.Source = Source;

			var set = this.CreateBindingSet<HueRemoteView, HueRemoteViewModel>();
			set.Bind(Source).To((HueRemoteViewModel vm) => vm.Items);
			set.Apply();

			ItemList.ReloadData();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}