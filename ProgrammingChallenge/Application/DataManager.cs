using System.Collections.Generic;
using ProgrammingChallenge.Data.CSV;
using ProgrammingChallenge.Logic;
using ProgrammingChallenge.Models;
using ProgrammingChallenge.ViewModels;

namespace ProgrammingChallenge.Application
{
    public class DataManager
    {
		/// <summary>
		/// Path of the csv-file with weather data
		/// </summary>
		private readonly string _weatherFilePath;

		/// <summary>
		/// Path of the csv-file with country data
		/// </summary>
		private readonly string _countryFilePath;

		/// <summary>
        /// Occurs when a conversion from string to int fails
        /// </summary>
		public event EventHandler<string>? ConversionFailed;

		/// <summary>
		/// Constructor for the DataManager class, initializes properties
		/// </summary>
		/// <param name="weatherFilePath">Path of the csv-file with weather data</param>
		/// <param name="countryFilePath">Path of the csv-file with country data</param>
		public DataManager(string weatherFilePath, string countryFilePath)
        {
            _weatherFilePath = weatherFilePath;
            _countryFilePath = countryFilePath;
        }

        /// <summary>
        /// Loads weather data, initializes DataAnalyzer and gets most uniform day as WeatherViewModel
        /// </summary>
        public WeatherViewModel GetMostUniformDay()
        {
            var weatherData = new CsvReader(',').ReadData(_weatherFilePath);
            var weatherAnalyzer = new DataAnalyzer();
            weatherAnalyzer.InitializeWeatherData(weatherData);
            return weatherAnalyzer.GetMostUniformDay();
        }

        /// <summary>
        /// Loads countries data, initializes DataAnalyzer and gets country with highest population density
        /// </summary>
        public CountryViewModel GetCountryWithHighestPopulationDensity()
        {
            var countriesData = new CsvReader(';').ReadData(_countryFilePath);
            var countriesAnalyzer = new DataAnalyzer();
            countriesAnalyzer.InitializeCountriesData(countriesData);
            return countriesAnalyzer.GetCountryWithHighestPopulationDensity();
        }
    }
}
