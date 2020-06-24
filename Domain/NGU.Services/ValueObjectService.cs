using NGU.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using NGU.Core;
using NGU.Interfaces.Repositories;
using NGU.Interfaces.ApiAdmin;
using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Pangea.Logger;
using NGU.Core.DTO;
using Languages = Pangea.MultiLanguage.Languages;
using System.Reflection;
using Pangea.MultiLanguage;
using Pangea.Utils;

namespace NGU.Services
{
    [System.ServiceModel.ServiceBehavior(ConcurrencyMode = System.ServiceModel.ConcurrencyMode.Multiple, InstanceContextMode = System.ServiceModel.InstanceContextMode.Single)]
    public class ValueObjectService : BaseService, IValueObjectService
    {
        #region  private members

        private IBaseRepository _baseRepository;

        #endregion

        #region ctor

        public ValueObjectService() : base()
        {
            MultiLanguageExtension.Initialize(typeof(Core.LocalizedNames));
        }

        #endregion

        #region props

        public IBaseRepository BaseRepository
        {
            get
            {
                if (_baseRepository == null)
                    _baseRepository = Pangea.IoC.Instance.Resolve<IBaseRepository>();

                return _baseRepository;
            }
        }

        #endregion

        #region methods from Admin API

        public IList<SystemParameter> GetSystemParameters()
        {
            return APIAdmin.GetSystemParameters();
        }

        public IList<Sex> GetGenders(Languages lang)
        {
            return APIAdmin.GetGenders(lang);
        }

        public IList<Country> GetCountries(Languages lang)
        {
            return APIAdmin.GetCountries(lang);
        }

        public IList<IdenType> GetIdenTypes(Languages lang)
        {
            return APIAdmin.GetIdenTypes(lang);
        }

        #endregion

        #region methods (Identity locally)

        public IList<ImageType> GetImageTypes(Languages lang)
        {
            ImageType[] dbImageTypes = BaseRepository.FindAll<ImageType>().ToArray();
            dbImageTypes.SetDescription(lang);
            return dbImageTypes;
        }

        public IList<RequestType> GetRequestTypes(Languages lang)
        {
            RequestType[] dbRequestTypes = BaseRepository.FindAll<RequestType>().ToArray();
            dbRequestTypes.SetDescription(lang);
            return dbRequestTypes;
        }

        public IList<RequestSubType> GetRequestSubTypes(Languages lang)
        {
            RequestSubType[] dbRequestTypes = BaseRepository.FindAll<RequestSubType>().ToArray();
            dbRequestTypes.SetDescription(lang);
            return dbRequestTypes;
        }

        public IList<RequestStatus> GetRequestStatuses(Languages lang)
        {
            RequestStatus[] dbRequestStatuses = BaseRepository.FindAll<RequestStatus>().ToArray();
            dbRequestStatuses.SetDescription(lang);
            return dbRequestStatuses;
        }

        public IList<RequestReason> GetRequestReasons(Languages lang)
        {
            RequestReason[] dbReasons = BaseRepository.FindAll<RequestReason>().ToArray();
            dbReasons.SetDescription(lang);
            return dbReasons;
        }

        #endregion
    }
}