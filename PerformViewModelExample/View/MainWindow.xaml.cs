using System.Windows;
using Cas.Common.WPF;
using PerformViewModelExample.ViewModel;

namespace PerformViewModelExample.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PerformActionButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.PerformViewModelAction<MainViewModel>(vm => vm.DisplayMessage());
        }

        private void PerformFuncButton_OnClick(object sender, RoutedEventArgs e)
        {
            var message = this.PerformViewModelFunc<MainViewModel, string>(vm => vm.Text);

            MessageBox.Show($"Got '{message}' from the view model.");
        }
    }
}
