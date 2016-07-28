using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConvertersExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _value;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool Value
        {
            get { return _value; }
            set
            {
                _value = value; 
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}