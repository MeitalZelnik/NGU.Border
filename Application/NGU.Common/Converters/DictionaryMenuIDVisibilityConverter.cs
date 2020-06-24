using NGU.Enums;
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
    public class DictionaryMenuIDVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ViewModelTypes scanFormType = (ViewModelTypes)value;

            //if((scanFormType == ViewModelTypes.SupportingDocuments) && parameter.ToString().Equals("SupportingDocuments"))
            //    return Visibility.Visible;
            //if ((scanFormType == ViewModelTypes.LicenseTypes) && parameter.ToString().Equals("LicenseTypes"))
            //    return Visibility.Visible;
            //if ((scanFormType == ViewModelTypes.Relationship) && parameter.ToString().Equals("Relationship"))
            //    return Visibility.Visible;
            //if ((scanFormType == ViewModelTypes.SystemSettings) && parameter.ToString().Equals("SystemSettings"))
            //    return Visibility.Visible;
            //if ((scanFormType == ViewModelTypes.VehicleRestriction) && parameter.ToString().Equals("VehicleRestriction"))
            //    return Visibility.Visible;
            //if ((scanFormType == ViewModelTypes.PersonalRestriction) && parameter.ToString().Equals("PersonalRestriction"))
            //    return Visibility.Visible;
            //if ((scanFormType == ViewModelTypes.Nationality) && parameter.ToString().Equals("Nationality"))
            //    return Visibility.Visible;
            //if ((scanFormType == ViewModelTypes.Location) && parameter.ToString().Equals("Location"))
            //    return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
