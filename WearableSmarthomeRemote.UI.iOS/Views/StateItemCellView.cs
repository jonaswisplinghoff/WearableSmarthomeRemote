using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using WearableSmarthomeRemote.MobileCore;

namespace WearableSmarthomeRemote.UI.iOS
{
	public partial class StateItemCellView : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("StateItemCellView");
		public static readonly UINib Nib;

		static StateItemCellView()
		{
			Nib = UINib.FromName("StateItemCellView", NSBundle.MainBundle);
		}

		protected StateItemCellView(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<StateItemCellView, StateItemCellViewModel>();
				set.Bind(NameLabel).To(item => item.ItemName);
				set.Bind(StateLabel).To(item => item.State);
				set.Apply();
			});
		}
	}
}
