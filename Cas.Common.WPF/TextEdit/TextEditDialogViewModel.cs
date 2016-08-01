using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Cas.Common.WPF.Behaviors;

namespace Cas.Common.WPF.TextEdit
{
    internal class TextEditDialogViewModel : INotifyPropertyChanged, ICloseableViewModel
    {
        private readonly string _caption;
        private readonly string _title;
        private readonly Func<string, bool> _validate;
        private string _text;
        public event PropertyChangedEventHandler PropertyChanged;

        public TextEditDialogViewModel(string text, string caption, string title, Func<string, bool> validate)
        {
            _caption = caption;
            _title = title;
            _validate = validate;
            _text = text;

            OkCommand = new SimpleRelayCommand(Ok, CanOk);
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value; 
                OnPropertyChanged();
            }
        }

        public ICommand OkCommand { get; }

        private void Ok()
        {
            Close?.Invoke(this, new CloseEventArgs(true));
        }

        private bool CanOk()
        {
            return _validate == null || _validate(Text);
        }

        public string Caption
        {
            get { return _caption; }
        }

        public string Title
        {
            get { return _title; }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler<CloseEventArgs> Close;
        public bool CanClose()
        {
            return true;
        }

        public void Closed()
        {
        }
    }
}