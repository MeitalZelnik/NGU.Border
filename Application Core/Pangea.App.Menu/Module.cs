using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pangea.App.Menu
{
    public class Module
    {
        [XmlAttribute("is_process")]
        public bool IsProcess { get; set; }

        [XmlAttribute("showSideMenu")]
        public bool ShowSideMenu { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
