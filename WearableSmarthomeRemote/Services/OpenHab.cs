using System;

namespace WearableSmarthomeRemote.Core
{
	public class OpenHab : IOpenHab
	{

		public OpenHab()
		{
		}


		public string GetLampState()
		{
			string url = "http://192.168.128.102:8080/rest/items/Toggle_1/state";

			return "OFF";
		}
	}
}