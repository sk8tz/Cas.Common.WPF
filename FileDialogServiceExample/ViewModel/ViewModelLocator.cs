using System.Dynamic;
using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;

namespace FileDialogServiceExample.ViewModel
{
    public static class ViewModelLocator
    {
        private static readonly IFileDialogService FileDialogService = new FileDialogService();

        public static MainViewModel Main
        {
            get { return new MainViewModel(FileDialogService); }
        }
    }
}