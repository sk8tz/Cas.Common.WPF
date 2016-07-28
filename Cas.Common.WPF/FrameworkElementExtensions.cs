using System;
using System.Windows;

namespace Cas.Common.WPF
{
    /// <summary>
    /// Extensions for FrameworkElements.
    /// </summary>
    public static class FrameworkElementExtensions
    {
        
        private static TViewModel GetViewModel<TViewModel>(this FrameworkElement frameworkElement)
            where TViewModel : class
        {
            var viewModel = frameworkElement.DataContext as TViewModel;

            if (viewModel == null)
                throw new ViewModelException("Unable to get view model.");

            return viewModel;
        }

        /// <summary>
        /// Performs an action on the view model bound to the element's DataContext property.
        /// </summary>
        /// <param name="frameworkElement"></param>
        /// <param name="action"></param>
        /// <typeparam name="TViewModel"></typeparam>
        public static void PerformViewModelAction<TViewModel>(this FrameworkElement frameworkElement, Action<TViewModel> action) 
            where TViewModel : class
        {
            if (frameworkElement == null) throw new ArgumentNullException(nameof(frameworkElement));
            if (action == null) throw new ArgumentNullException(nameof(action));

            var viewModel = frameworkElement.GetViewModel<TViewModel>();

            action(viewModel);
        }

        /// <summary>
        /// Performs a func on the view model bound to the element's DataContext property.
        /// </summary>
        /// <param name="frameworkElement"></param>
        /// <param name="func"></param>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        public static TResult PerformViewModelFunc<TViewModel, TResult>(this FrameworkElement frameworkElement, Func<TViewModel, TResult> func)
            where TViewModel : class
        {
            if (frameworkElement == null) throw new ArgumentNullException(nameof(frameworkElement));
            if (func == null) throw new ArgumentNullException(nameof(func));

            var viewModel = frameworkElement.GetViewModel<TViewModel>();

            return func(viewModel);
        }
    }
}
