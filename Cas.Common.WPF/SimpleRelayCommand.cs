using System;
using System.Windows.Input;

namespace Cas.Common.WPF
{
    /// <summary>
    /// This is a simple ICommand implementation based on the MSDN article: https://msdn.microsoft.com/en-us/magazine/dd419663.aspx#id0090030
    /// A more robust implementation is available in the MVVM Lite package: http://www.mvvmlight.net/
    /// </summary>
    /// <remarks>
    /// This version is used here for both the OrderedListViewModel and the examples. This way, there are no external dependencies on any particular
    /// MVVM framework.
    /// </remarks>
    public class SimpleRelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public SimpleRelayCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public virtual void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute();
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}