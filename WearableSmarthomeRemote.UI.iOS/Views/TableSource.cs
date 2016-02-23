using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using WearableSmarthomeRemote.MobileCore;
using MvvmCross.Binding.BindingContext;

namespace WearableSmarthomeRemote.UI.iOS
{
	public class TableSource : MvxTableViewSource
	{
		private static readonly NSString SwitchItemCellIdentifier = new NSString("SwitchItemCellView");
		private static readonly NSString StateItemCellIdentifier = new NSString("StateItemCellView");
		private static readonly NSString ColorItemCellIdentifier = new NSString("ColorItemCellView");
		public TableSource(UITableView tableView)
			: base(tableView)
		{
			tableView.RegisterNibForCellReuse(UINib.FromName("SwitchItemCellView", NSBundle.MainBundle), SwitchItemCellIdentifier);
			tableView.RegisterNibForCellReuse(UINib.FromName("StateItemCellView", NSBundle.MainBundle), StateItemCellIdentifier);
			tableView.RegisterNibForCellReuse(UINib.FromName("ColorItemCellView", NSBundle.MainBundle), ColorItemCellIdentifier);
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath,
															  object item)
		{
			NSString cellIdentifier;
			if (item is SwitchItemCellViewModel)
			{
				cellIdentifier = SwitchItemCellIdentifier;
			}
			else if (item is StateItemCellViewModel)
			{
				cellIdentifier = StateItemCellIdentifier;
			}
			else if (item is ColorItemCellViewModel)
			{
				cellIdentifier = ColorItemCellIdentifier;
			}
			else
			{
				throw new ArgumentException("Unknown type: " + item.GetType().Name);
			}

			return (UITableViewCell)TableView.DequeueReusableCell(cellIdentifier, indexPath);
		}
	}
}

