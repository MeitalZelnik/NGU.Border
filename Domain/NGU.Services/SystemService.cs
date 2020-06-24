using NGU.App.DTO;
using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.Repositories;
using NGU.Interfaces.Services;
using NGU.Common.Utilities;
using Pangea.Extensions;
using Pangea.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Admin = NGU.Interfaces.ApiAdmin;

namespace NGU.Services
{
    [System.ServiceModel.ServiceBehavior(ConcurrencyMode = System.ServiceModel.ConcurrencyMode.Multiple, InstanceContextMode = System.ServiceModel.InstanceContextMode.Single)]
    public class SystemService : BaseService, ISystemService
    {
        #region private members

        private ISystemRepository _systemRepository;

        #endregion

        #region props

        public ISystemRepository SystemRepository
        {
            get
            {
                if (_systemRepository == null)
                    _systemRepository = Pangea.IoC.Instance.Resolve<ISystemRepository>();
                return _systemRepository;
            }
        }

        #endregion

        //public bool IsAlive()
        //{
        //    SystemRepository.GetBiometricsParams();

        //    return true;
        //}

        public bool SaveRequest(Request request)
        {
            try
            {
                //AppendSurnameAndGivenNames(request);
                SystemRepository.SaveOrUpdate<Request>(request);

                return true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        public bool TerminateRequest(Request request)
        {
            return SaveRequest(request);
            
            //if (request.RequestType.ID != (int)RequestTypes.NewRequest)
            //{
            //    BlackListRecord blackList = SystemRepository.Get<BlackListRecord>(request.BlackList.ID);

            //    if (blackList != null)
            //    {
            //        //by moshe, no need!
            //        //if (request.RequestType.ID == (int)RequestTypes.CancelRequest)
            //        //    blackList.Status = new RecordStatus() { ID = (int)BlackListStatusTypes.Cancelled };

            //        //if (request.RequestType.ID == (int)RequestTypes.RemoveRequest)
            //        //    blackList.Status = new RecordStatus() { ID = (int)BlackListStatusTypes.Removed };

            //        //if (request.RequestType.ID == (int)RequestTypes.UpdateRequest)
            //        //    blackList.Status = new RecordStatus() { ID = (int)BlackListStatusTypes.Active };
            //    }

            //    return SaveRequest(request);
            //}
        }





        #region private methods

        //private void AppendSurnameAndGivenNames(Request request)
        //{
        //    StringBuilder sbSurname = new StringBuilder();
        //    StringBuilder sbGivenNames = new StringBuilder();

        //    sbSurname.Append(request.PrimaryName);
        //    if (!request.SecondName.IsNullOrEmpty())
        //    {
        //        sbSurname.Append(" ");
        //        sbSurname.Append(request.SecondName);
        //    }

        //    sbGivenNames.Append(request.PrimarySurname);
        //    if (!request.SecondName.IsNullOrEmpty())
        //    {
        //        sbGivenNames.Append(" ");
        //        sbGivenNames.Append(request.SecondName);
        //    }

        //    request.Surname = sbSurname.ToString();
        //    request.GivenNames = sbGivenNames.ToString();
        //}

 
        #endregion
    }
}
