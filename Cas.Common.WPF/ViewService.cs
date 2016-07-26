using System;
using System.Collections.Generic;
using System.Windows;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
    public class ViewService : IViewService
    {
        private readonly Dictionary<Type, IViewRegistration> _registrations = new Dictionary<Type, IViewRegistration>();
        private Window _currentWindow;

        /// <summary>
        /// Singleton instance of the view service.
        /// </summary>
        public static readonly IViewService Instance = new ViewService();

        private IViewRegistration GetRegistration(Type viewModelType)
        {
            if (viewModelType == null) throw new ArgumentNullException(nameof(viewModelType));

            IViewRegistration registration;

            if (_registrations.TryGetValue(viewModelType, out registration))
            {
                return registration;
            }

            foreach (var pair in _registrations)
            {
                if (pair.Key.IsAssignableFrom(viewModelType))
                {
                    return pair.Value;
                }
            }

            throw new InvalidOperationException($"Unable to find a View registration for view model with type '{viewModelType.Name}'.");
        }

        private Window CreateView<TViewModel>(TViewModel viewModel)
        {
            IViewRegistration registration = GetRegistration(typeof (TViewModel));
           
            var window = registration.CreateView();

            window.DataContext = viewModel;
            window.Owner = _currentWindow;

            return window;
        }

        public bool? ShowDialog<TViewModel>(TViewModel viewModel)
        {
            var window = CreateView(viewModel);

            return window.ShowDialog();
        }

        public void Show<TViewModel>(TViewModel viewModel)
        {
            var window = CreateView(viewModel);

            window.Show();
        }

        public void SetActiveWindow(Window window)
        {
            _currentWindow = window;
        }

        public void AddRegistration(IViewRegistration registration)
        {
            if (registration == null) throw new ArgumentNullException(nameof(registration));

            _registrations.Add(registration.ViewModelType, registration);
        }

        public Window ActiveWindow
        {
            get { return _currentWindow; }
        }
    }
}