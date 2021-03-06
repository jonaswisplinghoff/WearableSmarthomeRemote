﻿using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using WearableSmarthomeRemote.WatchCore;

namespace WearableSmarthomeRemote.UI.DroidWear
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext)
			: base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}
	}
}