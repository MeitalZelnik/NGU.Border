using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pangea.App.Menu
{
    [XmlRoot]
    public class RootMenu
    {
        [XmlElement("AppMenu")]
        public List<AppMenu> AppMenus { get; set; }
    }
}
