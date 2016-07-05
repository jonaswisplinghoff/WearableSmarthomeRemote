using System;
using System.Collections.Generic;

namespace WearableSmarthomeRemote.Core
{
	public class Homepage
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Link { get; set; }
		public bool Leaf { get; set; }
		public List<Widget> Widgets { get; set; }
	}
}

