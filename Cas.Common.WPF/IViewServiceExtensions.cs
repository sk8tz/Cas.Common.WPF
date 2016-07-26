using System;
using System.Windows;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
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