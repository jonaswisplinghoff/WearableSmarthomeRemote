using System;
using System.Threading.Tasks;

namespace WearableSmarthomeRemote.Core
{
	public interface IOpenHab
	{
		void SetSwitchState(string switchName, bool state);
		Task<Item[]> GetItems();
		Task<Sitemap> GetSitemapWithName(string name = "default");

	}
}

