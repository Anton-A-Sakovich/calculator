using System;
using System.Globalization;
using System.Windows.Data;

namespace BinaryCalculator.Wpf
{
    public class BaseFormValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int number && targetType == typeof(string))
            {

                return System.Convert.ToString(number, 2);
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
