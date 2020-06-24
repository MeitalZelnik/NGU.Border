using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.ApiAdmin;
using System.ServiceModel;

namespace NGU.Interfaces.Services
{
    [ServiceContract]
    public interface IRequestService : IBaseService
    {
        [OperationContract]
        string GenerateRequestNum();

        [OperationContract]
        long SaveRequest(Request request);

        [OperationContract]
        RequestStatuses GetRequestStatus(long reqID);

        [OperationContract]
        bool SaveRequestStatus(long reqID, RequestStatuses requestStatus);

        [OperationContract]
        Request GetRequestByDoc(int docType, string docNumber, int docCountry);

        [OperationContract]
        Request GetRequestByNum(string requestNum);
    }
}
