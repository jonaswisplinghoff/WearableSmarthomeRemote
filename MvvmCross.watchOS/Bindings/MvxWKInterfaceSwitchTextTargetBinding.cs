using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Platform.Platform;
using WatchKit;
namespace MvvmCross.watchOS.Binding
{
	public class MvxWKInterfaceSwitchTextTargetBinding : MvxTargetBinding
	{
		public MvxWKInterfaceSwitchTextTargetBinding(WKInterfaceSwitch target)
			: base(target)
		{
			MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - WKInterfaceSwitch is null in MvxWKInterfaceSwitchTextTargetBinding");
		}

		public override void SetValue(object value)
		{
			var target = Target as WKInterfaceSwitch;
			if (target == null)
				return;
			target.SetTitle((string)value);
		}

		public override Type TargetType => typeof(string);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
	}
}

