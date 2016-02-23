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

			var Source = new MvxSimpleTableViewSource(ItemList, SwitchItemCellView.Key, SwitchItemCellView.Key);
			ItemList.Source = Source;
			ItemList.RowHeight = 60;
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