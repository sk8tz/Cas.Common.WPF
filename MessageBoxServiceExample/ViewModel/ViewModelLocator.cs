using System.Dynamic;
using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;

namespace MessageBoxServiceExample.ViewModel
{
    public static class ViewModelLocator
    {
        private static readonly IMessageBoxService MessageBoxService = new MessageBoxService();

        public static MainViewModel Main
        {
            get { return new MainViewModel(MessageBoxService); }
        }
    }
}