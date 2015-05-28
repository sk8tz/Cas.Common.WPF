using System;
using System.Windows;

namespace Cas.Common.WPF
{
    /// <summary>
    /// 
    /// </summary>
    public static class FrameworkElementExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameworkElement"></param>
        /// <param name="action"></param>
        /// <typeparam name="TViewModel"></typeparam>
        public static void PerformViewModelAction<TViewModel>(this FrameworkElement frameworkElement, Action<TViewModel> action) 
            where TViewModel : class
        {
            var viewModel = frameworkElement.DataContext as TViewModel;

            if (viewModel == null)
                throw new ApplicationException("Unable to get view model.");

            action(viewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameworkElement"></param>
        /// <param name="func"></param>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        public static TResult PerformViewModelFunc<TViewModel, TResult>(this FrameworkElement frameworkElement, Func<TViewModel, TResult> func)
            where TViewModel : class
        {
            var viewModel = frameworkElement.DataContext as TViewModel;

            if (viewModel == null)
                throw new ApplicationException("Unable to get view model.");

            return func(viewModel);
        }
    }
}
