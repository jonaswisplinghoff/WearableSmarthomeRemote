using System;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WearableSmarthomeRemote.Core
{
	public class OpenHab : IOpenHab
	{

		public OpenHab()
		{
		}

		async public Task<string> GetLampState()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://192.168.128.102:8080/");
			try
			{
				var response = await client.GetAsync("rest/items/Toggle_1/state");
				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine("Success");
					return await response.Content.ReadAsStringAsync();
				}
				else 
				{
					Debug.WriteLine(response.RequestMessage);
					Debug.WriteLine(response.StatusCode);
				}
			}
			catch (HttpRequestException e)
			{
				Debug.WriteLine(e.Message);
				Debug.WriteLine(e.StackTrace);
				Debug.WriteLine(e.InnerException.Message);
				Debug.WriteLine(e.InnerException.StackTrace);
			}

			return "OFF";
		}

	}
}