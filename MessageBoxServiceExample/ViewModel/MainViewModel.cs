using System;
using System.Windows;
using System.Windows.Input;
using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;

namespace MessageBoxServiceExample.ViewModel
{
    public class MainViewModel
    {
        private readonly IMessageBoxService _messageBoxService;

        public MainViewModel(IMessageBoxService messageBoxService)
        {
            if (messageBoxService == null) throw new ArgumentNullException(nameof(messageBoxService));

            _messageBoxService = messageBoxService;

            ShowMessageBoxCommand = new SimpleRelayCommand(ShowMessageBox);
            AskYesNoCommand = new SimpleRelayCommand(AskYesNo);
        }

        public ICommand ShowMessageBoxCommand { get; }

        public ICommand AskYesNoCommand { get; }

        private void ShowMessageBox()
        {
            _messageBoxService.Show("From the message box service.");
        }

        private void AskYesNo()
        {
            var result = _messageBoxService.Show("Yes or no?", "Question", MessageBoxButton.YesNo);

            _messageBoxService.Show(result.ToString(), "You answered");
        }
    }
}