﻿namespace MvvmCross.Binding.watchOS.Target
{
	using System;
	using MvvmCross.Binding;
	using MvvmCross.Binding.Bindings.Target;
	using MvvmCross.Platform.Platform;
	using WatchKit;

	public class MvxWKInterfaceSwitchValueTargetBinding : MvxTargetBinding
	{
		public MvxWKInterfaceSwitchValueTargetBinding(WKInterfaceSwitch target)
			: base(target)
		{
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - WKInterfaceSwitch is null in MvxWKInterfaceSwitchTextTargetBinding");
			}
		}

		public override void SetValue(object value)
		{
			var target = Target as WKInterfaceSwitch;
			if (target == null)
				return;

			var on = (bool)value;
			target.SetOn(on);
		}

		public override Type TargetType => typeof(bool);

		public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
	}
}

