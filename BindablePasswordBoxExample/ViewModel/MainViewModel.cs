using System.ComponentModel;
using System.Runtime.CompilerServices;
using BindablePasswordBoxExample.Annotations;

namespace BindablePasswordBoxExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _password = "password";
        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                OnPropertyChanged();
            }
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}