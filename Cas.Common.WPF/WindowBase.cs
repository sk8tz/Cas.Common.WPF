using System;
using System.Windows;
using Cas.Common.WPF.Interfaces;

namespace Cas.Common.WPF
{
    public class WindowBase : Window
    {

        private IViewService _viewService;

        protected override void OnActivated(EventArgs e)
        {
            ViewService.SetActiveWindow(this);

            base.OnActivated(e);
        }

        public virtual IViewService ViewService
        {
            get
            {
                if (_viewService != null)
                {
                    return _viewService;
                }

                return WPF.ViewService.Instance;
            }
            set { _viewService = value; }
        }
    }
}