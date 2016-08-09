using System.Windows;
using System.Windows.Controls;

namespace Cas.Common.WPF.Controls
{
    /// <summary>
    /// Provides a pasword box that can be bound to using MVVM.
    /// </summary>
    /// <remarks>
    /// http://stackoverflow.com/a/3214538/232566
    /// </remarks>
    public class BindablePasswordBox : Decorator
    {
        /// <summary>
        /// Password Dependency Property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty
            = DependencyProperty.Register("Password", typeof (string), typeof (BindablePasswordBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnDependencyPropertyChanged));

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private static void OnDependencyPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var p = source as BindablePasswordBox;
            if (p != null)
            {
                if (e.Property == PasswordProperty)
                {
                    var pb = p.Child as PasswordBox;
                    if (pb != null)
                    {
                        if (pb.Password != p.Password)
                            pb.Password = p.Password;
                    }
                }
            }
        }

        /// <summary>
        /// Creates an instance of of the BindablePasswordBox.
        /// </summary>
        public BindablePasswordBox()
        {
            Child = new PasswordBox();
            ((PasswordBox)Child).PasswordChanged += BindablePasswordBox_PasswordChanged;
            this.Focusable = true;
        }

        void BindablePasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = ((PasswordBox)Child).Password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            Child.Focus();
        }
    }
}
