using System.Linq;
using System.Windows;

namespace Cas.Common.WPF
{
    public static class WindowUtil
    {
        //http://stackoverflow.com/questions/2038879/refer-to-active-window-in-wpf

        public static Window GetActiveWindow()
        {
            return Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(x => x.IsActive);
        }
    }
}