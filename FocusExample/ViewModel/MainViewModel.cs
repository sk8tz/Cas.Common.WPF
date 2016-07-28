using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Cas.Common.WPF;

namespace FocusExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _isFirstNameFocused;
        private bool _isLastNameFocused;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            SelectFirstName = new SimpleRelayCommand(() =>
            {
                IsLastNameFocused = false;
                IsFirstNameFocused = true;
            });
            SelectLastName = new SimpleRelayCommand(() =>
            {
                IsFirstNameFocused = false;
                IsLastNameFocused = true;
            });
        }

        public ICommand SelectFirstName { get; }
        public ICommand SelectLastName { get;  }

        public bool IsFirstNameFocused
        {
            get { return _isFirstNameFocused; }
            set
            {
                _isFirstNameFocused = value; 
                OnPropertyChanged();
            }
        }

        public bool IsLastNameFocused
        {
            get { return _isLastNameFocused; }
            set
            {
                _isLastNameFocused = value; 
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}