using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NGU.Common.Structs
{
    public struct ActionButton
    {
        public object ButtonImage { get; set; }
        public string ButtonText { get; set; }
        public string ButtonToolTip { get; set; }
        public ICommand ButtonCommand { get; set; }
        public object ButtonCommandParameter { get; set; }
        public bool ButtonIsEnabled { get; set; }
    }
}
