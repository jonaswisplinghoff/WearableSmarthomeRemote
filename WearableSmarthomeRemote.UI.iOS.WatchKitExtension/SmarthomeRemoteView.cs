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

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context", this);

			var set = this.CreateBindingSet<SmarthomeRemoteView, SmarthomeRemoteViewModel>();
			set.Bind(HeadingLabel).To(vm => vm.Heading);
			set.Bind(this).For(v => v.ShowAllButtonPressed).To(vm => vm.NextPageCommand);
			set.Bind(this.WidgetList).For("WidgetList").To(vm => vm.Widgets);
			set.Bind(this).For(v => v.TableCellPressed).To(vm => vm.WidgetSelectedCommand);
			set.Apply();
		}

		public event EventHandler ShowAllButtonPressed = delegate { };
		partial void OnShowAllButtonPressed()
		{
			ShowAllButtonPressed(this, new EventArgs());
		}

		public event EventHandler<TableCellPressedEventArgs> TableCellPressed = delegate { };
		public override void DidSelectRow(WKInterfaceTable table, nint rowIndex)
		{
			base.DidSelectRow(table, rowIndex);
			Debug.WriteLine(rowIndex);

			var args = new TableCellPressedEventArgs();
			args.Widget = this.ViewModel.Widgets[(int)rowIndex]; ;

			EventHandler<TableCellPressedEventArgs> handler = TableCellPressed;
			if (handler != null)
			{
				handler(this, args);
			}
		}

		public override void WillActivate()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine("{0} will activate", this);
		}

		public override void DidDeactivate()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine("{0} did deactivate", this);
		}
	}

	public class TableCellPressedEventArgs : EventArgs
	{
		public WidgetCellViewModel Widget { get; set; }
	}
}

