using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using WearableSmarthomeRemote.Core;

namespace WearableSmarthomeRemote.WatchCore
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterType<IOpenHab, OpenHab>();
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<SmarthomeRemoteViewModel>());
		}
	}
}