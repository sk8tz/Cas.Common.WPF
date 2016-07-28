using System;
using System.Windows;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
    /// <summary>
    /// Extensions for the IViewService interface.
    /// </summary>
    public static class IViewServiceExtensions
    {
        /// <summary>
        /// Register a view type with the view service.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        /// <param name="viewService"></param>
        /// <returns></returns>
        public static IViewRegistration Register<TViewModel, TView>(this IViewService viewService)
            where TView : Window, new()
        {
            if (viewService == null) throw new ArgumentNullException(nameof(viewService));

            //Create the registration
            var registration = new ViewRegistration(typeof(TViewModel), () => new TView());

            //Add the registration
            viewService.AddRegistration(registration);

            //Return it in case it's needed (most of the time it won't be).
            return registration;
        }

        /// <summary>
        /// Registers a viewmodel type with a view factory.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TView"></typeparam>
        /// <param name="viewService"></param>
        /// <param name="viewFactory"></param>
        /// <returns></returns>
        public static IViewRegistration Register<TViewModel, TView>(this IViewService viewService,
            Func<TView> viewFactory)
            where TView : Window
        {
            if (viewService == null) throw new ArgumentNullException(nameof(viewService));
            if (viewFactory == null) throw new ArgumentNullException(nameof(viewFactory));

            //Create the registration
            var registration = new ViewRegistration(typeof(TViewModel), viewFactory);

            //Add the registration
            viewService.AddRegistration(registration);

            //Return it in case it's needed (most of the time it won't be).
            return registration;
        }

        /// <summary>
        /// Reigsters a viewmodel type with a view factory.
        /// </summary>
        /// <param name="viewService"></param>
        /// <param name="viewModelType"></param>
        /// <param name="viewFactory"></param>
        /// <returns></returns>
        public static IViewRegistration Register(this IViewService viewService, Type viewModelType,
            Func<Window> viewFactory)
        {
            if (viewService == null) throw new ArgumentNullException(nameof(viewService));
            if (viewModelType == null) throw new ArgumentNullException(nameof(viewModelType));
            if (viewFactory == null) throw new ArgumentNullException(nameof(viewFactory));

            //Create the registration
            var registration = new ViewRegistration(viewModelType, viewFactory);

            //Add the registration
            viewService.AddRegistration(registration);

            //Return it in case it's needed (most of the time it won't be).
            return registration;
        }
    }
}