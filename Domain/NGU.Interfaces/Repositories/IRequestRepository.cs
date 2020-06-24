using NGU.Core;
using NGU.Interfaces.ApiAdmin;
using System.ServiceModel;

namespace NGU.Interfaces.Repositories
{
    public interface IRequestRepository : IBaseRepository
    {
        string GenerateRequestNum();
        Request GetReqByDoc(int docType, string docNumber, int country);

        //[OperationContract]
        //bool SaveRequest(Request request);

        //[OperationContract]
        //bool TerminateRequest(Request request);

        //[OperationContract]
        //RequestStatus GetRequestStatus(int requestNum);

        //[OperationContract]
        //RequestStatus SaveRequestStatus(int requestNum, RequestStatus requestStatus);

        //[OperationContract]
        //Request GetRequest(string docNumber);

        //[OperationContract]
        //Request GetRequest(int docType);

        //[OperationContract]
        //Request GetRequest(Country docCountry);
    }
}
