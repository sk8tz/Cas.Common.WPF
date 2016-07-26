using System;
using System.Windows;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
    public class WindowBase : Window
    {
        protected override void OnActivated(EventArgs e)
        {
            ViewService.SetActiveWindow(this);

            base.OnActivated(e);
        }

        public virtual IViewService ViewService
        {
            get { return WPF.ViewService.Instance; }
        }
    }
}