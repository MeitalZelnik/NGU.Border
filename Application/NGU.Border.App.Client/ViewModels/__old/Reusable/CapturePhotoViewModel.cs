using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using Pangea.Client.WPF.CustomControls;
using NGU.Common.Utilities;
using NIP.Devices.Camera.Player.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NGU.Admin.App.Client.ViewModels
{
    public class CapturePhotoViewModel : BaseViewModel
    {
        #region ctor

        public CapturePhotoViewModel(bool withApp)
        {
            //InitializePhoto(withApp);
        }

        #endregion

        //#region members

        ////photo members
        //private bool _isPhotoInitFlag;
        //private bool _isStartCameraVisible;
        //private bool _isCaptureVisible;
        //private bool _enableClear;
        //private ImageType _photoImageType;
        //private Image _photoImage;
        //private byte[] _origPhotoData;
        //private byte[] _capturedPhotoData;

        //private ICommand _startPhotoCommand;
        //private ICommand _capturePhotoCommand;
        //private ICommand _recapturePhotoCommand;
        //private ICommand _clearPhotoCommand;

        //private bool _hasChanges;

        //#endregion

        //#region photo props

        //public ApplicationDTO CurrentApplication
        //{
        //    get
        //    {
        //        return BaseContainerViewModel.CurrentApplication;
        //    }
        //}

        //public ImageType PhotoImageType
        //{
        //    get
        //    {
        //        if (_photoImageType == null)
        //            _photoImageType = ValueObjectHelper.AllImageTypes.First(i => i.ID == ImageTypes.Photo.GetStringValue());

        //        return _photoImageType;
        //    }
        //}

        //public Image PhotoImage
        //{
        //    get
        //    {
        //        return _photoImage;
        //    }
        //    set
        //    {
        //        _photoImage = value;
        //        NotifyPropertyChanged(() => PhotoImage);
        //    }
        //}

        //public Image PhotoImageCloned { get; set; }

        //public bool IsStartCameraVisible
        //{
        //    get
        //    {
        //        return _isStartCameraVisible;
        //    }
        //    set
        //    {
        //        _isStartCameraVisible = value;
        //        NotifyPropertyChanged(() => IsStartCameraVisible);
        //    }
        //}

        //public bool IsCaptureVisible
        //{
        //    get
        //    {
        //        return _isCaptureVisible;
        //    }
        //    set
        //    {
        //        _isCaptureVisible = value;
        //        NotifyPropertyChanged(() => IsCaptureVisible);
        //    }
        //}

        //public bool EnableClear
        //{
        //    get
        //    {
        //        return _enableClear;
        //    }
        //    set
        //    {
        //        _enableClear = value;
        //        NotifyPropertyChanged(() => EnableClear);
        //    }
        //}

        //[NipMustBeSelected]
        //public bool IsPhotoEmpty
        //{
        //    get
        //    {
        //        if (PhotoImage == null || (PhotoImage != null && PhotoImage.BinaryData == null))
        //            return true;

        //        return false;
        //    }
        //}

        //#endregion

        //#region photo commands

        //public ICommand StartPhotoCommand
        //{
        //    get
        //    {
        //        if (_startPhotoCommand == null)
        //            _startPhotoCommand = new RelayCommand(StartPhotoExecute);

        //        return _startPhotoCommand;
        //    }
        //}

        //public ICommand CapturePhotoCommand
        //{
        //    get
        //    {
        //        if (_capturePhotoCommand == null)
        //            _capturePhotoCommand = new RelayCommand(CapturePhotoExecute);

        //        return _capturePhotoCommand;
        //    }
        //}

        //public ICommand RecapturePhotoCommand
        //{
        //    get
        //    {
        //        if (_recapturePhotoCommand == null)
        //            _recapturePhotoCommand = new RelayCommand(RecapturePhotoExecute);

        //        return _recapturePhotoCommand;
        //    }
        //}

        //public ICommand ClearPhotoCommand
        //{
        //    get
        //    {
        //        if (_clearPhotoCommand == null)
        //            _clearPhotoCommand = new RelayCommand(ClearPhotoExecute);

        //        return _clearPhotoCommand;
        //    }
        //}

        //#endregion

        //#region photo methods

        //private void InitializePhoto(bool withApp)
        //{
        //    if (withApp)
        //        if (CurrentApplication == null)
        //            return;

        //    _isPhotoInitFlag = false;

        //    List<ImageTypes> imageTypesPhotoOnly = new List<ImageTypes>();
        //    imageTypesPhotoOnly.Add(ImageTypes.Photo);

        //    if (withApp)
        //    {
        //        List<Image> images = DrivingLicenceService.GetImageByImageTypes(CurrentApplication.AppNo, imageTypesPhotoOnly);

        //        if (images != null && images.Any())
        //        {
        //            PhotoImage = images.FirstOrDefault();
        //            PhotoImage.LoadedFromDB = true;
        //            _origPhotoData = (byte[])_photoImage.BinaryData.Clone();

        //            if (_origPhotoData != null)
        //            {
        //                PlayerObserver.DisplayExistImage(_origPhotoData);
        //            }
        //        }
        //    }

        //    IsStartCameraVisible = true;
        //    IsCaptureVisible = false;
        //    EnableClear = true;
        //    _isPhotoInitFlag = true;
        //}

        //public void StartPhotoExecute(object param)
        //{
        //    PlayerObserver.OnVideoStarted += PlayerObserverOnVideoStarted;
        //    PlayerObserver.CreateVideoManager();

        //    PhotoImage = null;
        //    NotifyPropertyChanged(() => IsPhotoEmpty);
        //}

        //private void CapturePhotoExecute(object param)
        //{
        //    _capturedPhotoData = PlayerObserver.CaptureImage();

        //    if (_capturedPhotoData != null)
        //    {
        //        #region check face Detection legality

        //        //bool isLegalFace = SystemService.DetectFace(_capturedPhotoData);
        //        //if (!isLegalFace)
        //        //{
        //        //    Recapture();
        //        //    DialogService.ShowDialogError("Captured photo is illegal");
        //        //    return;
        //        //}

        //        #endregion

        //        _hasChanges = true;
        //        IsCaptureVisible = false;

        //        if (PhotoImage == null)
        //        {
        //            PhotoImage = new Image()
        //            {
        //                ImageType = PhotoImageType,
        //                IsWaived = YesNo.No.GetCharValue(),
                       
        //            };

        //            if (CurrentApplication != null)
        //                PhotoImage.AppNo = CurrentApplication.AppNo;
        //        }

        //        PhotoImage.BinaryData = _capturedPhotoData;
        //        PhotoImage.CaptureDate = DateTime.Now;
        //        PhotoImage.LoadedFromDB = false;
        //    }

        //    NotifyPropertyChanged(() => IsPhotoEmpty);
        //    EnableClear = true;
        //}

        //private void RecapturePhotoExecute(object param)
        //{
        //    PlayerObserver.DiscardCapture();
        //    IsCaptureVisible = true;
        //    EnableClear = false;

        //    PhotoImage = null;
        //    NotifyPropertyChanged(() => IsPhotoEmpty);
        //}

        //private void ClearPhotoExecute(object param)
        //{
        //    if (PhotoImage != null && _hasChanges)
        //    {
        //        //must save clone aside for future use after closing current vm
        //        PhotoImageCloned = new Image()
        //        {
        //            AppNo = PhotoImage.AppNo,
        //            BinaryData = PhotoImage.BinaryData,
        //            CaptureDate = PhotoImage.CaptureDate,
        //            CaptureUser = PhotoImage.CaptureUser,
        //            ImageType = PhotoImage.ImageType,
        //            IsWaived = PhotoImage.IsWaived,
        //            LoadedFromDB = PhotoImage.LoadedFromDB
        //        };

        //        _hasChanges = false;
        //        if (_origPhotoData == null)
        //        {
        //            PhotoImage = null;
        //            PlayerObserver.CloseCamera();
        //        }
        //        else
        //        {
        //            PhotoImage.BinaryData = (byte[])_origPhotoData.Clone();
        //            PlayerObserver.CloseCameraAndDisplayImage(_origPhotoData);
        //        }

        //        _capturedPhotoData = null;
        //        IsStartCameraVisible = true;
        //        IsCaptureVisible = false;
        //        NotifyPropertyChanged(() => IsPhotoEmpty);
        //    }
        //}

        //private void PlayerObserverOnVideoStarted()
        //{
        //    IsStartCameraVisible = false;
        //    IsCaptureVisible = true;
        //    EnableClear = false;
        //}

        //public void CloseCamera()
        //{
        //    try
        //    {
        //        PlayerObserver.CloseCamera();

        //        IsStartCameraVisible = true;
        //        IsCaptureVisible = false;
        //        NotifyPropertyChanged(() => IsPhotoEmpty);
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        //#endregion
    }
}
