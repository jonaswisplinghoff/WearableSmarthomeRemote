using System;
namespace MvvmCross.watchOS
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;

	using MvvmCross.Binding;
	using MvvmCross.Binding.Binders;
	using MvvmCross.Binding.BindingContext;
	using MvvmCross.Binding.Bindings.Target.Construction;
	using MvvmCross.Binding.iOS;
	using MvvmCross.Core.Platform;
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform;
	using MvvmCross.Platform.Converters;
	using MvvmCross.Platform.Platform;
	using MvvmCross.Platform.Plugins;
	using MvvmCross.Platform.iOS.Platform;
	using MvvmCross.Platform.iOS.Views;
	using MvvmCross.iOS.Views;
	using MvvmCross.iOS.Views.Presenters;

	using UIKit;

	public abstract class MvxWatchOSSetup
		: MvxSetup
	{
		private MvxInterfaceController _controller;

		protected MvxWatchOSSetup(MvxInterfaceController controller)
		{
			this._controller = controller;
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new MvxDebugTrace();
		}

		protected override IMvxPluginManager CreatePluginManager()
		{
			var toReturn = new MvxLoaderPluginManager();
			var registry = new MvxLoaderPluginRegistry(".watchOS", toReturn.Finders);
			this.AddPluginsLoaders(registry);
			return toReturn;
		}

		protected virtual void AddPluginsLoaders(MvxLoaderPluginRegistry loaders)
		{
			// none added by default
		}

		protected sealed override IMvxViewsContainer CreateViewsContainer()
		{
			var container = this.CreateWatchOSViewsContainer();
			this.RegisterWatchOSViewCreator(container);
			return container;
		}

		protected virtual IMvxWatchOSViewsContainer CreateWatchOSViewsContainer()
		{
			return new MvxWatchOSViewsContainer();
		}

		protected virtual void RegisterWatchOSViewCreator(IMvxWatchOSViewsContainer container)
		{
			Mvx.RegisterSingleton<IMvxWatchOSViewCreator>(container);
			Mvx.RegisterSingleton<IMvxCurrentRequest>(container);
		}

		protected override IMvxViewDispatcher CreateViewDispatcher()
		{
			return new MvxWatchOSViewDispatcher(this.Presenter);
		}

		protected override void InitializePlatformServices()
		{
			this.RegisterPlatformProperties();
			// for now we continue to register the old style platform properties
			this.RegisterPresenter();
		}

		protected virtual void RegisterPlatformProperties()
		{
			Mvx.RegisterSingleton<IMvxWatchOSSystem>(this.CreateWatchOSSystemProperties());
		}

		protected virtual MvxWatchOSSystem CreateWatchOSSystemProperties()
		{
			return new MvxWatchOSSystem();
		}

		private IMvxWatchOSViewPresenter _presenter;
		protected IMvxWatchOSViewPresenter Presenter
		{
			get
			{
				this._presenter = this._presenter ?? this.CreatePresenter();
				return this._presenter;
			}
		}

		protected virtual IMvxWatchOSViewPresenter CreatePresenter()
		{
			return new MvxWatchOSViewPresenter(this._controller);
		}

		protected virtual void RegisterPresenter()
		{
			var presenter = this.Presenter;
			Mvx.RegisterSingleton(presenter);
			Mvx.RegisterSingleton<IMvxIosModalHost>(presenter);
		}

		protected override void InitializeLastChance()
		{
			this.InitializeBindingBuilder();
			base.InitializeLastChance();
		}

		protected virtual void InitializeBindingBuilder()
		{
			this.RegisterBindingBuilderCallbacks();
			var bindingBuilder = this.CreateBindingBuilder();
			bindingBuilder.DoRegistration();
		}

		protected virtual void RegisterBindingBuilderCallbacks()
		{
			Mvx.CallbackWhenRegistered<IMvxValueConverterRegistry>(this.FillValueConverters);
			Mvx.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(this.FillTargetFactories);
			Mvx.CallbackWhenRegistered<IMvxBindingNameRegistry>(this.FillBindingNames);
		}

		protected virtual MvxBindingBuilder CreateBindingBuilder()
		{
			var bindingBuilder = new MvxIosBindingBuilder();
			return bindingBuilder;
		}

		protected virtual void FillBindingNames(IMvxBindingNameRegistry obj)
		{
			// this base class does nothing
		}

		protected virtual void FillValueConverters(IMvxValueConverterRegistry registry)
		{
			registry.Fill(this.ValueConverterAssemblies);
			registry.Fill(this.ValueConverterHolders);
		}

		protected virtual List<Type> ValueConverterHolders => new List<Type>();

		protected virtual IEnumerable<Assembly> ValueConverterAssemblies
		{
			get
			{
				var toReturn = new List<Assembly>();
				toReturn.AddRange(this.GetViewModelAssemblies());
				toReturn.AddRange(this.GetViewAssemblies());
				return toReturn;
			}
		}

		protected virtual void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			// this base class does nothing
		}

		protected override IMvxNameMapping CreateViewToViewModelNaming()
		{
			return new MvxPostfixAwareViewToViewModelNameMapping("View", "ViewController");
		}
	}
}

