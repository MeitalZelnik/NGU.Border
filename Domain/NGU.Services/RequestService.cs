using NGU.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGU.Core;
using NGU.Interfaces.ApiAdmin;
using NGU.Interfaces.Repositories;
using Pangea;
using Pangea.Logger;
using NGU.Enums;
using Pangea.Extensions;
using System.Configuration;

namespace NGU.Services
{
    public class RequestService : BaseService, IRequestService
    {
        private readonly IRequestRepository _requestRepository = IoC.Instance.Resolve<IRequestRepository>();

        public string GenerateRequestNum()
        {
            string reqNum = _requestRepository.GenerateRequestNum();
            Log.Info($"Generate request number: {reqNum}");
            return reqNum;
        }

        public Request GetRequestByDoc(int docType, string docNumber, int docCountry)
        {
            Log.Debug($"Params: type={docType}, number={docNumber}, country={docCountry}");
            Request req = _requestRepository.GetReqByDoc(docType, docNumber, docCountry);
            Log.Info($"Request is found: {req != null}");
            return req;
        }

        public Request GetRequestByNum(string requestNum)
        {
            Log.Debug($"Params: requestNum={requestNum}");
            Request req = _requestRepository.FindAll<Request>().FirstOrDefault(r => r.Num == requestNum);
            Log.Info($"Request is found: {req != null}");
            return req;
        }

        public RequestStatuses GetRequestStatus(long reqID)
        {
            var request = _requestRepository.Get<Request>(reqID);

            RequestStatuses status = RequestStatuses.Empty;
            if (request.RequestStatus != null)
                status = request.RequestStatus.Code.ToEnumFromStringValue<RequestStatuses>();

            return status;
        }

        public long SaveRequest(Request request)
        {
            DateTime saveTime = DateTime.Now;

            if (request.CreateDate == null)
                request.CreateDate = saveTime;

            request.UpdateDate = saveTime;
            _requestRepository.SaveOrUpdate(request);
            Log.Info($"Saved request: {request.Num}");

            return request.ID;
        }

        public bool SaveRequestStatus(long reqID, RequestStatuses requestStatus)
        {
            Log.Debug($"Params: reqID={reqID}, requestStatus={requestStatus}");

            DateTime saveTime = DateTime.Now;
            var req = _requestRepository.Get<Request>(reqID);
            if (req == null)
                return false;

            req.RequestStatus = _requestRepository.Get<RequestStatus>((int)requestStatus);
            req.UpdateDate = saveTime;
            req.StatusDate = saveTime;
            _requestRepository.SaveOrUpdate(req);
            Log.Info($"Update request status from {req.RequestStatus.Name} to {requestStatus}.");
            return true;
        }
    }
}
