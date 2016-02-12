using System;
using System.Threading.Tasks;

namespace WearableSmarthomeRemote.Core
{
	public interface IOpenHab
	{
		Task<string> GetLampState();
	}
}

