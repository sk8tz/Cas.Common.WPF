using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF.Test.ViewModel
{
    public static class Locator
    {
        public static readonly IMessageBoxService MessageBoxService = new MessageBoxService(ViewService.Instance);

        public static readonly IFileDialogService FileDialogService = new FileDialogService(ViewService.Instance);

        public static MainViewModel Main
        {
            get { return new MainViewModel(ViewService.Instance, MessageBoxService, FileDialogService);}
        }
    }
}
