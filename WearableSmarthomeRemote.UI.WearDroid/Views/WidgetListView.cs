﻿using Android.App;
using MvvmCross.Droid.Views;

namespace WearableSmarthomeRemote.UI.WearDroid
{
	[Activity(Label = "WidgetListView")]
	public class WidgetListView : MvxActivity
	{
		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.View_WidgetList);
		}
	}
}

