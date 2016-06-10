namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	using System;
	using System.Diagnostics;
	using Foundation;
	using MvvmCross.Binding.BindingContext;
	using MvvmCross.watchOS.Views;
	using WatchKit;
	using WearableSmarthomeRemote.WatchCore;

	public partial class WidgetListView : MvxInterfaceController<WidgetListViewModel>
	{
		public WidgetListView()
		{
			this.AdaptForBinding();
		}

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context: {1}", this, context);

			var set = this.CreateBindingSet<WidgetListView, WidgetListViewModel>();
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
	}
}