using System;
using Foundation;
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
	}
}


