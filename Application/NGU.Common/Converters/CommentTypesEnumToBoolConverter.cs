using NGU.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NGU.Common.Converters
{
    public class CommentTypesEnumToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            if (parameter.ToString().Equals("Comments") && ((CommentTypes)value == CommentTypes.Comments))
                return true;
            if (parameter.ToString().Equals("Log") && ((CommentTypes)value == CommentTypes.Log))
                return true;
            if (parameter.ToString().Equals("Both") && ((CommentTypes)value == CommentTypes.Both))
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter.ToString().Equals("Comments") && ((bool)value == true))
                return CommentTypes.Comments;
            if (parameter.ToString().Equals("Log") && ((bool)value == true))
                return CommentTypes.Log;
            if (parameter.ToString().Equals("Both") && ((bool)value == true))
                return CommentTypes.Both;


            return CommentTypes.Both;
        }
    }
}
