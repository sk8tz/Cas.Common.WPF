using System;
using System.Windows;
using System.Windows.Input;
using Cas.Common.WPF;
using Cas.Common.WPF.Behaviors;

namespace CloseableExample.ViewModel
{
    public class MainViewModel : ICloseableViewModel
    {
        public event EventHandler<CloseEventArgs> Close;

        public MainViewModel()
        {
            OkCommand = new SimpleRelayCommand(Ok);
            CancelCommand = new SimpleRelayCommand(Cancel);
        }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        private void Ok()
        {
            Close?.Invoke(this, new CloseEventArgs(true));
        }

        private void Cancel()
        {
            Close?.Invoke(this, new CloseEventArgs(null));
        }

        public bool CanClose()
        {
            return MessageBox.Show("Close?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }

        public void Closed()
        {
            Console.WriteLine("The view model is being closed.");            
        }
    }
}