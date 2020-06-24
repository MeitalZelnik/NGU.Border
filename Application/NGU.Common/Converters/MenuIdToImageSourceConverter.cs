using NGU.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using Pangea.Extensions;

namespace NGU.Common.Converters
{
    public class MenuIdToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var menu = value.ToString().ToEnum<ViewModelTypes>();
                
                string name = menu.GetResourceKey();
                name = name + "ForComments";
                return System.Windows.Application.Current.TryFindResource(name);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
