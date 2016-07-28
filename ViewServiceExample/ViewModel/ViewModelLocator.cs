using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;
using ViewServiceExample.View;

namespace ViewServiceExample.ViewModel
{
    public static class ViewModelLocator
    {
        public static MainViewModel Main
        {
            get
            {
                //Create the view service
                IViewService viewService = new ViewService();

                //Register the viewmodels with their views.
                viewService.Register<EditTextViewModel, EditTextView>();
                viewService.Register<DisplayTextViewModel, DisplayTextView>();

                return new MainViewModel(viewService); 
            }
        }
    }
}