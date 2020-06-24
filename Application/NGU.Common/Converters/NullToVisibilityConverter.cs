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
    public class NullToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            Type type = null;
            if (value != null)
                type = value.GetType();

            if (type == typeof(String))
            {

                if ((parameter != null) &&
                    (parameter is string) &&
                    (parameter.ToString().Upper() == "NOT"))
                    return !string.IsNullOrEmpty(value.ToString()) ? Visibility.Collapsed : Visibility.Visible;
                else
                    return string.IsNullOrEmpty(value.ToString()) ? Visibility.Collapsed : Visibility.Visible;
            }
            else if (type == typeof(char))
            {
                if ((parameter != null) && (parameter is string) && (parameter.ToString().Upper() == "NOT"))
                    return (char)value == '\0' ? Visibility.Collapsed : Visibility.Visible;
                else
                    return (char)value == '\0' ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                if ((parameter != null) &&
                    (parameter is string) &&
                    (parameter.ToString().Upper() == "NOT"))
                    return value != null ? Visibility.Collapsed : Visibility.Visible;
                else
                    return value == null ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
