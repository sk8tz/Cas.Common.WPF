using System.Windows;

namespace PerformViewModelExample.ViewModel
{
    public class MainViewModel
    {
        public string Text
        {
            get { return "Hello"; }
        }

        public void DisplayMessage()
        {
            MessageBox.Show("Hello!");
        }
    }
}