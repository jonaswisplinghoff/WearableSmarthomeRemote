namespace MvvmCross.watchOS
{
	using MvvmCross.Core.ViewModels;
	using MvvmCross.Core.Views;
	using MvvmCross.Platform.Platform;

	using UIKit;

	public class MvxBaseWatchOSViewPresenter
		: MvxViewPresenter, IMvxWatchOSViewPresenter
	{
		public override void Show(MvxViewModelRequest request)
		{
		}

		public override void ChangePresentation(MvxPresentationHint hint)
		{
			if (this.HandlePresentationChange(hint)) return;

			MvxTrace.Warning("Hint ignored {0}", hint.GetType().Name);
		}

		public virtual bool PresentModalViewController(UIViewController viewController, bool animated)
		{
			return false;
		}

		public virtual void NativeModalViewControllerDisappearedOnItsOwn()
		{
		}
	}
}