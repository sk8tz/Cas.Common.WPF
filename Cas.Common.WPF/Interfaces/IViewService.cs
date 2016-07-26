using System.Windows;

namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IViewService
    {
        /// <summary>
        /// Shows a dialog.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        bool? ShowDialog<TViewModel>(TViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        void Show<TViewModel>(TViewModel viewModel);

        /// <summary>
        /// The curently active window sets this.
        /// </summary>
        /// <param name="window"></param>
        void SetActiveWindow(Window window);

        /// <summary>
        /// Add a registration.
        /// </summary>
        void AddRegistration(IViewRegistration registration);

        /// <summary>
        /// Gets the active window
        /// </summary>
        Window ActiveWindow { get; }
    }
}