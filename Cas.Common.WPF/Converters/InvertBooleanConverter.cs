using System;
using System.Windows.Data;

namespace Cas.Common.WPF.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool) value;
        }
    }
}
