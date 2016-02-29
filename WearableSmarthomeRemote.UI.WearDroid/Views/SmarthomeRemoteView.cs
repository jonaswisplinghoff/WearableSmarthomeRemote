﻿using Android.App;
using MvvmCross.Droid.Views;

namespace WearableSmarthomeRemote.UI.WearDroid
{
	[Activity(Label = "SmarthomeRemoteView", MainLauncher = true)]
	public class SmarthomeRemoteView : MvxActivity
	{
		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.View_SmarthomeRemote);
		}
	}
}