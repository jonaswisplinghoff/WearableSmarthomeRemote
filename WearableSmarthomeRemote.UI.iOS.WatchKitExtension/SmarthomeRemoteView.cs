using System;

using WatchKit;
using Foundation;
using WearableSmarthomeRemote.WatchCore;
using MvvmCross.watchOS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using System.Diagnostics;
using MvvmCross.watchOS.Views;
using MvvmCross.watchOS.Platform;

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
			}
			this.Request = new MvxViewModelRequest<SmarthomeRemoteViewModel>(new MvxBundle(null), null, MvxRequestedBy.Unknown);
			this.AdaptForBinding();
		}

		public override void Awake(NSObject context)
		{
			base.Awake(context);

			// Configure interface objects here.
			Console.WriteLine("{0} awake with context", this);

			this.CreateBinding(HeadingLabel).To((SmarthomeRemoteViewModel vm) => vm.Heading).Apply();
			this.CreateBinding(this).For(v => v.ShowAllButtonPressed).To((SmarthomeRemoteViewModel vm) => vm.NextPageCommand).Apply();

			var set = this.CreateBindingSet<SmarthomeRemoteView, SmarthomeRemoteViewModel>();
			//set.Bind(HeadingLabel).To(vm => vm.Heading);
			//set.Bind(this).For(v => v.ShowAllButtonPressed).To(vm => vm.NextPageCommand);
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
	}

	public class TableCellPressedEventArgs : EventArgs
	{
		public WidgetCellViewModel Widget { get; set; }
	}
}

