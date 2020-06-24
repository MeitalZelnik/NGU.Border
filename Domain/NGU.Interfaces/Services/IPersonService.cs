using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.ApiAdmin;
using Pangea.Fingerprints.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Interfaces.Services
{
    [ServiceContract]
    public interface IPersonService : IBaseService
    {
        [OperationContract]
        Person GetPerson(int ID);

        [OperationContract]
        PersonDoc GetPersonDoc(int ID);

        [OperationContract]
        Person SearchPersonByDoc(int docType, string docNumber, int country);

        [OperationContract]
        void SaveFingerprints(long requestId, int userId, Dictionary<FPIndexes, byte[]> fingersData);

        [OperationContract]
        PangeaBiometricStatus Enroll(long requestId, int userId);

        [OperationContract]

        void SaveImage(long requestId, int userId, ImageTypes imageType, byte[] image);
    }
}
