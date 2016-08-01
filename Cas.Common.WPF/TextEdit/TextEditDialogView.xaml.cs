using System.Windows;

namespace Cas.Common.WPF.TextEdit
{
    /// <summary>
    /// Interaction logic for RenameDialogView.xaml
    /// </summary>
    internal partial class TextEditDialogView
    {
        public TextEditDialogView()
        {
            InitializeComponent();
        }

        private void TextEditDialogView_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextTextBox.Focus();
        }
    }
}
