using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Interfaces.Services
{
    [ServiceContract]
    public interface IBaseService
    {
        [OperationContract]
        bool IsAlive();
    }
}
