using WatchKit;
namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	using System;
	using System.Windows.Input;
	using MvvmCross.Binding;
	using MvvmCross.Binding.Bindings.Target;
	using MvvmCross.Platform.Platform;
	using MvvmCross.Platform.WeakSubscription;

	using UIKit;

	public class MvxWKInterfaceControllerMethodTargetBinding : MvxConvertingTargetBinding
	{
		private ICommand _command;
		private IDisposable _canExecuteSubscription;
		private readonly EventHandler<EventArgs> _canExecuteEventHandler;

		protected SmarthomeRemoteView Controller => base.Target as SmarthomeRemoteView;

		public MvxWKInterfaceControllerMethodTargetBinding(SmarthomeRemoteView controller)
			: base(controller)
		{
			if (controller == null)
			{
				MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - WKInterfaceController is null in MvxWKInterfaceControllerMethodTargetBinding");
			}
			else
			{
				controller.ShowAllButtonPressedEvent += this.EventFired;
			}

			this._canExecuteEventHandler = new EventHandler<EventArgs>(this.OnCanExecuteChanged);
		}

		private void EventFired(object sender, EventArgs eventArgs)
		{
			if (this._command == null)
				return;

			if (!this._command.CanExecute(null))
				return;

			this._command.Execute(null);
		}

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

		public override System.Type TargetType => typeof(ICommand);

		protected override void SetValueImpl(object target, object value)
		{
			if (this._canExecuteSubscription != null)
			{
				this._canExecuteSubscription.Dispose();
				this._canExecuteSubscription = null;
			}
			this._command = value as ICommand;
			if (this._command != null)
			{
				this._canExecuteSubscription = this._command.WeakSubscribe(this._canExecuteEventHandler);
			}
			this.RefreshEnabledState();
		}

		private void RefreshEnabledState()
		{
			var view = this.Controller;
			if (view == null)
				return;

			var shouldBeEnabled = false;
			if (this._command != null)
			{
				shouldBeEnabled = this._command.CanExecute(null);
			}
			//view.Enabled = shouldBeEnabled;
		}

		private void OnCanExecuteChanged(object sender, EventArgs e)
		{
			this.RefreshEnabledState();
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				var view = this.Controller;
				if (view != null)
				{
					view.ShowAllButtonPressedEvent -= this.EventFired;
				}
				if (this._canExecuteSubscription != null)
				{
					this._canExecuteSubscription.Dispose();
					this._canExecuteSubscription = null;
				}
			}
			base.Dispose(isDisposing);
		}
	}
}
