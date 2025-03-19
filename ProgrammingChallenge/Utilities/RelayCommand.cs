using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProgrammingChallenge.Utilities
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

		/// <summary>
		/// Constructor for the RelayCommand class, initializes properties
		/// </summary>
		/// <param name="execute">Action to be executed</param>
		/// <param name="canExecute">Function that determines whether the command can be executed (optional).</param>
		public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? (() => true);
        }

		/// <summary>
		/// Determines whether the command can execute in its current state
		/// </summary>
		/// <param name="parameter">Optional parameter (not used)</param>
		/// <returns>True if the command can execute; otherwise, false</returns>
		public bool CanExecute(object? parameter) => _canExecute();
		
		/// <summary>
		/// Executes the command's action
		/// </summary>
		/// <param name="parameter">Optional parameter (not used)</param>
		public void Execute(object? parameter) => _execute();
		
		/// <summary>
		/// Occurs when changes affect whether or not the command should execute
		/// </summary>
		public event EventHandler? CanExecuteChanged;
		
		/// <summary>
		/// Raises the CanExecuteChanged event to notify the UI that the execution state has changed
		/// </summary>
		public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}
}
