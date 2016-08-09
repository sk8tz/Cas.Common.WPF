using System;
using System.Windows.Input;
using Cas.Common.WPF.Behaviors;
using GalaSoft.MvvmLight.CommandWpf;
using TextEditorApplication.Interfaces;

namespace TextEditorApplication.ViewModel
{
    public class AboutViewModel : IAboutViewModel
    {
        public AboutViewModel()
        {
            CloseCommand = new RelayCommand(OnClose);
        }

        public ICommand CloseCommand { get; }

        public Version Version
        {
            get { return typeof(AboutViewModel).Assembly.GetName().Version; }
        }

        private void OnClose()
        {
            Close?.Invoke(this, new CloseEventArgs(true));
        }

        public event EventHandler<CloseEventArgs> Close;

        public bool CanClose()
        {
            return true;
        }

        public void Closed()
        {
        }
    }
}