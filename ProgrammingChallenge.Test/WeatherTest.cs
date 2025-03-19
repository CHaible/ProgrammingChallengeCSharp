using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingChallenge.Models;

namespace ProgrammingChallenge.Test
{
	
	public class WeatherTest
	{
		[Fact]
		public void WeatherPropertiesTest()
		{
			Weather w1 = new Weather(1, 70, 80);

			Assert.Equal(1, w1.Day);
			Assert.Equal(70, w1.MinTemp);
			Assert.Equal(80, w1.MaxTemp);
			Assert.Throws<ArgumentOutOfRangeException>(() => new Weather(-3, 70, 80));
			Assert.Throws<ArgumentException>(() => new Weather(4, 80, 50));
		}

		[Fact]
		public void CalculateTempSpreadTest()
		{
			Weather w1 = new Weather(1, 70, 80);
			Weather w3 = new Weather(1, 70, 70);

			Assert.Equal(10, w1.CalculateTemperatureSpread());
			Assert.Throws<ArgumentException>(() => new Weather(2, 80, 70));
			Assert.Equal(0, w3.CalculateTemperatureSpread());
		}
	}
}
