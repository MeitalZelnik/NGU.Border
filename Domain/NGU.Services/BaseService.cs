using NGU.Core;
using NGU.Interfaces.ApiAdmin;
using NGU.Interfaces.Services;
using NGU.Common.Utilities;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using Admin = NGU.Interfaces.ApiAdmin;
using System;

namespace NGU.Services
{
    [System.ServiceModel.ServiceBehavior(ConcurrencyMode = System.ServiceModel.ConcurrencyMode.Multiple, InstanceContextMode = System.ServiceModel.InstanceContextMode.Single)]
    public class BaseService : IBaseService
    {
        #region members

        private ApiServiceClient _apiAdmin;

        #endregion

        #region ctor

        public BaseService()
        {
        }

        #endregion

        #region props
        internal ApiServiceClient APIAdmin
        {
            get
            {
                if (_apiAdmin == null)
                    _apiAdmin = Pangea.Network.WcfHelper.CreateWCFClientByConfig<ApiServiceClient>("NGU.Admin.Server");

                return _apiAdmin;
            }
        }
        #endregion


        #region Methods

        public bool IsAlive()
        {
            return true;
        }

        #endregion
    }
}

