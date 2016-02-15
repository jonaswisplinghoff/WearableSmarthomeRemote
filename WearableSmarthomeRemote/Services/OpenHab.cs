using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace WearableSmarthomeRemote.Core
{
	public class OpenHab : IOpenHab
	{

		public OpenHab()
		{
		}

		async public Task<Item[]> GetItems()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://192.168.128.102:8080/");
			try
			{
				var response = await client.GetAsync("rest/items");
				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine("Success");
					var content = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<Item[]>(content);
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

			return new Item[0];
		}

		async public Task<string> GetLampState(int lampId)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://192.168.128.102:8080/");
			try
			{
				var response = await client.GetAsync("rest/items/Toggle_" + lampId + "/state");
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

		async public void SetLampState(int lampId, bool state)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("http://192.168.128.102:8080/");
			try
			{
				StringContent content = state ? new StringContent("ON") : new StringContent("OFF");
				var response = await client.PutAsync("rest/items/Toggle_" + lampId + "/state", content);
				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine("Success");
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
		}
	}
}