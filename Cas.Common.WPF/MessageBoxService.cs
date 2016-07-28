using System;
using System.Windows;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
    /// <summary>
    /// Implementation of IMessageBoxService.
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        public MessageBoxResult Show(string messageBoxText, 
            string caption = null, 
            MessageBoxButton button = MessageBoxButton.OK, 
            MessageBoxImage icon = MessageBoxImage.None, 
            MessageBoxResult defaultResult = MessageBoxResult.None)
        {
            var owner = WindowUtil.GetActiveWindow();

            caption = caption ?? "";

            if (owner == null)
            {
                return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult);
            }

            return MessageBox.Show(owner, messageBoxText, caption, button, icon, defaultResult);
        }
    }
}