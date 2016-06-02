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
		public Setup(MvxInterfaceController controller)
			: base(controller)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			registry.RegisterCustomBindingFactory<WKInterfaceTable>("WidgetList",
																	list => new MvxWKInterfaceTableTargetBinding<WidgetCellViewModel>(list,
																																	  "WidgetItem"));
			base.FillTargetFactories(registry);
		}
	}
}

