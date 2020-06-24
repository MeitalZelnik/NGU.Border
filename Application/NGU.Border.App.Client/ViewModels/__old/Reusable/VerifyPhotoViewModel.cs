using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Admin.App.Client.ViewModels
{
    public class VerifyPhotoViewModel : BaseViewModel
    {
        public VerifyPhotoViewModel(byte[] binaryData)
        {
            BinaryData = binaryData;
        }

        private byte[] _binaryData;
        public byte[] BinaryData
        {
            get
            {
                return _binaryData;
            }
            set
            {
                _binaryData = value;
                NotifyPropertyChanged(() => BinaryData);
            }
        }
    }
}
