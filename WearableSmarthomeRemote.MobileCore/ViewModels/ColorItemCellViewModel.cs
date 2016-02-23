using System;
using MvvmCross.Platform.UI;
using System.Runtime.InteropServices;
using System.ServiceModel.Channels;
namespace WearableSmarthomeRemote.MobileCore
{
	public class ColorItemCellViewModel : ItemCellViewModel
	{
		public ColorItemCellViewModel(string name, string state)
		{
			_itemName = name;
			_state = state;
			var colors = state.Replace(" ", "").Split(',');

			int h = 0;
			int s = 0;
			int v = 0;
			if (Int32.TryParse(colors[0], out h)
			   && Int32.TryParse(colors[1], out s)
			   && Int32.TryParse(colors[2], out v))
			{
				double hDouble = h;
				double sDouble = (double)s / 100;
				double vDouble = (double)v / 100;

				int r = 0;
				int g = 0;
				int b = 0;

				HsvToRgb(hDouble, sDouble, vDouble, out r, out g, out b);
				_color = new MvxColor(r, g, b);
			}
		}

		private string _itemName;
		public string ItemName
		{
			get { return _itemName; }
			set
			{
				_itemName = value;
				RaisePropertyChanged(() => ItemName);
			}
		}

		private string _state;
		public string State
		{
			get { return _state; }
			set
			{
				_state = value;
				RaisePropertyChanged(() => State);
			}
		}

		private MvxColor _color;
		public MvxColor Color
		{
			get { return _color; }
			set
			{
				_color = value;
				RaisePropertyChanged(() => Color);
			}
		}

		// Helper

		static void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
		{
			double H = h;
			while (H < 0) { H += 360; };
			while (H >= 360) { H -= 360; };
			double R, G, B;
			if (V <= 0)
			{ R = G = B = 0; }
			else if (S <= 0)
			{
				R = G = B = V;
			}
			else
			{
				double hf = H / 60.0;
				int i = (int)Math.Floor(hf);
				double f = hf - i;
				double pv = V * (1 - S);
				double qv = V * (1 - S * f);
				double tv = V * (1 - S * (1 - f));
				switch (i)
				{

					// Red is the dominant color

					case 0:
						R = V;
						G = tv;
						B = pv;
						break;

					// Green is the dominant color

					case 1:
						R = qv;
						G = V;
						B = pv;
						break;
					case 2:
						R = pv;
						G = V;
						B = tv;
						break;

					// Blue is the dominant color

					case 3:
						R = pv;
						G = qv;
						B = V;
						break;
					case 4:
						R = tv;
						G = pv;
						B = V;
						break;

					// Red is the dominant color

					case 5:
						R = V;
						G = pv;
						B = qv;
						break;

					// Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

					case 6:
						R = V;
						G = tv;
						B = pv;
						break;
					case -1:
						R = V;
						G = pv;
						B = qv;
						break;

					// The color is not defined, we should throw an error.

					default:
						//LFATAL("i Value error in Pixel conversion, Value is %d", i);
						R = G = B = V; // Just pretend its black/white
						break;
				}
			}
			r = Clamp((int)(R * 255.0));
			g = Clamp((int)(G * 255.0));
			b = Clamp((int)(B * 255.0));
		}

		/// <summary>
		/// Clamp a value to 0-255
		/// </summary>
		static int Clamp(int i)
		{
			if (i < 0) return 0;
			if (i > 255) return 255;
			return i;
		}
	}
}

