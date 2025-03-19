using ProgrammingChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingChallenge.Test
{
	public class WeatherViewModelTest
	{
		[Fact]
		public void WeatherViewModelPropertiesTest()
		{
			Weather w1 = new Weather(1, 70, 80);
			WeatherViewModel w1VM = new WeatherViewModel(w1);

			Assert.Equal(1, w1VM.Day);
			Assert.Equal(70, w1VM.MinTemp);
			Assert.Equal(80, w1VM.MaxTemp);
			Assert.Equal(10, w1VM.TempSpread);
		}
	}
}
