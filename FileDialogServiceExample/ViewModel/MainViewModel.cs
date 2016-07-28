using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;

namespace FileDialogServiceExample.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IFileDialogService _fileDialogService;
        private string _fileName;
        private const string Filter = "All Files (*.*)|*.*";

        public MainViewModel(IFileDialogService fileDialogService)
        {
            if (fileDialogService == null) throw new ArgumentNullException(nameof(fileDialogService));
            _fileDialogService = fileDialogService;

            OpenFileCommand = new SimpleRelayCommand(OpenFile);
            SaveFileCommand = new SimpleRelayCommand(SaveFile);
        }

        public ICommand OpenFileCommand { get; }
        public ICommand SaveFileCommand { get; }

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value; 
                OnPropertyChanged();
            }
        }

        private void OpenFile()
        {
            var options = new FileDialogOptions()
            {
                Filter = Filter
            };

            var result = _fileDialogService.ShowOpenFileDialog(options);

            if (result != null)
            {
                FileName = result.FileName;
            }
        }

        private void SaveFile()
        {
            var options = new FileDialogOptions()
            {
                Filter = Filter
            };

            var result = _fileDialogService.ShowSaveFileDialog(options);

            if (result != null)
            {
                FileName = result.FileName;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}