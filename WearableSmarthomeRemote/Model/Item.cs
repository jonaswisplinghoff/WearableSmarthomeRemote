using System;
using System.Collections.Generic;

namespace WearableSmarthomeRemote.Core
{
	public class Item
	{
		public string Link { get; set; }
		public string State { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public string Label { get; set; }
		public List<string> Tags { get; set; }
		public List<string> GroupNames { get; set; }
	}
}