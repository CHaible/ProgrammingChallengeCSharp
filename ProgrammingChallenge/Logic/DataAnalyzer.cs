using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammingChallenge.Models;
using ProgrammingChallenge.ViewModels;
using ProgrammingChallenge.Resources;
using System.ComponentModel;

namespace ProgrammingChallenge.Logic
{
	public class DataAnalyzer
	{
		/// <summary>
		/// List of WeatherViewModels for holding all incoming weather data
		/// </summary>
		private readonly List<WeatherViewModel> _weatherViewModelList;
		/// <summary>
		/// List of CountryViewModels for holding all incoming country data
		/// </summary>
		private readonly List<CountryViewModel> _countryViewModelList;

		/// <summary>
		/// Occurs when a conversion from string to int fails
		/// </summary>
		public event EventHandler<string>? ConversionFailed;

		/// <summary>
		/// Constructor for the DataAnalyzer class, initializes properties
		/// </summary>
		public DataAnalyzer()
		{
			_weatherViewModelList = new List<WeatherViewModel>();
			_countryViewModelList = new List<CountryViewModel>();
		}

		/// <summary>
		/// Extracts the weather data from the given list of dictionaries, initializes the WeatherViewModels and adds them to the list
		/// </summary>
		/// <param name="data"></param>
		public void InitializeWeatherData(List<Dictionary<string, string>> data)
		{
			_weatherViewModelList.Clear();
			List<string> errorMessages = new();

			foreach (var row in data)
			{
				try
				{
					if (!row.TryGetValue(Resources.Resources.keyNameDay, out string dayValue))
						throw new FormatException($"Missing value: {Resources.Resources.keyNameDay}");
					if (!row.TryGetValue(Resources.Resources.keyNameMinTemp, out string minTempValue))
						throw new FormatException($"Missing value: {Resources.Resources.keyNameMinTemp}");
					if (!row.TryGetValue(Resources.Resources.keyNameMaxTemp, out string maxTempValue))
						throw new FormatException($"Missing value: {Resources.Resources.keyNameMaxTemp}");
					if (!int.TryParse(dayValue, out int day))
						throw new FormatException($"Invalid number: {Resources.Resources.keyNameDay} = {day}");
					if (!int.TryParse(minTempValue, out int minTemp))
						throw new FormatException($"Invalid number: {Resources.Resources.keyNameMinTemp} = {minTempValue}");
					if (!int.TryParse(maxTempValue, out int maxTemp))
						throw new FormatException($"Invalid number: {Resources.Resources.keyNameMaxTemp} = {maxTempValue}");
					
					var weather = new Weather(day, minTemp, maxTemp);
					_weatherViewModelList.Add(new WeatherViewModel(weather));
				}
				catch (Exception ex)
				{
					errorMessages.Add($"Error in row: {ex.Message}");
				}
			}

			if (errorMessages.Count > 0)
			{
				string errorReport = string.Join("\n", errorMessages);
				ConversionFailed?.Invoke(this, errorReport);
			}

		}

		/// <summary>
		/// Extracts the country data from the given list of dictionaries, initializes the CountryViewModels and adds them to the list
		/// </summary>
		/// <param name="data"></param>
		public void InitializeCountriesData(List<Dictionary<string, string>> data)
		{
			_countryViewModelList.Clear();
			List<string> errorMessages = new();

			foreach (var row in data)
			{
				try
				{
					if (!row.TryGetValue(Resources.Resources.keyNameCountryname, out string nameValue))
						throw new FormatException($"Missing value: {Resources.Resources.keyNameCountryname}");
					if (!row.TryGetValue(Resources.Resources.keyNamePopulation, out string populationValue))
						throw new FormatException($"Missing value: {Resources.Resources.keyNamePopulation}");
					if (!row.TryGetValue(Resources.Resources.keyNameArea, out string areaValue))
						throw new FormatException($"Missing value: {Resources.Resources.keyNameArea}");

					if (!int.TryParse(populationValue, out int population))
						throw new FormatException($"Invalid number: {Resources.Resources.keyNamePopulation} = {populationValue}");
					if (!int.TryParse(areaValue, out int area))
						throw new FormatException($"Invalid number: {Resources.Resources.keyNameArea} = {areaValue}");

					var country = new Country(nameValue, population, area);
					_countryViewModelList.Add(new CountryViewModel(country));
				}
				catch (Exception ex)
				{
					errorMessages.Add($"Error in row: {ex.Message}");
				}
			}

			if (errorMessages.Count > 0)
			{
				string errorReport = string.Join("\n", errorMessages);
				ConversionFailed?.Invoke(this, errorReport);
			}
		}


		/// <summary>
		/// Gets the day with the smallest temperature spread
		/// </summary>
		/// <returns></returns>
		public WeatherViewModel GetMostUniformDay()
		{
			return _weatherViewModelList.OrderBy(w => w.TempSpread).FirstOrDefault();
		}

		/// <summary>
		/// Gets the country with the highest population density
		/// </summary>
		/// <returns></returns>
		public CountryViewModel GetCountryWithHighestPopulationDensity()
		{
			return _countryViewModelList.OrderByDescending(c => c.Country.CalculatePopulationDensity()).FirstOrDefault();
		}
	}
}
