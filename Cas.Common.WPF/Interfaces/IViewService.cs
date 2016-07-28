using System.Windows;

namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// Lightweight framework for MVVM View creation.
    /// </summary>
    public interface IViewService
    {
        /// <summary>
        /// Shows a modal dialog.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        bool? ShowDialog<TViewModel>(TViewModel viewModel);

        /// <summary>
        /// Shows a non modal window.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        void Show<TViewModel>(TViewModel viewModel);

        /// <summary>
        /// Add a registration.
        /// </summary>
        void AddRegistration(IViewRegistration registration);

        /// <summary>
        /// Removes a registration.
        /// </summary>
        /// <param name="registration"></param>
        void RemoveRegistration(IViewRegistration registration);
    }
}