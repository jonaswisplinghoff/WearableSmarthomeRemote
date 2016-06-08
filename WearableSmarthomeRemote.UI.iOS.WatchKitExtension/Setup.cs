using MvvmCross.Core.ViewModels;
using MvvmCross.watchOS;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.Binding.Bindings.Target.Construction;
using WatchKit;
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
			registry.RegisterCustomBindingFactory<WKInterfaceTable>("WidgetList", list => new MvxWKInterfaceTableTargetBinding<WidgetCellViewModel>(list));
			registry.RegisterCustomBindingFactory<WKInterfaceTable>("ItemList", list => new MvxWKInterfaceTableTargetBinding<ItemCellViewModel>(list));

			base.FillTargetFactories(registry);
		}
	}
}

