using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;

namespace ViewServiceExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IViewService _viewService;
        private string _text = "Content";
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(IViewService viewService)
        {
            if (viewService == null) throw new ArgumentNullException(nameof(viewService));

            _viewService = viewService;

            EditTextCommand = new SimpleRelayCommand(EditText);
            DisplayTextCommand = new SimpleRelayCommand(DisplayText);
        }

        public ICommand EditTextCommand { get; }
        public ICommand DisplayTextCommand { get; }

        private void EditText()
        {
            var viewModel = new EditTextViewModel()
            {
                Text = Text
            };

            if (_viewService.ShowDialog(viewModel) == true)
            {
                Text = viewModel.Text;
            }
        }

        private void DisplayText()
        {
            var viewModel = new DisplayTextViewModel()
            {
                Text = Text
            };

            _viewService.Show(viewModel);
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