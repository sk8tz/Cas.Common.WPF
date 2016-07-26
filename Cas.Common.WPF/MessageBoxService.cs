using System;
using System.Windows;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
    public class MessageBoxService : IMessageBoxService
    {
        private readonly IViewService _viewService;

        public MessageBoxService(IViewService viewService = null)
        {
            _viewService = viewService;
        }

        public MessageBoxResult ShowMessageBox(string messageBoxText, 
            string caption = null, 
            MessageBoxButton button = MessageBoxButton.OK, 
            MessageBoxImage icon = MessageBoxImage.None, 
            MessageBoxResult defaultResult = MessageBoxResult.None)
        {
            var owner = _viewService?.ActiveWindow;

            if (owner == null)
            {
                return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult);
            }

            return MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult);
        }
    }
}