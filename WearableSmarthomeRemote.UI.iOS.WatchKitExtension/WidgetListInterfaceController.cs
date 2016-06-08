using System;
using WatchKit;
using UIKit;
using Foundation;
using WearableSmarthomeRemote.Core;
using System.Collections.Generic;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.watchOS;
using MvvmCross.Binding.BindingContext;
using System.Diagnostics;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class WidgetListInterfaceController : MvxInterfaceController<WidgetListViewModel>
	{
		public WidgetListInterfaceController()
		{
			this.AdaptForBinding();
		}

		public WidgetListInterfaceController(IntPtr handle) : base(handle)
		{
		}

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context: {1}", this, context);

			var set = this.CreateBindingSet<WidgetListInterfaceController, WidgetListViewModel>();
			set.Bind(this.WidgetList).For("WidgetList").To(vm => vm.Widgets);
			set.Bind(this.TableCellPressed).To(vm => vm.WidgetSelectedCommand);
			set.Apply();
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
}


