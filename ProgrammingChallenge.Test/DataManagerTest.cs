using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using ProgrammingChallenge.Application;
using ProgrammingChallenge.Data.CSV;
using ProgrammingChallenge.Logic;
using ProgrammingChallenge.Models;
using ProgrammingChallenge.ViewModels;

namespace ProgrammingChallenge.Test
{
	public class DataManagerTest
	{
		private const string WeatherTestFilePath = "weather_test.csv";
		private const string CountryTestFilePath = "country_test.csv";

		private void CreateTestFile(string filePath, string content)
		{
			File.WriteAllText(filePath, content);
		}

		private void CleanupTestFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}

		[Fact]
		public void GetMostUniformDay_Returns_CorrectWeatherViewModel()
		{
			// Arrange
			var csvContent = "Day,MxT,MnT\n1,88,59\n2,79,63\n3,77,60";
			CreateTestFile(WeatherTestFilePath, csvContent);
			var dataManager = new DataManager(WeatherTestFilePath, CountryTestFilePath);

			// Act
			var result = dataManager.GetMostUniformDay();

			// Assert
			Assert.NotNull(result);
			Assert.Equal(3, result.Day); // Tag mit geringstem TempSpread: 77-60=17

			CleanupTestFile(WeatherTestFilePath);
		}

		[Fact]
		public void GetCountryWithHighestPopulationDensity_Returns_CorrectCountryViewModel()
		{
			// Arrange
			var csvContent = "Country;Population;Area (km²)\nAland;30000;1580\nLuxembourg;650000;2586\nMonaco;39242;2";
			CreateTestFile(CountryTestFilePath, csvContent);
			var dataManager = new DataManager(WeatherTestFilePath, CountryTestFilePath);

			// Act
			var result = dataManager.GetCountryWithHighestPopulationDensity();

			// Assert
			Assert.NotNull(result);
			Assert.Equal("Monaco", result.Country.Name); // Höchste Bevölkerungsdichte: 39242 / 2

			CleanupTestFile(CountryTestFilePath);
		}

		[Fact]
		public void GetMostUniformDay_WithEmptyFile_Returns_Null()
		{
			// Arrange
			CreateTestFile(WeatherTestFilePath, "");
			var dataManager = new DataManager(WeatherTestFilePath, CountryTestFilePath);

			// Act
			var result = dataManager.GetMostUniformDay();

			// Assert
			Assert.Null(result);

			CleanupTestFile(WeatherTestFilePath);
		}

		[Fact]
		public void GetCountryWithHighestPopulationDensity_WithEmptyFile_Returns_Null()
		{
			// Arrange
			CreateTestFile(CountryTestFilePath, "");
			var dataManager = new DataManager(WeatherTestFilePath, CountryTestFilePath);

			// Act
			var result = dataManager.GetCountryWithHighestPopulationDensity();

			// Assert
			Assert.Null(result);

			CleanupTestFile(CountryTestFilePath);
		}
	}
}