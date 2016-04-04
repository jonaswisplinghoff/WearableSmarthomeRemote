﻿using System;

using WatchKit;
using Foundation;
using System.Diagnostics;
using System.Collections.Generic;

namespace WearableSmarthomeRemote.UI.iOS.WatchKitExtension
{
	public partial class InterfaceController : WKInterfaceController
	{
		public InterfaceController (IntPtr handle) : base (handle)
		{
		}

		public override void Awake (NSObject context)
		{
			base.Awake (context);

			// Configure interface objects here.
			Console.WriteLine ("{0} awake with context", this);
		}

		public override void WillActivate ()
		{
			// This method is called when the watch view controller is about to be visible to the user.
			Console.WriteLine ("{0} will activate", this);

			var rows = new List<string>();
			rows.Add ("asd");
			rows.Add ("dgh");
			rows.Add ("qwer");
			rows.Add ("dfjlgnü");

			tableView.SetNumberOfRows (rows.Count, "default");

			for (var i = 0; i < rows.Count; i++) {
				var elementRow = (RowController)tableView.GetRowController (i);
				elementRow.RowLabel.SetText (rows [i]);
			}
		}

		public override void DidDeactivate ()
		{
			// This method is called when the watch view controller is no longer visible to the user.
			Console.WriteLine ("{0} did deactivate", this);
		}

		int clickCount = 0;

		partial void OnButtonPress ()
		{
			var msg = String.Format("Clicked {0} times", ++clickCount);
			StatusLabel.SetText(msg);
		}
	}
}

