using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Cas.Common.WPF.Test.View;
using Cas.Common.WPF.Test.ViewModel;

namespace Cas.Common.WPF.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ViewService.Instance.Register<SampleDialogViewModel, SampleDialog>();
        }
    }
}
