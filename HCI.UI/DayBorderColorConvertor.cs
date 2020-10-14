using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;

namespace HCI.UI.Converters
{
    public class DayBorderColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            

            if ((bool)value)return new LinearGradientBrush(Color.FromRgb(220, 74, 56), Color.FromRgb(198, 56, 40), new Point(0.5, 0), new Point(0.5, 1));

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
