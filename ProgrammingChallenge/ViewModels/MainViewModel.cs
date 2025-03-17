using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProgrammingChallenge.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<WeatherViewModel> _weatherViewModels = new ObservableCollection<WeatherViewModel>();
		public ObservableCollection<WeatherViewModel> WeatherViewModels
		{
			get => _weatherViewModels;
			set
			{
				_weatherViewModels = value;
				OnPropertyChanged(nameof(WeatherViewModels));
				WeatherVisibility = Visibility.Visible;
			}
		}

		private Visibility _weatherVisibility = Visibility.Hidden;

		public Visibility WeatherVisibility
		{
			get => _weatherVisibility;
			set
			{
				_weatherVisibility = value;
				OnPropertyChanged(nameof(WeatherVisibility));
			}
		}

		private bool _isResetPossible = false;
		public bool IsResetPossible
		{
			get => _isResetPossible;
			set
			{
				_isResetPossible = value;
				OnPropertyChanged(nameof(IsResetPossible));
			}
		}

		public MainViewModel()
		{

		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

