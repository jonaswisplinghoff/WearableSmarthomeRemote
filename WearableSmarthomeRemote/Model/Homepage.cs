using System;
using System.Collections.Generic;

namespace WearableSmarthomeRemote.Core
{
	public class Homepage
	{
		public string id { get; set; }
		public string title { get; set; }
		public string link { get; set; }
		public bool leaf { get; set; }
		public List<Widget> widgets { get; set; }
	}
}

