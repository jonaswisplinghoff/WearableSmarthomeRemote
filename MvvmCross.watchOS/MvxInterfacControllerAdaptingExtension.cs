namespace MvvmCross.watchOS
{
	using System;
	using MvvmCross.Platform.iOS.Views;

	public static class MvxInterfaceControllerAdaptingExtensions
	{
		public static void AdaptForBinding(this IMvxEventSourceInterfaceController view)
		{
			var adapter = new MvxInterfaceControllerAdapter(view);
			var binding = new MvxBindingInterfaceControllerAdapter(view);
		}
	}
}

