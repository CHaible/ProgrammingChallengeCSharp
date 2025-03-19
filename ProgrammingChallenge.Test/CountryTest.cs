using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingChallenge.Models;

namespace ProgrammingChallenge.Test
{
	public class CountryTest
	{
		[Fact]
		public void CountryPropertiesTest()
		{
			Country c1 = new Country("Germany", 100, 50);
			Country c2 = new Country("France", 200, 100);

			Assert.Equal("Germany", c1.Name);
			Assert.Equal(100, c1.Population);
			Assert.Equal(50, c1.Area);
			Assert.Equal("France", c2.Name);
			Assert.Equal(200, c2.Population);
			Assert.Equal(100, c2.Area);

			Assert.Throws<ArgumentException>(() => new Country(string.Empty, 100, 50));
			Assert.Throws<ArgumentOutOfRangeException>(() => new Country("Germany", -100, 50));
			Assert.Throws<ArgumentOutOfRangeException>(() => new Country("Germany", 100, -50));
		}

		[Fact]
		public void CalculatePopulationDensityTest()
		{
			Country c1 = new Country("Germany", 100, 50);
			Country c2 = new Country("France", 200, 100);

			Assert.Equal(2, c1.CalculatePopulationDensity());
			Assert.Equal(2, c2.CalculatePopulationDensity());
		}	
	}
}
