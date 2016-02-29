using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WearableSmarthomeRemote.Core
{
	public interface IOpenHab
	{
		void SetSwitchState(string switchName, bool state);
		Task<List<Item>> GetItems();
		Task<Sitemap> GetSitemapWithName(string name = "default");
		Task<Item> GetItemWithName(string _itemName);
	}
}

