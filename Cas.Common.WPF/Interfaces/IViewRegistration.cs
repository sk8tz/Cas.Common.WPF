using System;
using System.Windows;

namespace Cas.Common.WPF.Interfaces
{
    /// <summary>
    /// A registration for a view
    /// </summary>
    public interface IViewRegistration
    {
        /// <summary>
        /// The type of view model.
        /// </summary>
        Type ViewModelType { get; }

        /// <summary>
        /// Create the view
        /// </summary>
        /// <returns></returns>
        Window CreateView();
    }
}