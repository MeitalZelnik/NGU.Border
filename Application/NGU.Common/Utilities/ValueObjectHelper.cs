using NGU.Core;
using NGU.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using Admin = NGU.Interfaces.ApiAdmin;

namespace NGU.Common.Utilities
{
    public static class ValueObjectHelper
    {
        #region members

        private static IList<Admin.Sex> _allGenders;

        #endregion

        #region props

        public static IValueObjectService ValueObjectService
        {
            get
            {
                return ServicesInstances.ValueObjectService;
            }
        }

        //public static IList<Admin.Sex> AllSexTypes
        //{
        //    get
        //    {
        //        if (_allGenders == null)
        //            _allGenders = ValueObjectService.GetSexTypes().ToList();
                
        //        return _allGenders;
        //    }
        //}
    }

    #endregion
}
