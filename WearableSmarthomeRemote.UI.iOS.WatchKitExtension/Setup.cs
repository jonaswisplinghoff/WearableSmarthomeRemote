namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	using MvvmCross.Binding.Bindings.Target.Construction;
	using MvvmCross.Binding.watchOS.Target;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.watchOS.Platform;
	using MvvmCross.watchOS.Views;
	using WatchKit;
	using WearableSmarthomeRemote.WatchCore;

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

