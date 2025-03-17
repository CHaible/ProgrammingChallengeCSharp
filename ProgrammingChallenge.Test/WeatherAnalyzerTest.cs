using ProgrammingChallenge.Logic;
using ProgrammingChallenge.Models;
using ProgrammingChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingChallenge.Test
{
	public class WeatherAnalyzerTest
	{
		[Fact]
		public void ConstructorTest()
		{
			WeatherAnalyzer wAnalyzer = new WeatherAnalyzer(CreateTestData());

			Assert.Equal(3, wAnalyzer.WeatherList.Count);
			Assert.Equal(3, wAnalyzer.WeatherViewModelList.Count);
		}

		[Fact]
		public void GetMostUniformDayTest()
		{
			WeatherAnalyzer wAnalyzer = new WeatherAnalyzer(CreateTestData());
			WeatherViewModel weatherVM = wAnalyzer.GetMostUniformDay();

			Assert.Equal(1, weatherVM.Day);
			Assert.Equal(4, weatherVM.TempSpread);
		}

		private List<Dictionary<string, string>> CreateTestData()
		{
			List<Weather> weatherList = new List<Weather>
			{
				new Weather(1, 4, 8),
				new Weather(2, 20, 60),
				new Weather(3, 2, 75)
			};

			List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
			foreach (Weather weather in weatherList)
			{
				data.Add(WeatherToDict(weather));
			}
			return data;
		}

		private Dictionary<string, string> WeatherToDict(Weather weather)
		{
			return new Dictionary<string, string> {
				{ Resources.Resources.keyNameDay, weather.getDay().ToString() },
				{ Resources.Resources.keyNameMax, weather.getMaxTemp().ToString() ?? String.Empty },
				{ Resources.Resources.keyNameMin, weather.getMinTemp().ToString() ?? String.Empty }
			};
		}
	}
}
