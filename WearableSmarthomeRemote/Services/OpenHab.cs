using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using ModernHttpClient;

namespace WearableSmarthomeRemote.Core
{
	public class OpenHab : IOpenHab
	{
		static string baseURL = "http://192.168.128.102:8080/";
		HttpClient client;

		public OpenHab()
		{
			client = new HttpClient(new NativeMessageHandler());
			client.BaseAddress = new Uri(baseURL);
		}

		async public Task<Item[]> GetItems()
		{
			try
			{
				var response = await client.GetAsync("rest/items");
				if (response.IsSuccessStatusCode)
				{
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
			}
			catch (WebException e)
			{
				Debug.WriteLine(e.Message);
			}

			return new Item[0];
		}

		async public Task<Sitemap> GetSitemapWithName(string name = "default")
		{
			try
			{
				var response = await client.GetAsync("rest/sitemaps/" + name);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					//var spareResponse = "{"name":"default","label":"Main Menu","link":"http://192.168.128.102:8080/rest/sitemaps/default","homepage":{"id":"default","title":"Main Menu","link":"http://192.168.128.102:8080/rest/sitemaps/default/default","leaf":false,"widgets":[{"widgetId":"default_0","type":"Frame","label":"Weather","icon":"frame","mappings":[],"widgets":[{"widgetId":"default_0_0","type":"Text","label":"Temperature [3.00 °C]","icon":"temperature","mappings":[],"item":{"link":"http://192.168.128.102:8080/rest/items/Temp","state":"3","stateDescription":{"pattern":"%.2f °C","readOnly":false,"options":[]},"type":"NumberItem","name":"Temp","label":"Temperature","category":"temperature","tags":[],"groupNames":[]},"widgets":[]},{"widgetId":"default_0_0_1","type":"Text","label":"Humidity [66.00]","icon":"humidity","mappings":[],"item":{"link":"http://192.168.128.102:8080/rest/items/Humid","state":"66","stateDescription":{"pattern":"%.2f","readOnly":false,"options":[]},"type":"NumberItem","name":"Humid","label":"Humidity","category":"humidity","tags":[],"groupNames":[]},"widgets":[]}]},{"widgetId":"default_1","type":"Frame","label":"Hue 1","icon":"frame","mappings":[],"widgets":[{"widgetId":"default_1_0","type":"Switch","label":"Light 1","icon":"switch","mappings":[],"item":{"link":"http://192.168.128.102:8080/rest/items/Toggle_1","state":"ON","type":"SwitchItem","name":"Toggle_1","tags":[],"groupNames":[]},"widgets":[]},{"widgetId":"default_1_0_1","type":"Colorpicker","label":"Light 1 Light Color","icon":"colorpicker","mappings":[],"item":{"link":"http://192.168.128.102:8080/rest/items/Color_1","state":"360,94,100","type":"ColorItem","name":"Color_1","tags":[],"groupNames":[]},"widgets":[]}]},{"widgetId":"default_2","type":"Frame","label":"Hue 2","icon":"frame","mappings":[],"widgets":[{"widgetId":"default_2_0","type":"Switch","label":"Light 2","icon":"switch","mappings":[],"item":{"link":"http://192.168.128.102:8080/rest/items/Toggle_2","state":"ON","type":"SwitchItem","name":"Toggle_2","tags":[],"groupNames":[]},"widgets":[]},{"widgetId":"default_2_0_1","type":"Colorpicker","label":"Light 2 Light Color","icon":"colorpicker","mappings":[],"item":{"link":"http://192.168.128.102:8080/rest/items/Color_2","state":"125,96,85","type":"ColorItem","name":"Color_2","tags":[],"groupNames":[]},"widgets":[]}]},{"widgetId":"default_3","type":"Frame","label":"Hue 3","icon":"frame","mappings":[],"widgets":[{"widgetId":"default_3_0","type":"Switch","label":"Light 3","icon":"switch","mappings":[],"item":{"link":"http://192.168.128.102:8080/rest/items/Toggle_3","state":"ON","type":"SwitchItem","name":"Toggle_3","tags":[],"groupNames":[]},"widgets":[]},{"widgetId":"default_3_0_1","type":"Colorpicker","label":"Light 3 Light Color","icon":"colorpicker","mappings":[],"item":{"link":"http://192.168.128.102:8080/rest/items/Color_3","state":"237,96,100","type":"ColorItem","name":"Color_3","tags":[],"groupNames":[]},"widgets":[]}]}]}}"
					return JsonConvert.DeserializeObject<Sitemap>(content);
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
			}
			catch (WebException e)
			{
				Debug.WriteLine(e.Message);
			}

			return new Sitemap();
		}

		async public void SetSwitchState(string switchName, bool state)
		{
			try
			{
				StringContent content = state ? new StringContent("ON") : new StringContent("OFF");
				var response = await client.PutAsync("rest/items/" + switchName + "/state", content);
				if (!response.IsSuccessStatusCode)
				{
					Debug.WriteLine(response.RequestMessage);
					Debug.WriteLine(response.StatusCode);
				}
			}
			catch (HttpRequestException e)
			{
				Debug.WriteLine(e.Message);
			}
			catch (WebException e)
			{
				Debug.WriteLine(e.Message);
			}
		}
	}
}