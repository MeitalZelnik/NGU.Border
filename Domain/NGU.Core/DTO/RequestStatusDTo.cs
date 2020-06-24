using Pangea.BaseStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Pangea.MultiLanguage;

namespace NGU.Core
{
    /// <summary>
    /// contains request and black list statuses - all united
    /// </summary>
    public class RequestStatusDTO: MultiLanguage
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

    }
}
