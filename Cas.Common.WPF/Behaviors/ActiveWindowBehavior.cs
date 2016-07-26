using System.Windows;
using System.Windows.Interactivity;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF.Behaviors
{
    /// <summary>
    /// In the case that inheriting from WindowBase is not desierable, or an alternative instance of IViewService
    /// is desired, this behavior can be used.
    /// </summary>
    public class ActiveWindowBehavior : Behavior<Window>
    {
        public static readonly DependencyProperty ViewServiceProperty =
            DependencyProperty.Register("ViewService", typeof (IViewService), typeof (ActiveWindowBehavior),
                new PropertyMetadata(WPF.ViewService.Instance));

        public IViewService ViewService
        {
            get { return (IViewService)GetValue(ViewServiceProperty); }
            set { SetValue(ViewServiceProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Activated += AssociatedObject_Activated;
        }

        private void AssociatedObject_Activated(object sender, System.EventArgs e)
        {
            ViewService?.SetActiveWindow(AssociatedObject);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Activated -= AssociatedObject_Activated;
        }
    }
}