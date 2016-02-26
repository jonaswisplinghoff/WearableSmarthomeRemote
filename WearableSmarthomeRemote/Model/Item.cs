using System;
using System.Collections.Generic;

namespace WearableSmarthomeRemote.Core
{
	public class Item
	{
		public string link { get; set; }
		public string state { get; set; }
		public string type { get; set; }
		public string name { get; set; }
		public string label { get; set; }
		public List<string> tags { get; set; }
		public List<string> groupNames { get; set; }
	}
}