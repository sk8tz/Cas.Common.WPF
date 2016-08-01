using Cas.Common.WPF;

namespace TextEditServiceExample.ViewModel
{
    public static class ViewModelLocator
    {
        public static MainViewModel Main
        {
            get
            {
                var textEditService = new TextEditService();

                var main = new MainViewModel(textEditService)
                {
                    Text = "This is the text to edit"
                };

                return main;
            }
        }
    }
}