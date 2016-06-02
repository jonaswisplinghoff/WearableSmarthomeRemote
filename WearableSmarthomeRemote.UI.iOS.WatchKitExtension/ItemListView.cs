using System;
using WatchKit;
using UIKit;
using Foundation;
using WearableSmarthomeRemote.Core;
using System.Collections.Generic;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.watchOS;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class ItemListView : MvxInterfaceController<ItemListViewModel>
	{
		public ItemListView()
		{
			this.Request = new MvxViewModelRequest<ItemListViewModel>(new MvxBundle(null), null, MvxRequestedBy.Unknown);
			this.AdaptForBinding();
		}

		public ItemListView(IntPtr handle) : base(handle)
		{
		}

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context: {1}", this, context);

			var set = this.CreateBindingSet<ItemListView, ItemListViewModel>();
			set.Bind(this.ItemList).For("ItemList").To(vm => vm.Items);
			set.Apply();
		}

		public override void WillActivate()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine("{0} will activate", this);

		}

		public override void DidDeactivate()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine("{0} did deactivate", this);
		}
	}
}


