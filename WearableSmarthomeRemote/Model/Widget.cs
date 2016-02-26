using System;
using System.Collections.Generic;

namespace WearableSmarthomeRemote.Core
{
	public class Widget
	{
		public string widgetId { get; set; }
		public string type { get; set; }
		public string label { get; set; }
		public string icon { get; set; }
		public List<object> mappings { get; set; }
		public Item item { get; set; }
		public List<Widget> widgets { get; set; }
	}
}
