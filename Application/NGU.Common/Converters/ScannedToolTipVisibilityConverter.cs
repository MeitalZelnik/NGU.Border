using NGU.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NGU.Common.Converters
{
    public class ScannedToolTipVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //if (values == null)
            //    return Visibility.Collapsed; 

            //if (values[0] == null || values[1] == null)
            //    return Visibility.Collapsed;

            //string crsValue = values[0].ToString();
            //string formValue = values[1].ToString();

            //if (values[0].GetType() == typeof(DicSex) && values[1].GetType() == typeof(DicSex))
            //{
            //     crsValue = (values[0] as DicSex).Description;
            //     formValue =(values[1] as DicSex).Description;
            //}
            //if (values[0].GetType() == typeof(DateTime) && values[1].GetType() == typeof(DateTime))
            //{
            //    if ((DateTime)values[0]== default(DateTime) || (DateTime)values[1] == default(DateTime))
            //        return Visibility.Collapsed;
            //}

            //    if (crsValue.Equals(formValue))
            //    return Visibility.Collapsed;

           return Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
