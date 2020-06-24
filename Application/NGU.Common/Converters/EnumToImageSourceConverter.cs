using NGU.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace NGU.Common.Converters
{
    public class EnumToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource source = null;

            if (value == null)
                return "";

            if (!(value is Enum))
                return "";

            if (parameter == null)
                return "";

            string strParameter = parameter.ToString();

            if (value is MenuStatusTypes)
            {
                if (strParameter == "MenuStatus")
                {
                    MenuStatusTypes status = (MenuStatusTypes)value;

                    if (status == MenuStatusTypes.NotValid)
                        source = Application.Current.Resources["WarningIcon"] as ImageSource;
                    //if (status == MenuStatusTypes.OK)
                    //    source = Application.Current.Resources["CheckIcon"] as ImageSource;
                    if (status == MenuStatusTypes.Visited)
                        source = Application.Current.Resources["CheckIcon"] as ImageSource;

                }
            }

            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
