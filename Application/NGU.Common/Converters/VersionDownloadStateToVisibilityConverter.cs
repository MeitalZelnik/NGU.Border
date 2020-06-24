using NGU.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NGU.Common.Converters
{
    public class VersionDownloadStateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VersionDownloadStates state = (VersionDownloadStates)value;

            if (state == null)
                return Visibility.Collapsed;


            if (parameter.ToString().Equals("BeforeDownloading") && ((VersionDownloadStates)value == VersionDownloadStates.BeforeDownloading))
                return Visibility.Visible;
            if (parameter.ToString().Equals("Downloading") && ((VersionDownloadStates)value == VersionDownloadStates.Downloading))
                return Visibility.Visible;
            if (parameter.ToString().Equals("DownloadSucceed") && ((VersionDownloadStates)value == VersionDownloadStates.DownloadSucceed))
                return Visibility.Visible;
            if (parameter.ToString().Equals("DownloadFailed") && ((VersionDownloadStates)value == VersionDownloadStates.DownloadFailed))
                return Visibility.Visible;
            if (parameter.ToString().Equals("DownloadSucceed|DownloadFailed") && (((VersionDownloadStates)value == VersionDownloadStates.DownloadFailed) || ((VersionDownloadStates)value == VersionDownloadStates.DownloadSucceed)))
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
