using NGU.Core;
using NGU.Interfaces.ApiAdmin;
using Pangea.Network.NetDataContract;
using System.Collections.Generic;
using System.ServiceModel;
using Languages = Pangea.MultiLanguage.Languages;


namespace NGU.Interfaces.Services
{
    [ServiceContract]
    //[XmlSerializerFormat]
    public interface IUserService : IBaseService
    {
        /// <summary>
        /// Check the validity of the user name and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="getMenus">if true returns the menus in the LoggedUser object</param>
        /// <returns></returns>
        [OperationContract]
        [UseNetDataContractSerializer]
        UserValidation CheckUserValidityWithPassword(string username, string password, bool getMenus, Languages moduleLanguage);

        [OperationContract]
        [UseNetDataContractSerializer]
        UserValidation UpdateUserPassWord(string username, string currentPassword, string newPassword, Languages moduleLanguage);
    }
}