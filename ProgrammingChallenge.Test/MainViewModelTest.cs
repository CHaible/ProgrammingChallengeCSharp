using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Xunit;
using ProgrammingChallenge.ViewModels;
using ProgrammingChallenge.Application;
using ProgrammingChallenge.Utilities;
using ProgrammingChallenge.Models;

namespace ProgrammingChallenge.Test
{
	public class MainViewModelTests
	{
		private readonly DataManager _dataManager;
		private readonly MainViewModel _viewModel;

		public MainViewModelTests()
		{
			_dataManager = new DataManager("weather.csv", "countries.csv");
			_viewModel = new MainViewModel();
		}

		[Fact]
		public void Constructor_InitializesDefaults()
		{
			// Assert
			Assert.NotNull(_viewModel.WeatherViewModels);
			Assert.Empty(_viewModel.WeatherViewModels);
			Assert.Null(_viewModel.CountryToString);
			Assert.Null(_viewModel.ErrorString);
			Assert.Equal(Visibility.Hidden, _viewModel.WeatherVisibility);
			Assert.Equal(Visibility.Hidden, _viewModel.CountryVisibility);
			Assert.Equal(Visibility.Hidden, _viewModel.ErrorVisibility);
			Assert.False(_viewModel.IsResetPossible);
		}

		// TODO Cora: Hier noch eine entsprechende korrekte Implementierung finden
		//[Fact]
		//public void AnalyzeWeatherCommand_AddsWeatherViewModel()
		//{
		//	// Arrange
		//	var weatherViewModel = new WeatherViewModel( new Weather(1, 59, 88));
		//	_dataManager.GetMostUniformDay();
		//	var viewModel = new MainViewModel();

		//	// Act
		//	viewModel.AnalyzeWeatherCommand.Execute(null);

		//	// Assert
		//	Assert.Single(viewModel.WeatherViewModels);
		//	Assert.Equal(weatherViewModel, viewModel.WeatherViewModels[0]);
		//	Assert.Equal(Visibility.Visible, viewModel.WeatherVisibility);
		//	Assert.True(viewModel.IsResetPossible);
		//}

		// TODO Cora: Hier noch eine entsprechende korrekte Implementierung finden
		//[Fact]
		//public void AnalyzeCountryCommand_SetsCountryToString()
		//{
		//	// Arrange
		//	var countryViewModel = new CountryViewModel(new Country("Testland", 1000000, 500));
		//	_dataManager.GetCountryWithHighestPopulationDensity();
		//	var viewModel = new MainViewModel();

		//	// Act
		//	viewModel.AnalyzeCountryCommand.Execute(null);

		//	// Assert
		//	Assert.Contains("Testland", viewModel.CountryToString);
		//	Assert.Equal(Visibility.Visible, viewModel.CountryVisibility);
		//	Assert.True(viewModel.IsResetPossible);
		//}

		[Fact]
		public void ResetCommand_ClearsData()
		{
			// Arrange
			var weatherViewModel = new WeatherViewModel(new Weather(1, 59, 88));
			_viewModel.WeatherViewModels.Add(weatherViewModel);
			_viewModel.CountryToString = "Testland";
			_viewModel.ErrorString = "Error";

			// Act
			_viewModel.ResetCommand.Execute(null);

			// Assert
			Assert.Empty(_viewModel.WeatherViewModels);
			Assert.Equal(string.Empty, _viewModel.CountryToString);
			Assert.Equal(string.Empty, _viewModel.ErrorString);
			Assert.Equal(Visibility.Hidden, _viewModel.WeatherVisibility);
			Assert.Equal(Visibility.Hidden, _viewModel.CountryVisibility);
			Assert.Equal(Visibility.Hidden, _viewModel.ErrorVisibility);
			Assert.False(_viewModel.IsResetPossible);
		}

		[Fact]
		public void ConversionFailedEvent_SetsErrorString()
		{
			// Arrange
			string errorMessage = "Invalid";
			bool eventRaised = false;
			_viewModel.ConversionFailed += (s, e) =>
			{
				eventRaised = true;
				Assert.Contains(errorMessage, e);
			};

			// Act
			_viewModel.ConvertStringToInt("NotANumber");

			// Assert
			Assert.True(eventRaised);
			Assert.Contains(errorMessage, _viewModel.ErrorString);
			Assert.Equal(Visibility.Visible, _viewModel.ErrorVisibility);
		}

		[Fact]
		public void PropertyChanged_IsRaisedCorrectly()
		{
			// Arrange
			bool eventRaised = false;
			_viewModel.PropertyChanged += (sender, args) =>
			{
				if (args.PropertyName == nameof(MainViewModel.CountryToString))
					eventRaised = true;
			};

			// Act
			_viewModel.CountryToString = "New Country";

			// Assert
			Assert.True(eventRaised);
		}
	}
}