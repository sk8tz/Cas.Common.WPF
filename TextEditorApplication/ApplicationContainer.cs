using Autofac;
using Cas.Common.WPF;
using Cas.Common.WPF.Interfaces;
using TextEditorApplication.Interfaces;
using TextEditorApplication.View;
using TextEditorApplication.ViewModel;

namespace TextEditorApplication
{
    public static class ApplicationContainer
    {
        private static readonly IContainer _instance;

        static ApplicationContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<MessageBoxService>().As<IMessageBoxService>().SingleInstance();
            builder.RegisterType<FileDialogService>().As<IFileDialogService>().SingleInstance();
            builder.RegisterType<AboutViewModel>().As<IAboutViewModel>();

            //ViewService
            var viewService = new ViewService();

            viewService.Register<IAboutViewModel, AboutView>();

            builder.RegisterInstance(viewService).As<IViewService>();

            //DirtyService
            builder.RegisterType<DirtyService>()
                .As<IDirtyService>()
                .As<IMarkClean>()
                .As<IMarkClean>()
                .SingleInstance();

            _instance = builder.Build();
        }

        public static IContainer Instance
        {
            get { return _instance; }
        }  

    }
}