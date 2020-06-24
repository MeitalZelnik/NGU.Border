using Pangea.App.Utils;
using Pangea.BaseStructures;
using Pangea.Fingerprints.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pangea.Extensions;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Windows;
using Pangea.Fingerprints.Interfaces;
using NGU.Common.Utilities;
using NGU.App.Client.Utitlities;
using Pangea.Logger;
using Pangea.App.Services;

namespace NGU.App.Client.ViewModels
{
    public class FingerprintViewModel : BaseViewModel
    {
        #region DataMembers

        private AllFingersViewModel _fingersVM;

        #endregion

        #region Ctor

        public FingerprintViewModel()
        {
            FingersVM = new AllFingersViewModel(WorkingMode.Take);
        }

        #endregion

        #region Properties

        public AllFingersViewModel FingersVM
        {
            get
            {
                return _fingersVM;
            }
            set 
            {
                _fingersVM = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods

        public void SetFingers(Dictionary<FPIndexes, byte[]> fingers)
        {
            if (fingers != null)
                FingersVM.LoadFingerprintsFromWSQ(fingers);
        }

        public override void OnDispose()
        {
            FingersVM.StopScanning();
            FingersVM.Clear(null);
            FingersVM.Dispose();
        }

        #endregion
    }
}
