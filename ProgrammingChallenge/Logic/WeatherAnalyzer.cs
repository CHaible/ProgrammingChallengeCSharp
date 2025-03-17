using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingChallenge.Models;
using ProgrammingChallenge.Resources;
using ProgrammingChallenge.ViewModels;

namespace ProgrammingChallenge.Logic
{
	public class WeatherAnalyzer
	{
		private List<Weather> _weatherList = new List<Weather>();
		private List<WeatherViewModel> _weatherViewModelList = new List<WeatherViewModel>();

		public List<Weather> WeatherList { get => _weatherList; }
		public List<WeatherViewModel> WeatherViewModelList { get => _weatherViewModelList; }
		
		public WeatherAnalyzer(List<Dictionary<string, string>> data)
		{
			foreach (Dictionary<string, string> day in data)
			{
				string dayValue = day.FirstOrDefault(x => x.Key == Resources.Resources.keyNameDay).Value;
				string minTempValue = day.FirstOrDefault(x => x.Key == Resources.Resources.keyNameMin).Value;
				string maxTempValue = day.FirstOrDefault(x => x.Key == Resources.Resources.keyNameMax).Value;

				Weather oneDay = new Weather(int.Parse(dayValue), int.Parse(minTempValue), int.Parse(maxTempValue));
				WeatherList.Add(oneDay);
				WeatherViewModelList.Add(new WeatherViewModel(oneDay));
			}
		}

		public WeatherViewModel GetMostUniformDay()
		{
			int? minSpread = int.MaxValue;
			WeatherViewModel mostUniformDay = new WeatherViewModel(new Weather());

			foreach (var weatherVM in WeatherViewModelList)
			{
				try
				{
					if (weatherVM.TempSpread < minSpread)
					{
						minSpread = weatherVM.TempSpread;
						mostUniformDay = weatherVM;
					}
				}
				catch
				{
					continue;
				}
			}
			return mostUniformDay;
		}
	}
}
