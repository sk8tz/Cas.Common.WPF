using System;
using System.Windows;
using System.Windows.Input;

namespace Cas.Common.WPF.ExtensionProperties
{
    /// <summary>
    /// Provides a way to set focus via binding from a ViewModel.
    /// </summary>
    public static class FocusExtension
    {
        /// <summary>
        /// Gets the value of the IsFocused property.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFocusedProperty);
        }

        /// <summary>
        /// Sets the value of the IsFocused property.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }

        /// <summary>
        /// Dependency Property.
        /// </summary>
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
             "IsFocused", typeof(bool), typeof(FocusExtension),
             new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));


        private static void OnIsFocusedPropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var uie = (UIElement)d;
            if ((bool)e.NewValue)
            {
                uie.Focus(); // Don't care about false values.

                try
                {
                    Keyboard.Focus(uie);
                }
                catch (Exception)
                {
                }                
            }
        }
    }
}
