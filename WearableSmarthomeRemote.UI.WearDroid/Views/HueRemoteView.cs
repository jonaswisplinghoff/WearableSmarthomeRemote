﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MvvmCross.Droid.Views;

namespace WearableSmarthomeRemote.UI.WearDroid
{
	[Activity(Label = "HueRemoteView", MainLauncher = true)]
	public class HueRemoteView : MvxActivity
	{
		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.View_HueRemote);
		}
	}
}