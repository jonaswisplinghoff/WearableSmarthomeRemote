using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.UI.iOS
{
	public partial class ItemCellView : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("ItemCellView");
		public static readonly UINib Nib;

		static ItemCellView()
		{
			Nib = UINib.FromName("ItemCellView", NSBundle.MainBundle);
		}

		protected ItemCellView(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<ItemCellView, Item>();
				set.Bind(NameLabel).To(item => item.name);
				set.Bind(StateLabel).To(item => item.state);
				set.Apply();
			});
		}
	}
}
