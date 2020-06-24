using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using NGU.Admin.Interfaces;
using NGU.Common.Utilities;
using Pangea.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Admin.App.Client.ViewModels
{
    public class EnquiryLicenceViewModel : BaseViewModel, IPrintingFunctions
    {
        #region ctor

        public EnquiryLicenceViewModel()
        {
            ProcessHelper.RunMethodOnDifferentTask(() =>
            {
                intref = BaseContainerViewModel.EquiryPersonIntref;
                appNo = BaseContainerViewModel.EquiryApplicationAppNo;

                Tuple<EnquiryLicenseDTO, List<EnquiryLicenseDTO>> res = null; // DrivingLicenceService.GetLicenceDataForEnquiryLicneseScreenByAppNo(appNo);

                License = res.Item1;
                TemporaryLicenses = res.Item2;

                if (TemporaryLicenses != null && TemporaryLicenses.Count > 0)
                    SelectedTemporaryLicense = TemporaryLicenses.First();
            });


            //DrivingLicencePrintingDTO = PrinterService.CreatePrintingData(BaseContainerViewModel.EquiryApplicationAppNo, null); // When sending null to the location we sould get the location of where the object was printed - ARI
            CreateImagesPreview();
        }

        #endregion

        #region members

        private int _selectedTabIndex = 0;
        private EnquiryLicenseDTO _license;
        private EnquiryLicenseDTO _selectedTemporaryLicense;
        private byte[] _cardPreviewFront;
        private byte[] _cardPreviewBack;
        //private Printer _printer;
        private List<EnquiryLicenseDTO> _temporaryLicenses;

        private long appNo;
        private string intref;

        #endregion

        #region props

        public int SelectedTabIndex
        {
            get
            {
                return _selectedTabIndex;
            }
            set
            {
                _selectedTabIndex = value;

                OnNotifyContainer("enableTempPrintBtn");

                NotifyPropertyChanged(() => SelectedTabIndex);
            }
        }

        public EnquiryLicenseDTO License
        {
            get
            {
                return _license;
            }
            set
            {
                _license = value;
                NotifyPropertyChanged(() => License);
            }
        }

        public List<EnquiryLicenseDTO> TemporaryLicenses
        {
            get
            {
                return _temporaryLicenses;
            }
            set
            {
                _temporaryLicenses = value;
                NotifyPropertyChanged(() => TemporaryLicenses);
                NotifyPropertyChanged(() => HasTemporaryLicenses);
            }
        }

        public bool HasTemporaryLicenses
        {
            get
            {
                if (TemporaryLicenses == null || TemporaryLicenses.Count == 0)
                    return false;

                return true;
            }
        }

        public EnquiryLicenseDTO SelectedTemporaryLicense
        {
            get
            {
                return _selectedTemporaryLicense;
            }
            set
            {
                _selectedTemporaryLicense = value;
                NotifyPropertyChanged(() => SelectedTemporaryLicense);
            }
        }

        //public Printer Printer
        //{
        //    get
        //    {
        //        if (_printer == null)
        //            _printer = new Printer();

        //        return _printer;
        //    }
        //}

        public PrintingDataDrivingLicenceDTO DrivingLicencePrintingDTO { get; set; }

        public byte[] CardPreviewFront
        {
            get
            {
                return _cardPreviewFront;
            }

            set
            {
                _cardPreviewFront = value;
                NotifyPropertyChanged(() => CardPreviewFront);
            }
        }

        public byte[] CardPreviewBack
        {
            get
            {
                return _cardPreviewBack;
            }

            set
            {
                _cardPreviewBack = value;
                NotifyPropertyChanged(() => CardPreviewBack);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Create print preview Images
        /// </summary>
        public void CreateImagesPreview()
        {
            try
            {
                // Send for preview
                //System.Drawing.Imaging.Metafile[] imgs = Printer.PrintPreview(DrivingLicencePrintingDTO, NIP.Devices.Printers.Zebra.DTO.Targets.ZebraZXP, DrivingLicencePrintingDTO.PrintingConfig, true);

                //if (imgs != null)
                //{
                //    CardPreviewFront = NIP.Devices.Printers.Zebra.Utilities.ImageHelper.EmfToByteImageFormat(imgs[0], System.Drawing.Imaging.ImageFormat.Bmp);
                //    CardPreviewBack = NIP.Devices.Printers.Zebra.Utilities.ImageHelper.EmfToByteImageFormat(imgs[1], System.Drawing.Imaging.ImageFormat.Bmp);
                //}

            }
            catch (Exception ex)
            {
            }
        }

        public void Print()
        {
            var vm = new EnquiryCreateTempDrivingLicenseViewModel(intref, appNo);
            DialogBoxResult dialogBoxResult = DialogService.SetUserControl(vm)
                                                          //.SetButtons(DialogButtons.OK)
                                                          .SetTitle("Temporary DL Details").SetWindowDimensions(null, 900)
                                                          .ShowDialog();

            //License lic = new License();
            //lic.AppNo = appNo;
            //lic.LicenseDocType = AllLicenseDocTypes.FirstOrDefault(x => x.ID == (int)LicenseDocTypes.Temporary);
            ////TODO

        }

        #endregion
    }
}
