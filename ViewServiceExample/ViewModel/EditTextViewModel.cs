using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Cas.Common.WPF;
using Cas.Common.WPF.Behaviors;

namespace ViewServiceExample.ViewModel
{
    public class EditTextViewModel : ICloseableViewModel, INotifyPropertyChanged
    {
        private string _text;
        public event EventHandler<CloseEventArgs> Close;

        public EditTextViewModel()
        {
            OkCommand = new SimpleRelayCommand(Ok);
        }

        public ICommand OkCommand { get; }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value; 
                OnPropertyChanged();
            }
        }

        private void Ok()
        {
            Close?.Invoke(this, new CloseEventArgs(true));
        }

        public bool CanClose()
        {
            return true;
        }

        public void Closed()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}