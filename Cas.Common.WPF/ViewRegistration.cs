using System;
using System.Windows;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
    /// <summary>
    /// This is internal so that callers are encouraged to use the extension methods (e.g. Register).
    /// </summary>
    internal class ViewRegistration : IViewRegistration
    {
        private readonly Type _viewModelType;
        private readonly Func<Window> _windowFactory;

        internal ViewRegistration(Type viewModelType, Func<Window> windowFactory)
        {
            if (viewModelType == null) throw new ArgumentNullException(nameof(viewModelType));
            if (windowFactory == null) throw new ArgumentNullException(nameof(windowFactory));

            _viewModelType = viewModelType;
            _windowFactory = windowFactory;
        }

        public Type ViewModelType
        {
            get { return _viewModelType; }
        }

        public Window CreateView()
        {
            return _windowFactory();
        }
    }
}