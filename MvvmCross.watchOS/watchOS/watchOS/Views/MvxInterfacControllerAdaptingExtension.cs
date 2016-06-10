namespace MvvmCross.watchOS.Views
{
	using MvvmCross.Platform.watchOS.Views;

	public static class MvxInterfaceControllerAdaptingExtensions
	{
		public static void AdaptForBinding(this IMvxEventSourceInterfaceController view)
		{
			var adapter = new MvxInterfaceControllerAdapter(view);
			var binding = new MvxBindingInterfaceControllerAdapter(view);
		}
	}
}

