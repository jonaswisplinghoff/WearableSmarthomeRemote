﻿namespace MvvmCross.Binding.watchOS
{
	using System;
	using MvvmCross.Binding;
	using MvvmCross.Binding.Binders;
	using MvvmCross.Binding.BindingContext;
	using MvvmCross.Binding.Bindings.Target.Construction;
	using MvvmCross.Binding.watchOS.Target;
	using MvvmCross.Binding.watchOS.ValueConverters;
	using MvvmCross.Platform.Converters;
	using WatchKit;

	public class MvxWatchOSBindingBuilder
		: MvxBindingBuilder
	{
		private readonly Action<IMvxTargetBindingFactoryRegistry> _fillRegistryAction;
		private readonly Action<IMvxValueConverterRegistry> _fillValueConvertersAction;
		private readonly Action<IMvxAutoValueConverters> _fillAutoValueConvertersAction;
		private readonly Action<IMvxBindingNameRegistry> _fillBindingNamesAction;
		private readonly MvxUnifiedTypesValueConverter _unifiedValueTypesConverter;

		public MvxWatchOSBindingBuilder(Action<IMvxTargetBindingFactoryRegistry> fillRegistryAction = null,
									Action<IMvxValueConverterRegistry> fillValueConvertersAction = null,
									Action<IMvxAutoValueConverters> fillAutoValueConvertersAction = null,
									Action<IMvxBindingNameRegistry> fillBindingNamesAction = null)
		{
			this._fillRegistryAction = fillRegistryAction;
			this._fillValueConvertersAction = fillValueConvertersAction;
			this._fillAutoValueConvertersAction = fillAutoValueConvertersAction;
			this._fillBindingNamesAction = fillBindingNamesAction;

			this._unifiedValueTypesConverter = new MvxUnifiedTypesValueConverter();
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			base.FillTargetFactories(registry);

			registry.RegisterCustomBindingFactory<WKInterfaceLabel>("Text",
																	view => new MvxWKInterfaceLabelTextTargetBinding(view));
			registry.RegisterCustomBindingFactory<WKInterfaceSwitch>("Title",
																	 view => new MvxWKInterfaceSwitchTextTargetBinding(view));
			registry.RegisterCustomBindingFactory<WKInterfaceSwitch>("On",
																	 view => new MvxWKInterfaceSwitchValueTargetBinding(view));
			this._fillRegistryAction?.Invoke(registry);
		}

		protected override void FillValueConverters(IMvxValueConverterRegistry registry)
		{
			base.FillValueConverters(registry);

			this._fillValueConvertersAction?.Invoke(registry);
		}

		protected override void FillAutoValueConverters(IMvxAutoValueConverters autoValueConverters)
		{
			base.FillAutoValueConverters(autoValueConverters);

			//register converter for xamarin unified types
			foreach (var kvp in MvxUnifiedTypesValueConverter.UnifiedTypeConversions)
				autoValueConverters.Register(kvp.Key, kvp.Value, this._unifiedValueTypesConverter);

			this._fillAutoValueConvertersAction?.Invoke(autoValueConverters);
		}

		protected override void FillDefaultBindingNames(IMvxBindingNameRegistry registry)
		{
			base.FillDefaultBindingNames(registry);

			registry.AddOrOverwrite(typeof(WKInterfaceLabel), "Text");
			registry.AddOrOverwrite(typeof(WKInterfaceSwitch), "On");

			this._fillBindingNamesAction?.Invoke(registry);
		}
	}
}