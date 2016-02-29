using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using ModernHttpClient;
using System.Collections.Generic;

namespace WearableSmarthomeRemote.Core
{
	public class OpenHab : IOpenHab
	{
		//static string baseURL = "http://192.168.128.102:8080/";
		static string baseURL = "http://10.0.2.2:8080/";
		//static string baseURL = "http://127.0.0.1:8080/";

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
					//var spareResponse = "[{"link":"http://192.168.128.102:8080/rest/items/Temp","state":"4","stateDescription":{"pattern":"%.2f Â°C","readOnly":false,"options":[]},"type":"NumberItem","name":"Temp","label":"Temperature","category":"temperature","tags":[],"groupNames":[]},{"link":"http://192.168.128.102:8080/rest/items/Humid","state":"58","stateDescription":{"pattern":"%.2f","readOnly":false,"options":[]},"type":"NumberItem","name":"Humid","label":"Humidity","category":"humidity","tags":[],"groupNames":[]},{"link":"http://192.168.128.102:8080/rest/items/Toggle_1","state":"ON","type":"SwitchItem","name":"Toggle_1","tags":[],"groupNames":[]},{"link":"http://192.168.128.102:8080/rest/items/Toggle_2","state":"ON","type":"SwitchItem","name":"Toggle_2","tags":[],"groupNames":[]},{"link":"http://192.168.128.102:8080/rest/items/Toggle_3","state":"ON","type":"SwitchItem","name":"Toggle_3","tags":[],"groupNames":[]},{"link":"http://192.168.128.102:8080/rest/items/Color_1","state":"360,94,100","type":"ColorItem","name":"Color_1","tags":[],"groupNames":[]},{"link":"http://192.168.128.102:8080/rest/items/Color_2","state":"125,96,85","type":"ColorItem","name":"Color_2","tags":[],"groupNames":[]},{"link":"http://192.168.128.102:8080/rest/items/Color_3","state":"237,96,100","type":"ColorItem","name":"Color_3","tags":[],"groupNames":[]},{"members":[],"link":"http://192.168.128.102:8080/rest/items/hue_LCT001_a9ad83c1_1","state":"NULL","type":"GroupItem","name":"hue_LCT001_a9ad83c1_1","label":"Hue Lamp 1","tags":["thing"],"groupNames":[]},{"members":[],"link":"http://192.168.128.102:8080/rest/items/hue_LCT001_a9ad83c1_2","state":"NULL","type":"GroupItem","name":"hue_LCT001_a9ad83c1_2","label":"Hue Lamp 2","tags":["thing"],"groupNames":[]},{"members":[],"link":"http://192.168.128.102:8080/rest/items/hue_LCT001_a9ad83c1_4","state":"NULL","type":"GroupItem","name":"hue_LCT001_a9ad83c1_4","label":"Hue Lamp 3","tags":["thing"],"groupNames":[]},{"members":[],"link":"http://192.168.128.102:8080/rest/items/hue_bridge_a9ad83c1","state":"NULL","type":"GroupItem","name":"hue_bridge_a9ad83c1","label":"Hue Bridge","tags":["thing"],"groupNames":[]},{"members":[],"link":"http://192.168.128.102:8080/rest/items/yahooweather_weather_cc578ce2","state":"NULL","type":"GroupItem","name":"yahooweather_weather_cc578ce2","label":"Wetterinformation","tags":["thing"],"groupNames":[]}]"
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