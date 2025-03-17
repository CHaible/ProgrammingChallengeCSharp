using ProgrammingChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingChallenge.Test
{
	public class MainViewModelTest
	{
		[Fact]
		public void IsResetPossibleTest() 
		{ 
			MainViewModel mainVM = new MainViewModel();
			mainVM.IsResetPossible = true;
			Assert.True(mainVM.IsResetPossible);
		}

		[Fact]
		public void IsNotResetPossibleTest()
		{
			MainViewModel mainVM = new MainViewModel();
			mainVM.IsResetPossible = false;
			Assert.False(mainVM.IsResetPossible);
		}

		[Fact]
		public void PropertyChangedEventTest()
		{
			MainViewModel mainVM = new MainViewModel();
			PropertyChangedEventArgs? eventArgs = null;
			object? thisSender = null ;
			mainVM.PropertyChanged += (sender, e) =>
			{
				eventArgs = e;
				thisSender = sender;
			};
			mainVM.WeatherVisibility = System.Windows.Visibility.Collapsed;
			Assert.NotNull(eventArgs);
			Assert.Equal(mainVM, thisSender);
			Assert.Equal("WeatherVisibility", eventArgs.PropertyName);
		}

		[Fact]
		public void PropertyChangedTest()
		{
			MainViewModel mainVM = new MainViewModel();
			mainVM.WeatherVisibility = System.Windows.Visibility.Collapsed;
		}
	}
}
