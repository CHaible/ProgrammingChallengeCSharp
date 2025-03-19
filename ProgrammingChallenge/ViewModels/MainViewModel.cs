using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ProgrammingChallenge.Application;
using ProgrammingChallenge.Utilities;
using ProgrammingChallenge.Resources;

namespace ProgrammingChallenge.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// DataManager to handle the logic of the application
		/// </summary>
		private readonly DataManager _dataManager;

		private ObservableCollection<WeatherViewModel> _weatherViewModels = new();
		/// <summary>
		/// Contains the WeatherViewModels to show in the DataGrid
		/// </summary>
		public ObservableCollection<WeatherViewModel> WeatherViewModels
		{
			get => _weatherViewModels;
			set
			{
				_weatherViewModels = value;
				OnPropertyChanged();
			}
		}

		private string? _countryToString;
		/// <summary>
		/// Sets the country to string to show in the TextBlock
		/// </summary>
		public string? CountryToString
		{
			get => _countryToString;
			set
			{
				_countryToString = value;
				OnPropertyChanged();
			}
		}

		private string? _errorString;
		/// <summary>
		/// String to show in case of an error
		/// </summary>
		public string? ErrorString
		{
			get => _errorString;
			set
			{
				_errorString = value;
				OnPropertyChanged();
			}
		}

		private Visibility _weatherVisibility = Visibility.Hidden;
		/// <summary>
		/// Flag to show or hide the Weather DataGrid
		/// </summary>
		public Visibility WeatherVisibility
		{
			get => _weatherVisibility;
			set
			{
				if (_weatherVisibility != value)
				{
					_weatherVisibility = value;
					OnPropertyChanged();
				}
			}
		}

		private Visibility _countryVisibility = Visibility.Hidden;
		/// <summary>
		/// Flag to show or hide the Country TextBlock
		/// </summary>
		public Visibility CountryVisibility
		{
			get => _countryVisibility;
			set
			{
				if (_countryVisibility != value)
				{
					_countryVisibility = value;
					OnPropertyChanged();
				}
			}
		}

		private Visibility _errorVisibility = Visibility.Hidden;
		/// <summary>
		/// Flag to show or hide the Error TextBlock
		/// </summary>
		public Visibility ErrorVisibility
		{
			get => _errorVisibility;
			set
			{
				if (_errorVisibility != value)
				{
					_errorVisibility = value;
					OnPropertyChanged();
				}
			}
		}

		private bool _isResetPossible = false;
		/// <summary>
		/// Flag to enable or disable the Reset Button
		/// </summary>
		public bool IsResetPossible
		{
			get => _isResetPossible;
			set
			{
				if (_isResetPossible != value)
				{
					_isResetPossible = value;
					OnPropertyChanged();
					((RelayCommand)ResetCommand).RaiseCanExecuteChanged();
				}
			}
		}

		/// <summary>
		/// Command to reset the results
		/// </summary>
		public ICommand ResetCommand { get; }

		/// <summary>
		/// Command to analyze the weather data
		/// </summary>
		public ICommand AnalyzeWeatherCommand { get; }

		/// <summary>
		/// Command to analyze the country data
		/// </summary>
		public ICommand AnalyzeCountryCommand { get; }

		/// <summary>
		/// Occurs when a property value changes
		/// </summary>
		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// Occurs when a conversion from string to int fails
		/// </summary>
		public event EventHandler<string>? ConversionFailed;

		/// <summary>
		/// Constructor for the MainViewModel class, initializes properties
		/// </summary>
		public MainViewModel()
		{
			_dataManager = new DataManager(Resources.Resources.pathWeather, Resources.Resources.pathCountries);
			ResetCommand = new RelayCommand(Reset, () => IsResetPossible);
			AnalyzeWeatherCommand = new RelayCommand(AnalyzeWeatherData);
			AnalyzeCountryCommand = new RelayCommand(AnalyzeCountryData);
			_dataManager.ConversionFailed += (sender, message) =>
			{
				ErrorString = message;
				OnPropertyChanged(nameof(ErrorString));
			};
		}

		/// <summary>
		/// Resets CountryToString and WeatherViewModels, calls DataManger to get the most uniform day and updates visibility
		/// </summary>
		private void AnalyzeWeatherData()
		{
			try
			{
				Reset();
				var weather = _dataManager.GetMostUniformDay();
				WeatherViewModels.Add(weather);
				UpdateVisibility();
			}
			catch(FormatException e)
			{
				ConversionFailed?.Invoke(this, $"{Resources.Resources.errorAnalyseWeather}: {e.Message}");
			}
		}

		/// <summary>
		/// Resets WeatherViewModels, calls DataManager to get the country with the highest population density and updates visibility
		/// </summary>
		private void AnalyzeCountryData()
		{
			try
			{
				Reset();
				var country = _dataManager.GetCountryWithHighestPopulationDensity();
				CountryToString = country?.ToString() ?? $"{Resources.Resources.errorInvalidData}";
				UpdateVisibility();
			}
			catch (Exception ex)
			{
				ConversionFailed?.Invoke(this, $"{Resources.Resources.errorAnalyseCountries}: {ex.Message}");
			}
		}


		/// <summary>
		/// Resets CountryToString and WeatherViewModels and updates visibility
		/// </summary>
		private void Reset()
		{
			WeatherViewModels.Clear();
			CountryToString = string.Empty;
			ErrorString = String.Empty;
			UpdateVisibility();
		}

		/// <summary>
		/// Sets Visibility properties based on the WeatherViewModels and CountryToString
		/// </summary>
		private void UpdateVisibility()
		{
			WeatherVisibility = WeatherViewModels.Count > 0 ? Visibility.Visible : Visibility.Hidden;
			CountryVisibility = string.IsNullOrEmpty(CountryToString) ? Visibility.Hidden : Visibility.Visible;
			IsResetPossible = WeatherViewModels.Count > 0 || !string.IsNullOrEmpty(CountryToString);
			ErrorVisibility = string.IsNullOrEmpty(ErrorString) ? Visibility.Hidden : Visibility.Visible;
		}

		/// <summary>
		/// Raises the PropertyChanged event to notify the UI that a property value has changed
		/// </summary>
		/// <param name="propertyName"></param>
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Raises conversion failed event if the input is not a valid integer
		/// </summary>
		/// <param name="input"></param>
		public void ConvertStringToInt(string input)
		{
			if (!int.TryParse(input, out int result))
			{
				ConversionFailed?.Invoke(this, $"Invalid input: {input}");
			}
		}
	}

	
}