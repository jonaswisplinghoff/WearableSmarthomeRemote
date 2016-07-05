using System;
using System.Collections.Generic;

namespace WearableSmarthomeRemote.Core
{
	public class Widget
	{
		public string WidgetId { get; set; }
		public string Type { get; set; }
		public string Label { get; set; }
		public string Icon { get; set; }
		public List<object> Mappings { get; set; }
		public Item Item { get; set; }
		public List<Widget> Widgets { get; set; }
	}
}
