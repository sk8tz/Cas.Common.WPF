using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Cas.Common.WPF.Behaviors
{
    /// <summary>
    /// Selects all text when the textbox receives focus.
    /// </summary>
    public class SelectAllOnFocusBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
        }
        
        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
        }

        private void AssociatedObject_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            AssociatedObject.SelectAll();
        }
    }
}