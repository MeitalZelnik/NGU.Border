using NGU.App.Client.Utitlities;
using NGU.App.Client.Validators;
using NGU.App.Client.Views;
using NGU.Core;
using NGU.Enums;
//using NGU.Border.Controls;
using NGU.Interfaces.ApiAdmin;
using Pangea.App.Services;
using Pangea.App.Utils;
using Pangea.BaseStructures;
using Pangea.BasicValidators;
using Pangea.DialogService;
using Pangea.Extensions;
using Pangea.Fingerprints.Interfaces;
using Pangea.Fingerprints.UI.ViewModel;
using Pangea.Logger;
using Pangea.Utils.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NGU.App.Client.ViewModels
{
    public class RegistrationViewModel : BaseViewModel, IOperationSaveRequest, IOperationNew, IOperationTerminate, IOperationSubmit
    {
        #region Data Members

        
        
        #endregion

        #region Ctor
        public RegistrationViewModel()
        {
           
        }
        #endregion

        #region Properties

       


        #endregion

        #region Commands
       
        #endregion

        #region Override Methods
        public override void OnDispose()
        {
           
        }

        public override bool Validate(ref NotificationMessages msg)
        {
            return this.IsValid();
        }
        #endregion

      

        #region Operations Methods
        public void Save()
        {
            //if (!BioCommandsData(null))
            //    return;

            //UpdateApplication(Request);

            try
            {
                //Request.ID = Channels.RequestService.SaveRequest(Request);
                SetIsEnableOperation(true, Operations.Terminate);
                ShowNotification(Lang.Resources.MSG_SaveSuccessfully, NotificationAreaType.Success);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ShowNotification(Lang.Resources.MSG_FailedWhileSaving, NotificationAreaType.Error);
            }
        }

        public void Submit()
        {
            try
            {
                //var status = Channels.PersonService.Enroll(Request.ID, LoggedUser.ID);
                //var reqStatus = Channels.RequestService.GetRequestStatus(Request.ID);
                //Request.RequestStatus = Lookups.RequestStatuses.FirstOrDefault(x => x.ID == (int)reqStatus); 
                //switch (status)
                //{
                //    case PangeaBiometricStatus.Ok:
                //        this.ShowNotification(Lang.Resources.MSG_RegistraionCompleted, NotificationAreaType.Success);
                //        break;
                //    case PangeaBiometricStatus.DuplicateFound:
                //        this.ShowNotification(Lang.Resources.MSG_RegistraionWaitInvestigation, NotificationAreaType.Error);
                //        break;
                //    default:
                //        this.ShowNotification(Lang.Resources.MSG_UnexpectedError, NotificationAreaType.Error);
                //        break;
                //}
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                this.ShowNotification(Lang.Resources.MSG_UnexpectedError, NotificationAreaType.Error);
            }

            RaisCanExecuteOperation(Operations.Terminate);
            RaisCanExecuteOperation(Operations.Save);
            RaisCanExecuteOperation(Operations.Submit);
            //System.Windows.Application.Current.Dispatcher.Invoke(() =>
            //{
            //    TakeFingerprintCommand.RaiseCanExecuteChanged();
            //    TakePhotoCommand.RaiseCanExecuteChanged();
            //    TakeSignatureCommand.RaiseCanExecuteChanged();
            //    VerifyPhotoCommand.RaiseCanExecuteChanged();
            //});
            
        }

        public void New()
        {
            //ResetData();
        }

        public void Terminate()
        {
            bool canTerminate = DialogService.ShowQuestionYesNo(Lang.Resources.MSG_Terminate);
            if (!canTerminate)
                return;

            try
            {
                //Channels.RequestService.SaveRequestStatus(Request.ID, RequestStatuses.Terminated);
                SetIsEnableOperation(false, Operations.Terminate);
                this.ShowNotification(Lang.Resources.MSG_TerminatedSuccessfully, NotificationAreaType.Success);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                this.ShowNotification(Lang.Resources.MSG_UnexpectedError, NotificationAreaType.Error);
            }
        }

        public bool CanExecuteSubmit(object obj)
        {
            return true;
            //return ReqIsInOpenStatus() &&
            //       IsTextualValid && 
            //       Photo != null && 
            //       Signature != null && 
            //       Fingers.All(f => f.Value != FingerStatus.NotCapture);
        }

        public bool CanExecuteTerminate(object obj)
        {
            //return ReqIsInOpenStatus();
            return true;
        }

        public bool CanExecuteSaveRequest(object obj)
        {
            //return IsTextualValid &&
            //       Request != null &&
            //       (Request.RequestStatus == null ||
            //        Request.RequestStatus.ID == (int)RequestStatuses.Open);
            return true;
        }

        public bool CanExecuteNew(object obj)
        {
            return true;
        }

        #endregion
    }
}
