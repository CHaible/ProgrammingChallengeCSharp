using ProgrammingChallenge.Data.CSV;
using ProgrammingChallenge.ViewModels;
using ProgrammingChallenge.Resources;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProgrammingChallenge.Application;

namespace ProgrammingChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			_manager = new MainWindowManager();
			DataContext = _manager.MainViewModel;
		}

		public MainWindowManager _manager { get; set; }
		
		private void ButtonWeather_Click(object sender, RoutedEventArgs e)
		{
			_manager.WeatherChallenge();
		}

		private void ButtonReset_Click(object sender, RoutedEventArgs e)
		{
			_manager.ResetWeather();
		}
	}
}