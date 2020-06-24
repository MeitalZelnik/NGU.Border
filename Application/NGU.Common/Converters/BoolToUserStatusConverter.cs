using NGU.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NGU.Common.Converters
{
    public class BoolToUserStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            UserStatuses val = (UserStatuses)value;

            switch (val)
            {
                case UserStatuses.Active:
                    return true;
                case UserStatuses.Passive:
                    return false;
                default:
                    return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return UserStatuses.Active;

            return UserStatuses.Passive;
        }
    }
}
