using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.watchOS;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.Binding.Bindings.Target.Construction;
using WatchKit;
using System.Runtime.Remoting.Messaging;
using MvvmCross.watchOS.Binding;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public class Setup : MvxWatchOSSetup
	{
		public Setup(MvxInterfaceController controller, MvxWatchOSViewPresenter presenter)
			: base(controller, presenter)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void FillTargetFactories(MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
		{
			registry.RegisterCustomBindingFactory<WKInterfaceLabel>("HeadingLabel", label => new MvxWKInterfaceLabelTargetBinding(label));
			base.FillTargetFactories(registry);
		}
	}
}

