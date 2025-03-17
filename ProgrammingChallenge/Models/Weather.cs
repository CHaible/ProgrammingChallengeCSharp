using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ProgrammingChallenge.Models
{
	public class Weather
	{
		private int day;
		private int? maxTemp = null;
		private int? minTemp = null;

		/// <summary>
		/// COnstructor for instantiating new weather-objects with the three known values
		/// </summary>
		/// <param name="day">Day of month</param>
		/// <param name="minTemp">Lowest temperature on this day</param>
		/// <param name="maxTemp">Highest temperature on this day</param>
		public Weather(int day, int minTemp, int maxTemp)
		{
			this.day = day;
			this.minTemp = minTemp;
			this.maxTemp = maxTemp;
		}

		public Weather()
		{
			this.day = int.MaxValue;
		}

		public int getDay()
		{
			return day;
		}

		public int? getMinTemp()
		{
			return minTemp;
		}
		
		public int? getMaxTemp()
		{
			return maxTemp;
		}

		public int? getTemperatureSpread()
		{
			return maxTemp - minTemp;
		}
	}
}
