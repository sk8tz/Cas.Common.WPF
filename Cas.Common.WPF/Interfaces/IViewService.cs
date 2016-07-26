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
        /// Add a registration.
        /// </summary>
        void AddRegistration(IViewRegistration registration);

        /// <summary>
        /// Removes a registration
        /// </summary>
        /// <param name="registration"></param>
        void RemoveRegistration(IViewRegistration registration);

    }
}