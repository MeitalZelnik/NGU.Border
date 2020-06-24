using NGU.Core;
using System.Collections.Generic;
using System;

namespace NGU.Interfaces.Repositories
{
    public interface ISystemRepository : IBaseRepository
    {
        Tuple<List<Request>, int> SearchRequests(int maxResults, string firstName, string lastName, bool isPartial, DateTime? createdFrom, DateTime? createdTo, int? selectedIDTypeID, string iDNumber, int? selectedCountryID, string internalFileNo, string requestNo, int? requestTypeID, int? requestStatusID);

        Request GetRequest(int id);
        
        string GenerateSequence(string seqName);

        List<BiometricParameter> GetBiometricsParams();

    }
}
