using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingChallenge.Logic;
using ProgrammingChallenge.Application;
using ProgrammingChallenge.Data.CSV;

namespace ProgrammingChallenge.Test
{
	public class DataAnalyzerTest
	{
		[Fact]
		public void InitializeWeatherData_ValidData_CreatesWeatherViewModels()
		{
			// Arrange
			var dataAnalyzer = new DataAnalyzer();
			var weatherData = new List<Dictionary<string, string>>
			{
				new Dictionary<string, string>
				{
					{ "Day", "1" },
					{ "MxT", "88" },
					{ "MnT", "59" }
				},
				new Dictionary<string, string>
				{
					{ "Day", "2" },
					{ "MxT", "79" },
					{ "MnT", "63" }
				}
			};

			// Act
			dataAnalyzer.InitializeWeatherData(weatherData);

			// Assert
			var result = dataAnalyzer.GetMostUniformDay();
			Assert.NotNull(result);
			Assert.Equal(2, result.Day); // Kleinste Temperaturdifferenz (79 - 63 = 16)
		}

		[Fact]
		public void InitializeWeatherData_InvalidData_TriggersConversionFailedEvent()
		{
			// Arrange
			var dataAnalyzer = new DataAnalyzer();
			var weatherData = new List<Dictionary<string, string>>
		{
			new Dictionary<string, string>
			{
				{ "Day", "abc" }, // Ungültige Zahl
                { "MxT", "88" },
				{ "MnT", "59" }
			}
		};

			string? receivedMessage = null;
			dataAnalyzer.ConversionFailed += (sender, message) => receivedMessage = message;

			// Act
			dataAnalyzer.InitializeWeatherData(weatherData);

			// Assert
			Assert.NotNull(receivedMessage);
			Assert.Contains("Error", receivedMessage);
		}

		[Fact]
		public void GetMostUniformDay_WithEmptyData_ReturnsNull()
		{
			// Arrange
			var dataAnalyzer = new DataAnalyzer();
			var weatherData = new List<Dictionary<string, string>>();

			dataAnalyzer.InitializeWeatherData(weatherData);

			// Act
			var result = dataAnalyzer.GetMostUniformDay();

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void InitializeCountriesData_ValidData_CreatesCountryViewModels()
		{
			// Arrange
			var dataAnalyzer = new DataAnalyzer();
			var countryData = new List<Dictionary<string, string>>
		{
			new Dictionary<string, string>
			{
				{ "Name", "CountryA" },
				{ "Population", "1000000" },
				{ "Area (km²)", "500" }  // Density: 2000
            },
			new Dictionary<string, string>
			{
				{ "Name", "CountryB" },
				{ "Population", "5000000" },
				{ "Area (km²)", "5000" }  // Density: 1000
            }
		};

			// Act
			dataAnalyzer.InitializeCountriesData(countryData);

			// Assert
			var result = dataAnalyzer.GetCountryWithHighestPopulationDensity();
			Assert.NotNull(result);
			Assert.Equal("CountryA", result.Name);
		}

		[Fact]
		public void InitializeCountriesData_InvalidData_TriggersConversionFailedEvent()
		{
			// Arrange
			var dataAnalyzer = new DataAnalyzer();
			var countryData = new List<Dictionary<string, string>>
		{
			new Dictionary<string, string>
			{
				{ "Name", "CountryC" },
				{ "Population", "abc" }, // Ungültige Zahl
                { "Area (km²)", "500" }
			}
		};

			string? receivedMessage = null;
			dataAnalyzer.ConversionFailed += (sender, message) => receivedMessage = message;

			// Act
			dataAnalyzer.InitializeCountriesData(countryData);

			// Assert
			Assert.NotNull(receivedMessage);
			Assert.Contains("Invalid number", receivedMessage);
		}

		[Fact]
		public void GetCountryWithHighestPopulationDensity_WithEmptyData_ReturnsNull()
		{
			// Arrange
			var dataAnalyzer = new DataAnalyzer();
			var countryData = new List<Dictionary<string, string>>();

			dataAnalyzer.InitializeCountriesData(countryData);

			// Act
			var result = dataAnalyzer.GetCountryWithHighestPopulationDensity();

			// Assert
			Assert.Null(result);
		}
	}
}
