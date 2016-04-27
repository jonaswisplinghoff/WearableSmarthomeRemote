using System;

using WatchKit;
using Foundation;
using MvvmCross.Platform;
using MvvmCross.watchOS;
using MvvmCross.Core.ViewModels;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class StartupInterfaceController : MvxInterfaceController
	{
		protected StartupInterfaceController(IntPtr handle) : base(handle)
		{
		}

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context", this);

			var setup = new Setup(this);
			setup.Initialize();

			var appStartViewModel = Mvx.Resolve<IMvxAppStart>();
			appStartViewModel.Start();
		}

		public override void WillActivate()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine("{0} will activate", this);
		}

		public override void DidDeactivate()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine("{0} did deactivate", this);
		}
	}
}

