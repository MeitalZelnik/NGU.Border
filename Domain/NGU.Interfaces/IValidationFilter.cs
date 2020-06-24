using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Interfaces
{
    public interface IValidationFilter
    {
        bool Filter(Type t);
    }
}
