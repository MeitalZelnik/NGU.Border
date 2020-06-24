using Pangea.Fingerprints.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Core
{
    public partial class Person
    {
        public virtual Dictionary<FPIndexes, byte[]> Fingers { get; set; }
        public virtual byte[] Signature { get; set; }

        public virtual byte[] Photo { get; set; }
    }
}
