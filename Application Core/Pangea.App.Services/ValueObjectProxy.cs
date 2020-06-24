using NGU.Core;
using NGU.Interfaces.ApiAdmin;
using Pangea.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangea.App.Services
{
    public class ValueObjectProxy
    {
        #region privates
        private static ValueObjectProxy _instance;

        private IList<ImageType> _imageTypes;
        private IList<RequestType> _requestTypes;
        private IList<RequestStatus> _requestStatuses;
        private IList<RequestReason> _requestReasons;
        private IList<RequestSubType> _requestSubTypes;
        // admin types
        private IList<SystemParameter> _systemParameters;
        private IList<Sex> _sexTypes;
        private IList<Country> _countries;
        private IList<IdenType> _idenTypes;
        #endregion

        public static ValueObjectProxy Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ValueObjectProxy();
                return _instance;
            }
        }

        public static void ResetProxy()
        {
            _instance = null;
        }

        public IList<ImageType> ImageTypes
        {
            get
            {
                if (_imageTypes == null)
                    _imageTypes = Channels.ValueObjectService.GetImageTypes(Language.SystemLanguage);
                return _imageTypes;
            }
        }

        public IList<RequestType> RequestTypes
        {
            get
            {
                if (_requestTypes == null)
                    _requestTypes = Channels.ValueObjectService.GetRequestTypes(Language.SystemLanguage);
                return _requestTypes;
            }
        }

        public IList<RequestSubType> RequestSubTypes
        {
            get
            {
                if (_requestSubTypes == null)
                    _requestSubTypes = Channels.ValueObjectService.GetRequestSubTypes(Language.SystemLanguage);
                return _requestSubTypes;
            }
        }

        public IList<RequestStatus> RequestStatuses
        {
            get
            {
                if (_requestStatuses == null)
                    _requestStatuses = Channels.ValueObjectService.GetRequestStatuses(Language.SystemLanguage);
                return _requestStatuses;
            }
        }

        public IList<RequestReason> RequestReasons
        {
            get
            {
                if (_requestReasons == null)
                    _requestReasons = Channels.ValueObjectService.GetRequestReasons(Language.SystemLanguage);
                return _requestReasons;
            }
        }

        public IList<SystemParameter> SystemParameters
        {
            get
            {
                if (_systemParameters == null)
                    _systemParameters = Channels.ValueObjectService.GetSystemParameters();
                return _systemParameters;
            }
        }

        public IList<Sex> Genders
        {
            get
            {
                if (_sexTypes == null)
                    _sexTypes = Channels.ValueObjectService.GetGenders(Language.SystemLanguage);
                return _sexTypes;
            }
        }

        public IList<Country> Countries
        {
            get
            {
                if (_countries == null)
                    _countries = Channels.ValueObjectService.GetCountries(Language.SystemLanguage);
                return _countries;
            }
        }

        public IList<IdenType> IdenTypes
        {
            get
            {
                if (_idenTypes == null)
                    _idenTypes = Channels.ValueObjectService.GetIdenTypes(Language.SystemLanguage);
                return _idenTypes;
            }
        }

    }
}
