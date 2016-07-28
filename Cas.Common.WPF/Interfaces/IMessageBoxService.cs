using System.Windows;

namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// A mockable interface for displaying standard windows message boxes.
    /// </summary>
    public interface IMessageBoxService
    {
        MessageBoxResult Show(string messageBoxText,
            string caption = null,
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.None,
            MessageBoxResult defaultResult = MessageBoxResult.None);
    }
}