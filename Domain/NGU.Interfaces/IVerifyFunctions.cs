using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Interfaces
{
    public interface IVerifyFunctions
    {
        void SendForApproval();

        void Terminate();
        
        void Approve();

        void Reject();
    }
}
