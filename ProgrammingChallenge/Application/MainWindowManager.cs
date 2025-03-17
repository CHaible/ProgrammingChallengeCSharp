using ProgrammingChallenge.Data.CSV;
using ProgrammingChallenge.Logic;
using ProgrammingChallenge.Models;
using ProgrammingChallenge.Resources;
using ProgrammingChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingChallenge.Application
{
    public class MainWindowManager
    {
        string PathWeather => Resources.Resources.pathWeather;

        public MainViewModel MainViewModel { get; set; }

        public MainWindowManager()
        {
            MainViewModel = new MainViewModel();
            ResetWeather();
        }

        public void WeatherChallenge()
        {
            MainViewModel.WeatherViewModels.Clear();
            List<Dictionary<string, string>> data = new CsvReader(',').ReadData(PathWeather);
            var newWeather = new WeatherAnalyzer(data).GetMostUniformDay();
            MainViewModel.WeatherViewModels.Add(newWeather);
            MainViewModel.WeatherVisibility = System.Windows.Visibility.Visible;
            MainViewModel.IsResetPossible = true;
        }

        public void ResetWeather()
        {
            MainViewModel.WeatherViewModels.Clear();
            MainViewModel.WeatherVisibility = System.Windows.Visibility.Hidden;
            MainViewModel.IsResetPossible = false;

        }
    }
}
