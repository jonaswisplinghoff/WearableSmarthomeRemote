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

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	[MvxFromStoryboard]
	public partial class SmarthomeRemoteView : MvxInterfaceController<SmarthomeRemoteViewModel>
	{

		public SmarthomeRemoteView(IntPtr handle) : base(handle)
		{
		}

		List<WidgetCellViewModel> Widgets = new List<WidgetCellViewModel>();

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context", this);

			this.AdaptForBinding();

			//this.CreateBinding(HeadingLabel).To((SmarthomeRemoteViewModel vm) => vm.Heading).Apply();
			var set = this.CreateBindingSet<SmarthomeRemoteView, SmarthomeRemoteViewModel>();
			set.Bind(HeadingLabel).For("HeadingLabel").To(vm => vm.Heading);
			set.Apply();
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

