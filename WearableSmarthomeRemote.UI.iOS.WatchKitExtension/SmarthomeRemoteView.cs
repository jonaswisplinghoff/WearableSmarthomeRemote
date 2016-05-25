using System;

using WatchKit;
using Foundation;
using System.Collections.Generic;
using WearableSmarthomeRemote.Core;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.watchOS;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Core;
using System.Diagnostics;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class SmarthomeRemoteView : MvxInterfaceController<SmarthomeRemoteViewModel>
	{
		public SmarthomeRemoteView()
		{
			if (!MvxWatchOSSetup.IsInitialized())
			{
				var setup = new Setup(this);
				setup.Initialize();
				this.Request = new MvxViewModelRequest<SmarthomeRemoteViewModel>(new MvxBundle(null), null, MvxRequestedBy.Unknown);
			}
			this.AdaptForBinding();
		}

		public SmarthomeRemoteView(IntPtr handle) : base(handle)
		{
		}

		List<WidgetCellViewModel> Widgets = new List<WidgetCellViewModel>();

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context", this);

			var set = this.CreateBindingSet<SmarthomeRemoteView, SmarthomeRemoteViewModel>();
			set.Bind(HeadingLabel).For("LabelText").To(vm => vm.Heading);
			set.Bind(this).For(v => v.ShowAllButtonPressed).To(vm => vm.NextPageCommand);
			set.Bind(this.WidgetList).For("WidgetList").To(vm => vm.Widgets);
			set.Apply();
		}



		public event EventHandler ShowAllButtonPressed = delegate { };
		partial void OnShowAllButtonPressed()
		{
			ShowAllButtonPressed(this, new EventArgs());

		}

		public override void WillActivate()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine("{0} will activate", this);
		}

		public override NSObject GetContextForSegue(string segueIdentifier, WKInterfaceTable table, nint rowIndex)
		{
			if (segueIdentifier == "showWidgets")
			{
				var widget = ((WidgetCellViewModel)Widgets[(int)rowIndex]).Widget;
				return new NSString(widget.widgetId);
			}
			return null;
		}

		public override void DidDeactivate()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine("{0} did deactivate", this);
		}
	}
}

