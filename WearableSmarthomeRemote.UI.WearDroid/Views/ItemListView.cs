using Android.App;
using Android.Content;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.WearDroid
{
	[Activity(Label = "ItemListView")]
	public class ItemListView : MvxActivity
	{
		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.View_ItemList);

			var list = FindViewById<MvxListView>(Resource.Id.ItemListView);
			list.Adapter = new CustomAdapter(this, (IMvxAndroidBindingContext)BindingContext);
		}

		public class CustomAdapter : MvxAdapter
		{
			public CustomAdapter(Context context, IMvxAndroidBindingContext bindingContext)
				: base(context, bindingContext)
			{
			}

			public override int GetItemViewType(int position)
			{
				var item = GetRawItem(position);
				if (item is StateCellViewModel)
					return 0;
				return 1;
			}

			public override int ViewTypeCount
			{
				get { return 3; }
			}

			protected override View GetBindableView(View convertView, object source, int templateId)
			{
				if (source is ColorCellViewModel)
					templateId = Resource.Layout.ListItem_Color;
				else if (source is StateCellViewModel)
					templateId = Resource.Layout.ListItem_State;
				else if (source is SwitchCellViewModel)
					templateId = Resource.Layout.ListItem_Switch;

				return base.GetBindableView(convertView, source, templateId);
			}
		}
	}
}

