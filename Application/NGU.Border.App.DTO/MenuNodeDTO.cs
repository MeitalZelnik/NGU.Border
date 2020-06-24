using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NGU.App.DTO
{
    public class MenuNodeDTO
    {
        private bool isSelected;
        private bool isEnabled;

        public int MenuId { get; set; }

        public int MenuOrderNo { get; set; }

        public string Name { get; set; }

        public string ViewModelName { get; set; }

        public string AssembleyName { get; set; }

        public bool IsModule { get; set; }

        public string ModuleType { get; set; }

        public string ParamFunction { get; set; }

        public ImageSource Image { get; set; }

        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                this.isEnabled = value;
            }
        }

        public bool IsProcess { get; set; }
        public bool ShowSideMenu { get; set; }

        public bool ShowDetailsBox { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is MenuNodeDTO)
                return (obj as MenuNodeDTO).MenuId == this.MenuId;

            return base.Equals(obj);
        }

        public List<string> Accessibility { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
