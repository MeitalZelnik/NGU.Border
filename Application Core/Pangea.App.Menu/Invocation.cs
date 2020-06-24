using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pangea.App.Menu
{
    public class Invocation
    {
        [XmlElement("assembly")]
        public string Assembly { get; set; }

        [XmlElement("vm")]
        public string ViewModelName { get; set; }

        [XmlElement("param")]
        public string Param { get; set; }
    }
}
