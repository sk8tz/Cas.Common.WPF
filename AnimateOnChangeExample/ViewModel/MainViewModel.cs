using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AnimateOnChangeExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _text = "Change me";
        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value; 
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}