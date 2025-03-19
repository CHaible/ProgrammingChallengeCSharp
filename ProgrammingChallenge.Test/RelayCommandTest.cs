using System;
using System.Windows.Input;
using Xunit;
using ProgrammingChallenge.Utilities;

namespace ProgrammingChallenge.Test
{
	public class RelayCommandTests
	{
		[Fact]
		public void Execute_CallsProvidedAction()
		{
			// Arrange
			bool executed = false;
			RelayCommand command = new(() => executed = true);

			// Act
			command.Execute(null);

			// Assert
			Assert.True(executed);
		}

		[Fact]
		public void CanExecute_ReturnsTrue_WhenNoCanExecuteProvided()
		{
			// Arrange
			RelayCommand command = new(() => { });

			// Act
			bool result = command.CanExecute(null);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void CanExecute_ReturnsFalse_WhenCanExecuteReturnsFalse()
		{
			// Arrange
			RelayCommand command = new(() => { }, () => false);

			// Act
			bool result = command.CanExecute(null);

			// Assert
			Assert.False(result);
		}

		[Fact]
		public void CanExecute_ReturnsTrue_WhenCanExecuteReturnsTrue()
		{
			// Arrange
			RelayCommand command = new(() => { }, () => true);

			// Act
			bool result = command.CanExecute(null);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void RaiseCanExecuteChanged_TriggersCanExecuteChangedEvent()
		{
			// Arrange
			RelayCommand command = new(() => { });
			bool eventTriggered = false;

			command.CanExecuteChanged += (sender, args) => eventTriggered = true;

			// Act
			command.RaiseCanExecuteChanged();

			// Assert
			Assert.True(eventTriggered);
		}
	}
}