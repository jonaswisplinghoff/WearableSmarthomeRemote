
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.WearDroid
{
	[Activity(Label = "OverviewView")]
	public class OverviewView : MvxActivity
	{
		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.View_Overview);

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
				if (item is StateItemCellViewModel)
					return 0;
				return 1;
			}

			public override int ViewTypeCount
			{
				get { return 3; }
			}

			protected override View GetBindableView(View convertView, object source, int templateId)
			{
				if (source is ColorItemCellViewModel)
					templateId = Resource.Layout.ListItem_Color;
				else if (source is StateItemCellViewModel)
					templateId = Resource.Layout.ListItem_State;
				else if (source is SwitchItemCellViewModel)
					templateId = Resource.Layout.ListItem_Switch;

				return base.GetBindableView(convertView, source, templateId);
			}
		}

	}
}

