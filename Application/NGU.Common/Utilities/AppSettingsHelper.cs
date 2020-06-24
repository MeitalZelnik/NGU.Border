using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.ApiAdmin;
using Pangea.BaseStructures;
using Pangea.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NGU.Common.Utilities
{
    public static class AppSettingsHelper
    {
        #region members & consts

        const string _KEY = "kushkush";
        private static bool? _checkMoreThenOneProcessOpen = null;
        private static string _adminApiPath;

        #endregion

        #region props

        public static User LoggedUser { get; set; }

        public static string Key
        {
            get
            {
                return _KEY;
            }
        }

        public static bool CheckMoreThenOneProcessOpen
        {
            get
            {
                if (_checkMoreThenOneProcessOpen == null)
                {
                    bool tmp = false;
                    object objIsTestMode = ConfigurationManager.AppSettings["CheckMoreThenOneProcessOpen"];

                    if (objIsTestMode == null)
                    {
                        _checkMoreThenOneProcessOpen = false;
                    }
                    else if (objIsTestMode.ToString().Upper() == YesNo.Yes.GetStringValue())
                    {
                        _checkMoreThenOneProcessOpen = true;
                    }
                    else
                    {
                        if (objIsTestMode != null)
                            bool.TryParse(objIsTestMode.ToString(), out tmp);

                        _checkMoreThenOneProcessOpen = tmp;
                    }
                }

                return _checkMoreThenOneProcessOpen.Value;
            }

        }

        public static string AdminApiPath
        {
            get
            {
                if (_adminApiPath.IsNullOrEmpty())
                    _adminApiPath = ConfigurationManager.AppSettings["AdminApiPath"];

                return _adminApiPath;
            }
        }

        #endregion

        #region method
        
        public static bool IsTestMode()
        {
            //todo: develop hot keys
            return true;
        }
        
        #endregion
    }

}
