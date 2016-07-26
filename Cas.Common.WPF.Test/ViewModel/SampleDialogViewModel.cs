using System;
using System.Windows.Input;
using Cas.Common.WPF.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Cas.Common.WPF.Test.ViewModel
{
    public class SampleDialogViewModel : ViewModelBase
    {
        private readonly IMessageBoxService _messageBoxService;

        public SampleDialogViewModel(IMessageBoxService messageBoxService)
        {
            if (messageBoxService == null) throw new ArgumentNullException(nameof(messageBoxService));

            _messageBoxService = messageBoxService;

            ShowMessageCommand = new RelayCommand(ShowMessage);
        }

        private void ShowMessage()
        {
            _messageBoxService.ShowMessageBox("Sup");
        }

        public string Title { get; set; }

        public ICommand ShowMessageCommand { get; }
    }
}