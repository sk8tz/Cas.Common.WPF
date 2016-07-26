using System.Windows;

namespace Cas.Common.WPF.Interfaces
{
    public interface IMessageBoxService
    {
        MessageBoxResult ShowMessageBox(string messageBoxText,
            string caption = null,
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None,
            MessageBoxResult defaultResult = MessageBoxResult.None);
    }
}