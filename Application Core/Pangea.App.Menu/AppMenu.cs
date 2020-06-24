using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pangea.App.Menu
{
    public class AppMenu
    { 
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("Menu")]
        public List<Menu> Menus { get; set; }
    }
}
