using NGU.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using NGU.Core;
using NGU.Enums;
using Pangea.Extensions;
using NGU.Interfaces.Repositories;
using NGU.Lang;
using NGU.Common.Utilities;
using Pangea.Utils.Encryption;
using System.ServiceModel;
using System.Reflection;
using System.Configuration;
using System.Xml.Serialization;
using NGU.Interfaces.ApiAdmin;
using Pangea.Logger;
using Languages = Pangea.MultiLanguage.Languages;

namespace NGU.Services
{
    [System.ServiceModel.ServiceBehavior(ConcurrencyMode = System.ServiceModel.ConcurrencyMode.Multiple, InstanceContextMode = System.ServiceModel.InstanceContextMode.Single)]
    public class UserService : BaseService, IUserService
    {
        #region private members


        #endregion

        #region props

        #endregion

        #region methods from Admin API

        public UserValidation CheckUserValidityWithPassword(string username, string password, bool getMenus, Languages moduleLanguage)
        {
            try
            {
                UserValidation apiDto = APIAdmin.CheckUserValidityWithPassword(username, password, moduleLanguage, ModuleTypes.Identification);

                return apiDto;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }
        
        public UserValidation UpdateUserPassWord(string username, string currentPassword, string newPassword, Languages moduleLanguage)
        {
            try
            {
                UserValidation apiDto = APIAdmin.UpdateUserPassword(username, currentPassword, newPassword, moduleLanguage, ModuleTypes.Identification);
                return apiDto;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }

        #endregion

        #region methods (Black List locally)

        #endregion
    }
}
