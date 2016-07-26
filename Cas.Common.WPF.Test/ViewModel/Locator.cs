using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF.Test.ViewModel
{
    public static class Locator
    {
        public static readonly IMessageBoxService MessageBoxService = new MessageBoxService();

        public static readonly IFileDialogService FileDialogService = new FileDialogService();

        public static MainViewModel Main
        {
            get { return new MainViewModel(ViewService.Instance, MessageBoxService, FileDialogService);}
        }
    }
}
