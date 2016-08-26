using Autofac;

namespace TextEditorApplication.ViewModel
{
    public static class ViewModelLocator
    {
        public static MainViewModel Main
        {
            get { return ApplicationContainer.Instance.Resolve<MainViewModel>(); }
        }
    }
}