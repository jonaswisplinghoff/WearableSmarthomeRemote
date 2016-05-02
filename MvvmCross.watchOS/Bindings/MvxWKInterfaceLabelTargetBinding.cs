using System;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using WatchKit;
namespace MvvmCross.watchOS.Binding
{
	public class MvxWKInterfaceLabelTargetBinding : MvxTargetBinding
	{

		public MvxWKInterfaceLabelTargetBinding(WKInterfaceLabel target)
			: base(target)
		{

		}

		public override void SetValue(object value)
		{
			var target = Target as WKInterfaceLabel;

			if (target == null)
				return;

			target.SetText((string)value);
		}

		public override Type TargetType
		{
			get
			{
				return typeof(string);
			}
		}

		public override MvxBindingMode DefaultMode
		{
			get
			{
				return MvxBindingMode.OneWay;
			}
		}
	}
}

