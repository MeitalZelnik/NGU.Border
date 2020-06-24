using Pangea.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NGU.Common.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;

            bool input = (bool)value;
            if (input == true)
                return Visibility.Visible;
            else
            {
                if (parameter != null)
                {
                    if (parameter.ToString().Upper() == "HIDDEN")
                        return Visibility.Hidden;
                }
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToNegativeVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;

            bool input = (bool)value;
            if (input == true)
            {
                if (parameter != null)
                {
                    if (parameter.ToString().Upper() == "HIDDEN")
                        return Visibility.Hidden;
                    else return Visibility.Collapsed;
                }
                else return Visibility.Collapsed;
            }
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
