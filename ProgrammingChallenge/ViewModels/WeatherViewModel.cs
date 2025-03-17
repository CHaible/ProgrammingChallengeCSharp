using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProgrammingChallenge.Models;

namespace ProgrammingChallenge.ViewModels
{
	public class WeatherViewModel
	{
		public int Day { get; set; }
		public int? MinTemp { get; set; }
		public int? MaxTemp { get; set; }
		public int? TempSpread { get; set; }

		public WeatherViewModel(Weather weather)
		{
			Day = weather.getDay();
			TempSpread = weather.getTemperatureSpread();
			MinTemp = weather.getMinTemp();
			MaxTemp = weather.getMaxTemp();
		}
	}
}
