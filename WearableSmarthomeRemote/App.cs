using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace WearableSmarthomeRemote.Core
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterType<IOpenHab,OpenHab>();
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<HueRemoteViewModel>());
		}
	}
}

