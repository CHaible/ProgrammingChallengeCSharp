using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingChallenge.Models;
using ProgrammingChallenge.ViewModels;

namespace ProgrammingChallenge.Test
{
	public class CountryViewModelTest
	{
		[Fact]
		public void CountryViewModelPropertiesTest()
		{
			Country c1 = new Country("Germany", 64000, 800);
			CountryViewModel c1VM = new CountryViewModel(c1);

			Assert.Equal(c1, c1VM.Country);
			Assert.Equal("Germany", c1VM.Name);
			Assert.Equal(80, c1VM.PopulationDensity);
			Assert.Equal("Germany: 80,00 Menschen/km²", c1VM.ToString());
		}
	}
}
