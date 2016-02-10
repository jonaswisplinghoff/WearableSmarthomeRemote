using System;
using WearableSmarthomeRemote.Core;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;

namespace WearableSmarthomeRemote.UI.iOS
{
	public class Setup : MvxIosSetup
	{
		public Setup (MvxApplicationDelegate appDelegate, IMvxIosViewPresenter presenter)
			: base(appDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new App();
		}
	}
}

