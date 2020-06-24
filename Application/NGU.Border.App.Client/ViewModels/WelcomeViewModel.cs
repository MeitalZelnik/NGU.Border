using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.App.Client.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private string _nodeName;
        public string NodeName 
        {
            get
            {
                return _nodeName;
            }
            set
            {
                _nodeName = value;
                NotifyPropertyChanged();
            }
        }

        public WelcomeViewModel(string nodeName)
        {
            NodeName = nodeName;
        }

        public override bool HasChanged
        {
            get { return false; }
        }
    }
}
