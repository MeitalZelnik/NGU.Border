using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using Pangea.Client.WPF.CustomControls;
using NGU.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NGU.Admin.App.Client.ViewModels
{
    public class CaptureFingerprintViewModel : BaseViewModel
    {
        #region ctor

        public CaptureFingerprintViewModel()
        {
            //InitializeFinger();
        }

        #endregion

        //#region members

        ////finger members
        //private IFingerprintsViewModel _fingerprintViewModel;
        //private ImageType _fingerprintsImageType;

        //private ICommand _waivedFingerprintCommand = null;
        //private ICommand _captureFingerprintCommand = null;

        //#endregion

        //#region props

        //public ApplicationDTO CurrentApplication
        //{
        //    get
        //    {
        //        return BaseContainerViewModel.CurrentApplication;
        //    }
        //}

        //#region finger props

        //public IFingerprintsViewModel FingerprintsViewModel
        //{
        //    get
        //    {
        //        if (_fingerprintViewModel == null)
        //            _fingerprintViewModel = DeviceFactory.Instance.GetSpecificFingerprintsViewModel(FingerPositions.RightIndex);

        //        return _fingerprintViewModel;
        //    }
        //}

        //public ImageType FingerprintsImageType
        //{
        //    get
        //    {
        //        if (_fingerprintsImageType == null)
        //            _fingerprintsImageType = ValueObjectHelper.AllImageTypes.First(i => i.ID == ImageTypes.Fingerprint.GetStringValue());

        //        return _fingerprintsImageType;
        //    }
        //}
        
        //#endregion finger props

        //#endregion

        //#region finger commands

        //public ICommand CaptureFingerprintCommand
        //{
        //    get
        //    {
        //        if (_captureFingerprintCommand == null)
        //        {
        //            _captureFingerprintCommand = new RelayCommand(param =>
        //            {
        //                FingerprintsViewModel.CaptureSequence();
        //            }, obj =>
        //            {
        //                return true;
        //            });
        //        }

        //        return _captureFingerprintCommand;
        //    }
        //}

        //public ICommand WaivedFingerprintCommand
        //{
        //    get
        //    {
        //        if (_waivedFingerprintCommand == null)
        //        {
        //            _waivedFingerprintCommand = new RelayCommand(param =>
        //            {
        //                FingerprintsViewModel.WaiveAll();
        //            }, obj =>
        //            {
        //                return true;
        //            });
        //        }

        //        return _waivedFingerprintCommand;
        //    }
        //}

        //#endregion

        //#region finger methods

        //private void InitializeFinger()
        //{
        //    DeviceFactory.Instance.Initialize(NeurotecVersion.Ver10, null, false, null, false);

        //    FingerprintsViewModel.MaxAllowedWaived = 1;
        //    FingerprintsViewModel.OnRecaptureAllOrOnlyNotWaived += FingersVM_OnRecaptureAllOrOnlyNotWaived;
        //    FingerprintsViewModel.OnSupervisorApprovalDialog += FingersVM_OnSupervisorApprovalDialog;
        //    /*            
        //    FingerViewModel.OnDisplayMsgOK += FingersVM_OnDisplayMsgOK;
        //    FingerViewModel.OnDisplayMsgError += FingersVM_OnDisplayMsgError;
        //    */

        //    NotifyPropertyChanged(() => FingerprintsViewModel);
        //}

        //bool FingersVM_OnRecaptureAllOrOnlyNotWaived(string message)
        //{
        //    DialogService d = new DialogService();
        //    d = d.SetButtons(DialogButtons.Yes, DialogButtons.No);
        //    DialogBoxResult result = d.ShowDialogError(message);
        //    if (result.Button == DialogButtons.Yes)
        //        return true;
        //    return false;
        //}

        //private bool FingersVM_OnSupervisorApprovalDialog(string message)
        //{
        //    bool returnValue = false;

        //    this.Dispatcher.Invoke(new Action(() => returnValue = FingersVM_TMP_credential_POPUP(message)));

        //    return returnValue;
        //}

        //private bool FingersVM_TMP_credential_POPUP(string message)
        //{
        //    DialogService d = new DialogService();
        //    d = d.SetButtons(DialogButtons.OK, DialogButtons.No);
        //    DialogBoxResult result = d.ShowDialogError(message);
        //    if (result.Button == DialogButtons.OK)
        //    {
        //        ////this is only temp, in real client should pop up credential window.
        //        if (MessageBox.Show("Approve waived finger?", "Credentials", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
        //        {
        //            return true;
        //        }

        //        return false;
        //    }

        //    return false;
        //}

        //#endregion finger methods
    }
}
