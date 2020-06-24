using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pangea.App.Menu
{
    public class Menu
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("order")]
        public int Order { get; set; }
        
        public bool IsModule
        {
            get
            {
                return Module != null;
            }
        }

        [XmlElement("Module")]
        public Module Module { get; set; }

        [XmlElement("Invocation")]
        public Invocation Invocation { get; set; }

        [XmlElement("Image")]
        public string Image { get; set; }

        [XmlElement("Accessibility")]
        public string Accessibility { get; set; }

        [XmlElement("DetailsBox")]
        public bool DetailsBox { get; set; }
        
        [XmlElement("Menus")]
        public MenuList SubMenus { get; set; }
    }

    [XmlRoot("Menus")]
    public class MenuList
    {
        public MenuList() { Menus = new List<Menu>(); }
        [XmlElement("Menu")]
        public List<Menu> Menus { get; set; }
    }
}
