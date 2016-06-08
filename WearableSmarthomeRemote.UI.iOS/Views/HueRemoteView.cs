using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using WearableSmarthomeRemote.MobileCore;
using MvvmCross.Binding.iOS.Views;
using WearableSmarthomeRemote.Core;
using System.Collections.Generic;

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

			//var Source = new MvxSimpleTableViewSource(ItemList, SwitchItemCellView.Key, SwitchItemCellView.Key);
			var Source = new TableSource(ItemList);
			ItemList.Source = Source;

			this.AddBindings(new Dictionary<object, string>
			{
				{Source, "ItemsSource Items"}
			});

			ItemList.ReloadData();
		}
	}
}