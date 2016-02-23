using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using WearableSmarthomeRemote.MobileCore;
using MvvmCross.Platform.Core;

namespace WearableSmarthomeRemote.UI.iOS
{
	public partial class ColorItemCellView : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString("ColorItemCellView");
		public static readonly UINib Nib;

		static ColorItemCellView()
		{
			Nib = UINib.FromName("ColorItemCellView", NSBundle.MainBundle);
		}

		protected ColorItemCellView(IntPtr handle) : base(handle)
		{
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<ColorItemCellView, ColorItemCellViewModel>();
				set.Bind(NameLabel).To(item => item.ItemName);
				set.Bind(StateLabel).To(item => item.State);
				set.Bind(ColorView).For(v => v.BackgroundColor).To(item => item.Color).WithConversion("NativeColor");
				set.Apply();
			});
		}
	}
}
