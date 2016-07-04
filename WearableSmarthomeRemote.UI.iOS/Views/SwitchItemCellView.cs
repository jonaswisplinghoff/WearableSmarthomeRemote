using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using WearableSmarthomeRemote.MobileCore;

namespace WearableSmarthomeRemote.UI.iOS
{
	public partial class SwitchItemCellView : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("SwitchItemCellView");
		public static readonly UINib Nib;

		static SwitchItemCellView()
		{
			Nib = UINib.FromName("SwitchItemCellView", NSBundle.MainBundle);
		}

		protected SwitchItemCellView(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<SwitchItemCellView, SwitchItemCellViewModel>();
				set.Bind(NameLabel).To(item => item.ItemName);
				set.Bind(StateLabel).To(item => item.State);
				set.Bind(SwitchItem).To(Item => Item.On);
				set.Apply();
			});
		}
	}
}
