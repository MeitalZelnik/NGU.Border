using System.Collections.Generic;
using System.ServiceModel;
using NGU.Core;
using Pangea.Network.NetDataContract;
using NGU.Interfaces.ApiAdmin;
using NGU.Core.DTO;
using Pangea.MultiLanguage;
using Languages = Pangea.MultiLanguage.Languages;

namespace NGU.Interfaces.Services
{
    [ServiceContract]
    public interface IValueObjectService : IBaseService
    {
        #region methods from Admin API

        [UseNetDataContractSerializer]
        [OperationContract]
        IList<Sex> GetGenders(Languages lang);

        [UseNetDataContractSerializer]
        [OperationContract]
        IList<SystemParameter> GetSystemParameters();

        [UseNetDataContractSerializer]
        [OperationContract]
        IList<Country> GetCountries(Languages lang);

        [UseNetDataContractSerializer]
        [OperationContract]
        IList<IdenType> GetIdenTypes(Languages lang);

        #endregion

        #region methods (Identity locally)

        [OperationContract]
        IList<ImageType> GetImageTypes(Languages lang);

        [OperationContract]
        IList<RequestType> GetRequestTypes(Languages lang);

        [OperationContract]
        IList<RequestStatus> GetRequestStatuses(Languages lang);

        [OperationContract]
        IList<RequestReason> GetRequestReasons(Languages lang);

        [OperationContract]
        IList<RequestSubType> GetRequestSubTypes(Languages lang);
        #endregion
    }
}
