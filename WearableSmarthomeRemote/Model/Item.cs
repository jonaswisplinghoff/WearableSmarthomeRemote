using System;
namespace WearableSmarthomeRemote.Core
{
	public class Item
	{
		public string link { get; set; }
		public string state { get; set; }
		public string type { get; set; }
		public string name { get; set; }
		public string label { get; set; }
		public string[] tags { get; set; }
		public string[] groupNames { get; set; }

	}
}