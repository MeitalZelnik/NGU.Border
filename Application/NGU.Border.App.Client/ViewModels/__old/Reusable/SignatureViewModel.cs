using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using Pangea.Client.WPF.CustomControls;
using NGU.Common.Utilities;
using NIP.Devices.Signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NGU.Admin.App.Client.ViewModels
{
    public class SignatureViewModel : BaseViewModel
    {
        #region ctor

        public SignatureViewModel(ImageTypes requestedSignaturerType)
        {
            //RequestedSignaturerType = requestedSignaturerType; //ImageTypes.CollectorSignature or ImageTypes.Signature
            //InitializeSignature();
        }

        #endregion

        //#region members

        //private bool _isSignatureInitFlag;
        //private bool _signatureTaken;
        //private bool _hasChanges;
        //private bool _enableSignatureSection;
        //private ImageType _signatureImageType;
        //private SignatureUserControl _signatureUserControl;
        //private Image _signatureImage;
        //private byte[] _originalSignatureBytes;
        //private byte[] _waivedImage = null;

        //private ICommand _startSignatureCommand;
        //private ICommand _clearCommand;
        //private ICommand _takeSignatureCommand;
        //private ICommand _waiveCommand;

        //#endregion

        //#region signatureProps

        //public ImageTypes RequestedSignaturerType { get; set; }

        //public ApplicationDTO CurrentApplication
        //{
        //    get
        //    {
        //        return BaseContainerViewModel.CurrentApplication;
        //    }
        //}

        //public int PenSize
        //{
        //    get
        //    {
        //        return 4;
        //        //TODO::::return AppSettingsHelper.SignaturePenSize;
        //    }
        //}

        //public SignatureUserControl SignatureUserControl
        //{
        //    get
        //    {
        //        return _signatureUserControl;
        //    }
        //    set
        //    {
        //        _signatureUserControl = value;

        //        NotifyPropertyChanged(() => SignatureUserControl);
        //    }
        //}

        //public bool IsSignatureAlive
        //{
        //    get
        //    {
        //        if (SignatureUserControl != null)
        //        {
        //            return SignatureUserControl.IsAlive;
        //        }

        //        return false;
        //    }
        //}

        //[NipMustBeFalse]
        //public bool IsSignatureEmpty
        //{
        //    get
        //    {
        //        bool result = false;

        //        if (SignatureUserControl != null)
        //        {
        //            ProcessHelper.RunMethodOnDispatcher(() =>
        //            {
        //                result = SignatureUserControl.IsEmpty;
        //            });
        //        }
        //        else
        //            result = true;

        //        return result;
        //    }
        //    set
        //    {
        //        NotifyPropertyChanged(() => IsSignatureEmpty);
        //    }
        //}

        //public Image SignatureImage
        //{
        //    get
        //    {
        //        return _signatureImage;
        //    }
        //    set
        //    {
        //        _signatureImage = value;
        //        NotifyPropertyChanged(() => SignatureImage);
        //    }
        //}

        //public bool EnableSignatureSection
        //{
        //    get
        //    {
        //        return _enableSignatureSection;
        //    }
        //    set
        //    {
        //        _enableSignatureSection = value;
        //        NotifyPropertyChanged(() => EnableSignatureSection);
        //    }
        //}

        //public ImageType SignatureImageType
        //{
        //    get
        //    {
        //        if (_signatureImageType == null)
        //            _signatureImageType = ValueObjectHelper.AllImageTypes.First(i => i.ID == RequestedSignaturerType.GetStringValue());

        //        return _signatureImageType;
        //    }
        //}

        //public bool IsShowAvatar
        //{
        //    get
        //    {
        //        return (!IsSignatureAlive && IsSignatureEmpty);
        //    }
        //}

        //#endregion

        //#region Signature Commands

        //public ICommand StartSignatureCommand
        //{
        //    get
        //    {
        //        if (_startSignatureCommand == null)
        //            _startSignatureCommand = new RelayCommand(StartSignatureExceute);

        //        return _startSignatureCommand;
        //    }
        //}

        //public ICommand ClearSignatureCommand
        //{
        //    get
        //    {
        //        if (_clearCommand == null)
        //            _clearCommand = new RelayCommand(ClearExecute);

        //        return _clearCommand;

        //    }
        //}

        //public ICommand TakeSignatureCommand
        //{
        //    get
        //    {
        //        if (_takeSignatureCommand == null)
        //            _takeSignatureCommand = new RelayCommand(TakeSignatureExecute);

        //        return _takeSignatureCommand;
        //    }
        //}

        //public ICommand WaiveSignatureCommand
        //{
        //    get
        //    {
        //        if (_waiveCommand == null)
        //            _waiveCommand = new RelayCommand(WaiveSignatureExectute);

        //        return _waiveCommand;
        //    }
        //}

        //#endregion

        //#region signature methods

        //private void InitializeSignature()
        //{
        //    if (CurrentApplication == null)
        //        return;

        //    _isSignatureInitFlag = false;

        //    // Create new instance of signature control
        //    SignatureUserControl = new NIP.Devices.Signature.SignatureUserControl(2, penSize: PenSize);
        //    SignatureUserControl.OnSignatureAccepted += SignatureUserControl_OnSignatureAccepted;

        //    List<ImageTypes> imageTypesSignatureOnly = new List<ImageTypes>();
        //    imageTypesSignatureOnly.Add(RequestedSignaturerType);

        //    List<Image> images = DrivingLicenceService.GetImageByImageTypes(CurrentApplication.AppNo, imageTypesSignatureOnly);

        //    _signatureTaken = false;

        //    if (images != null && images.Count > 0)
        //    {
        //        SignatureImage = images.FirstOrDefault();

        //        SignatureImage.LoadedFromDB = true;

        //        if (SignatureImage != null)
        //        {
        //            // Display the loaded signature on the screen
        //            SignatureUserControl.LoadExistingSignature(SignatureImage.BinaryData);

        //            _originalSignatureBytes = SignatureImage.BinaryData;
        //        }
        //    }

        //    _isSignatureInitFlag = true;

        //    EnableSignatureSection = true;

        //    _waivedImage = SignatureUserControl.WaivedImage;

        //    NotifyPropertyChanged(() => IsSignatureEmpty);
        //}

        //private void RestoreData()
        //{
        //    SignatureUserControl.ClearScreen();
        //    SignatureImage = null;
        //    InitializeSignature();
        //    NotifyPropertyChanged(() => IsSignatureEmpty);
        //}

        //#region Events Handler

        ///// <summary>
        ///// Raised whent he signature has been saved from the tablet
        ///// </summary>
        //private void SignatureUserControl_OnSignatureAccepted()
        //{
        //    TakeSignatureExecute(null);

        //    ProcessHelper.RunMethodOnDispatcher(() =>
        //    {
        //        //Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        //        //{
        //        _signatureUserControl.StopCapturingAndDisconnect();
        //        NotifyPropertyChanged(() => IsSignatureAlive);
        //        NotifyPropertyChanged(() => IsSignatureEmpty);
        //        NotifyPropertyChanged(() => IsShowAvatar);
        //        // Declare that the view model has changes
        //        _hasChanges = true;

        //        NIP.DisplayScreen.Display.ClearDisplayContent();
        //        //}));

        //    });
        //}

        ///// <summary>
        ///// Raised when we choose one of the component 
        ///// </summary>
        //private void SignatureUserControl_OnCompoenentSelected()
        //{
        //    NotifyPropertyChanged(() => IsSignatureAlive);
        //    NotifyPropertyChanged(() => IsShowAvatar);
        //}

        //#endregion

        //private void StartSignatureExceute(object param)
        //{
        //    if (SignatureUserControl != null)
        //        SignatureUserControl.StartCapturing();

        //    if (SignatureUserControl.Pads.Count > 0)
        //        NIP.DisplayScreen.Display.SetDisplayContent(SignatureUserControl.Pads[1]);

        //    NotifyPropertyChanged(() => IsSignatureAlive);
        //    NotifyPropertyChanged(() => IsSignatureEmpty);
        //    NotifyPropertyChanged(() => IsShowAvatar);
        //}

        //private void TakeSignatureExecute(object param)
        //{
        //    try
        //    {
        //        if (SignatureUserControl != null)
        //        {
        //            if (SignatureImage == null)
        //                SignatureImage = new Image();

        //            SignatureImage.IsWaived = YesNo.No.GetCharValue();
        //            SignatureImage.CaptureDate = DateTime.Now;
        //            SignatureImage.LoadedFromDB = false;
        //            SignatureImage.ImageType = SignatureImageType;

        //            SignatureUserControl.StopCapturingAndDisconnect();
        //            SignatureImage.BinaryData = SignatureUserControl.SaveSignature().ToArray();

        //            NotifyPropertyChanged(() => IsSignatureAlive);
        //            NotifyPropertyChanged(() => IsSignatureEmpty);
        //            NotifyPropertyChanged(() => IsShowAvatar);

        //            // Declare that the view model has changes
        //            _hasChanges = true;

        //            NIP.DisplayScreen.Display.ClearDisplayContent();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private void ClearExecute(object param)
        //{
        //    // Declare that the view model has changes
        //    if (!SignatureUserControl.IsEmpty)
        //        _hasChanges = true;

        //    // Clear the signature
        //    SignatureUserControl.ClearScreen();


        //    // if in Process of capturing OR there was no signture from the DB
        //    if (IsSignatureAlive || _originalSignatureBytes == null)
        //    {
        //        // Set signature as null
        //        SignatureImage = null;
        //    }
        //    else
        //    {
        //        // if there is an original Signature from the DB load it.
        //        SignatureImage.BinaryData = _originalSignatureBytes;
        //        SignatureUserControl.LoadExistingSignature(SignatureImage.BinaryData);
        //    }

        //    NotifyPropertyChanged(() => IsSignatureAlive);
        //    NotifyPropertyChanged(() => IsSignatureEmpty);
        //    NotifyPropertyChanged(() => IsShowAvatar);
        //}

        //private void WaiveSignatureExectute(object param)
        //{
        //    if (SignatureImage == null)
        //        SignatureImage = new Image();

        //    // Declare that the view model has changes
        //    if (!_signatureUserControl.IsWaived)
        //        _hasChanges = true;

        //    // Waive the SuerControl
        //    SignatureUserControl.Waive();

        //    SignatureImage.BinaryData = _waivedImage; // Use an image we saved
        //    SignatureImage.IsWaived = YesNo.Yes.GetCharValue();
        //    SignatureImage.CaptureDate = DateTime.Now;
        //    SignatureImage.LoadedFromDB = false;
        //    SignatureImage.ImageType = SignatureImageType;

        //    _signatureTaken = false;

        //    NotifyPropertyChanged(() => IsSignatureAlive);
        //    NotifyPropertyChanged(() => IsSignatureEmpty);
        //    NotifyPropertyChanged(() => IsShowAvatar);

        //    SignatureUserControl.StopCapturingAndDisconnect();
        //}

        //#endregion
    }
}
