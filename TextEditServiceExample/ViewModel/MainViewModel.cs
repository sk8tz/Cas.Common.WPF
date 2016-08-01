using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;

namespace TextEditServiceExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ITextEditService _textEditService;
        private string _text;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(ITextEditService textEditService)
        {
            if (textEditService == null) throw new ArgumentNullException(nameof(textEditService));

            _textEditService = textEditService;

            EditTextCommand = new SimpleRelayCommand(EditText);
        }

        public ICommand EditTextCommand { get; }

        private void EditText()
        {
            _textEditService.EditText(Text, "Edit the text:", "Edit Text Example", t => Text = t, t =>!string.IsNullOrWhiteSpace(t));
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}