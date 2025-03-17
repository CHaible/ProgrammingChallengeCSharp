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
		public void GetDayTest()
		{
			Weather w0 = new Weather();
			Weather w1 = new Weather(1, 70, 80);
			Weather w2 = new Weather(-3, 70, 70);

			Assert.Equal(int.MaxValue, w0.getDay());
			Assert.Equal(1, w1.getDay());
			Assert.Equal(-3, w2.getDay());
		}

		[Fact]
		public void GetMaxTempTest()
		{
			Weather w0 = new Weather();
			Weather w1 = new Weather(1, 70, 80);

			Assert.Null(w0.getMaxTemp());
			Assert.Equal(80, w1.getMaxTemp());
		}

		[Fact]
		public void GetMinTempTest()
		{
			Weather w0 = new Weather();
			Weather w1 = new Weather(1, 70, 80);

			Assert.Null(w0.getMinTemp());
			Assert.Equal(70, w1.getMinTemp());
		}

		[Fact]
		public void GetTempSpreadTest()
		{
			Weather w0 = new Weather();
			Weather w1 = new Weather(1, 70, 80);
			Weather w2 = new Weather(2, 80, 70);
			Weather w3 = new Weather(3, 70, 70);

			Assert.Null(w0.getTemperatureSpread());
			Assert.Equal(10, w1.getTemperatureSpread());
			Assert.Equal(-10, w2.getTemperatureSpread());
			Assert.Equal(0, w3.getTemperatureSpread());

		}

	}
}
