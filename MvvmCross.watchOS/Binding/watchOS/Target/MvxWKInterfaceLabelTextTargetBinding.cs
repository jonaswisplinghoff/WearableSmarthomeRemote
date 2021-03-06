﻿namespace MvvmCross.Binding.watchOS.Target
{
	using System;
	using MvvmCross.Binding;
	using MvvmCross.Binding.Bindings.Target;
	using MvvmCross.Platform.Platform;
	using WatchKit;

	public class MvxWKInterfaceLabelTextTargetBinding : MvxTargetBinding
	{
		public MvxWKInterfaceLabelTextTargetBinding(WKInterfaceLabel target)
			: base(target)
		{
			if (target == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - WKInterfaceLabel is null in MvxWKInterfaceLabelTargetBinding");
			}
		}

		public override void SetValue(object value)
		{
			var target = Target as WKInterfaceLabel;
			if (target == null)
				return;
			target.SetText((string)value);
		}

		public override Type TargetType => typeof(string);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
	}
}

