using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.watchOS;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.Binding.Bindings.Target.Construction;
using WatchKit;
using System.Runtime.Remoting.Messaging;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public class Setup : MvxWatchOSSetup
	{
		public Setup(MvxInterfaceController controller)
			: base(controller)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void FillTargetFactories(MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
		{
			registry.RegisterCustomBindingFactory<WKInterfaceLabel>("HeadingLabel", label => new WKInterfaceLabelTargetBinding(label));
			base.FillTargetFactories(registry);
		}
	}
}

