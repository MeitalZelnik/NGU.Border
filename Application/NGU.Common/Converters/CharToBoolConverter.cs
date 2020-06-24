using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NGU.Common.Converters
{
   public class CharToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return false;
            char ch = (char)value;

            if (ch == 'T')
                return true;
            else
                return false;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return false;
            bool b = (bool)value;

            if (b)
                return "T";
            else
                return "F";
        }
    }
}
