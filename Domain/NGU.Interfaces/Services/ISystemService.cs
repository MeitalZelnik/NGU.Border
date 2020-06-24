using NGU.App.DTO;
using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.ApiAdmin;
using Pangea.Network.NetDataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Interfaces.Services
{
    [ServiceContract]
    public interface ISystemService : IBaseService
    {
        //[OperationContract]
        //bool IsAlive();
    }
}
