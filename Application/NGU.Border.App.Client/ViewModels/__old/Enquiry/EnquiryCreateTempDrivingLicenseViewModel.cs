using NGU.Admin.Core;
using NGU.Admin.Enums;
using Pangea.Client.WPF.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NGU.Admin.App.Client.ViewModels
{
    public class EnquiryCreateTempDrivingLicenseViewModel : BaseViewModel
    {
        #region ctor

        public EnquiryCreateTempDrivingLicenseViewModel(string intref, long appNo)
        {
            //_intref = intref;
            //_appNo = appNo;

            //ProcessHelper.RunMethodOnDifferentTask(() => 
            //{
            //    _applicant = DrivingLicenceService.GetApplicant(_appNo);
            //});
        }

        #endregion

        //    #region members

        //    private string _intref;
        //    private long _appNo;
        //    private Applicant _applicant;

        //    private string _serialNo;
        //    private bool _isCollectorApplicant;
        //    private string _surname;
        //    private string _otherNames;
        //    private Sex _selectedSex;
        //    private DateTime? _birthDate;
        //    private DocumentType _selectedDocumentType;
        //    private string _idPassportNumber;
        //    private Nationality _selectedNationality;
        //    private string _physicalAddress;
        //    private string _postalAddress;
        //    private string _telephone;
        //    private Relationship _selectedRelationship;

        //    #endregion

        //    #region props

        //    [NipRequired]
        //    [NipLength(8)]
        //    public string SerialNo
        //    {
        //        get
        //        {
        //            return _serialNo;
        //        }
        //        set
        //        {
        //            _serialNo = value;
        //            NotifyPropertyChanged(() => SerialNo);
        //        }
        //    }

        //    public bool IsCollectorApplicant
        //    {
        //        get
        //        {
        //            return _isCollectorApplicant;
        //        }
        //        set
        //        {
        //            _isCollectorApplicant = value;

        //            if (_isCollectorApplicant && _applicant != null)
        //            {
        //                Surname = _applicant.Surname;
        //                OtherNames = _applicant.OtherNames;
        //                SelectedSex = _applicant.Sex;
        //                BirthDate = _applicant.BirthDate;
        //                SelectedDocumentType = _applicant.DocType;

        //                if (SelectedDocumentType.ID == (int)DocumentTypes.LesothoID)
        //                    IDPassportNumber = _applicant.IDNumber;
        //                else if (SelectedDocumentType.ID == (int)DocumentTypes.Passport)
        //                    IDPassportNumber = _applicant.PassportNumber;

        //                SelectedNationality = _applicant.Nationality;
        //                PhysicalAddress = _applicant.PhysicalAddress;
        //                PostalAddress = _applicant.PostalAddress;
        //                Telephone = _applicant.Phone;
        //                SelectedRelationship = AllRelationships.FirstOrDefault(x=>x.ID==(int)RelationshipTypes.Self);
        //            }
        //            else
        //            {
        //                Surname = null;
        //                OtherNames = null;
        //                SelectedSex = null;
        //                BirthDate = null;
        //                SelectedDocumentType = null;
        //                IDPassportNumber = null;
        //                SelectedNationality = null;
        //                PhysicalAddress = null;
        //                PostalAddress = null;
        //                Telephone = null;
        //                SelectedRelationship = null;
        //            }

        //            NotifyPropertyChanged(() => IsCollectorApplicant);
        //        }
        //    }

        //    [NipRequired]
        //    public string Surname
        //    {
        //        get
        //        {
        //            return _surname;
        //        }
        //        set
        //        {
        //            _surname = value;
        //            NotifyPropertyChanged(() => Surname);
        //        }
        //    }

        //    [NipRequired]
        //    public string OtherNames
        //    {
        //        get
        //        {
        //            return _otherNames;
        //        }
        //        set
        //        {
        //            _otherNames = value;
        //            NotifyPropertyChanged(() => OtherNames);
        //        }
        //    }

        //    [NipRequired]
        //    public Sex SelectedSex
        //    {
        //        get
        //        {
        //            return _selectedSex;
        //        }
        //        set
        //        {
        //            _selectedSex = value;
        //            NotifyPropertyChanged(() => SelectedSex);
        //        }
        //    }

        //    [NipRequired]
        //    [NipNotFuture]
        //    public DateTime? BirthDate
        //    {
        //        get
        //        {
        //            return _birthDate;
        //        }
        //        set
        //        {
        //            _birthDate = value;
        //            NotifyPropertyChanged(() => BirthDate);
        //        }
        //    }

        //    [NipRequired]
        //    public DocumentType SelectedDocumentType
        //    {
        //        get
        //        {
        //            return _selectedDocumentType;
        //        }
        //        set
        //        {
        //            _selectedDocumentType = value;
        //            NotifyPropertyChanged(() => SelectedDocumentType);
        //            NotifyPropertyChanged(() => IDNumberIsVisible);
        //        }
        //    }

        //    public bool IDNumberIsVisible
        //    {
        //        get
        //        {
        //            if (SelectedDocumentType != null)
        //            {

        //                if (SelectedDocumentType.ID == (int)DocumentTypes.LesothoID)
        //                    return true;

        //                if (SelectedDocumentType.ID == (int)DocumentTypes.Passport)
        //                    return false;
        //            }

        //            return true;
        //        }
        //    }

        //    [NipRequired]
        //    public string IDPassportNumber
        //    {
        //        get
        //        {
        //            return _idPassportNumber;
        //        }
        //        set
        //        {
        //            _idPassportNumber = value;
        //            NotifyPropertyChanged(() => IDPassportNumber);
        //        }

        //    }

        //    [NipRequired]
        //    public Nationality SelectedNationality
        //    {
        //        get
        //        {
        //            return _selectedNationality;
        //        }
        //        set
        //        {
        //            _selectedNationality = value;
        //            NotifyPropertyChanged(() => SelectedNationality);
        //        }

        //    }

        //    [NipRequired]
        //    public string PhysicalAddress
        //    {
        //        get
        //        {
        //            return _physicalAddress;
        //        }
        //        set
        //        {
        //            _physicalAddress = value;
        //            NotifyPropertyChanged(() => PhysicalAddress);
        //        }
        //    }

        //    [NipRequired]
        //    public string PostalAddress
        //    {
        //        get
        //        {
        //            return _postalAddress;
        //        }
        //        set
        //        {
        //            _postalAddress = value;
        //            NotifyPropertyChanged(() => PostalAddress);
        //        }
        //    }

        //    [NipRequired]
        //    public string Telephone
        //    {
        //        get
        //        {
        //            return _telephone;
        //        }
        //        set
        //        {
        //            _telephone = value;
        //            NotifyPropertyChanged(() => Telephone);
        //        }
        //    }

        //    [NipRequired]
        //    public Relationship SelectedRelationship
        //    {
        //        get
        //        {
        //            return _selectedRelationship;
        //        }
        //        set
        //        {
        //            _selectedRelationship = value;
        //            NotifyPropertyChanged(() => SelectedRelationship);
        //        }
        //    }

        //    #endregion

        //    #region commands

        //    private ICommand _printCommand;
        //    public ICommand PrintCommand
        //    {
        //        get
        //        {
        //            if (_printCommand == null)
        //                _printCommand = new RelayCommand(PrintExecute);

        //            return _printCommand;
        //        }
        //    }

        //    #endregion

        //    #region methods

        //    private void PrintExecute(object param)
        //    {
        //        if (!this.IsValid)
        //            return;

        //        Certificate cert = new Certificate();
        //        cert.CertificateStatus = new CertificateStatus() { ID = (int)CertificateStatuses.Printed };
        //        cert.CollectorRelationship = SelectedRelationship;
        //        cert.CollectorSex = SelectedSex;
        //        cert.CollectorNationality = SelectedNationality;
        //        //cert.LicenseID = todo sequence
        //        cert.SerialNo = int.Parse(SerialNo);
        //        cert.DatePrinted = DateTime.Now;
        //        cert.UserPrinted = LoggedUser.UserName;
        //        cert.DateCollected = DateTime.Now;
        //        cert.CollectorBirthDate = BirthDate;
        //        cert.CollectorSurname = Surname;
        //        cert.CollectorOtherNames = OtherNames;
        //        cert.CollectorPhysicalAddress = PhysicalAddress;
        //        cert.CollectorPostalAddress = PostalAddress;
        //        cert.CollectorTelephone = Telephone;

        //        if (SelectedDocumentType.ID == (int)DocumentTypes.LesothoID)
        //            cert.CollectorIDNumber = IDPassportNumber;
        //        else
        //            cert.CollectorPassportNo = IDPassportNumber;


        //        License lic = new License();
        //        //lic.ID = todo sequence
        //        lic.AppNo = _appNo;
        //        lic.IntrefNo = _intref;
        //        lic.ExpiryDate = DateTime.Now.AddMonths(6);
        //        lic.IssueDate = cert.DatePrinted;
        //        lic.LicenseDocType = AllLicenseDocTypes.FirstOrDefault(x => x.ID == (int)LicenseDocTypes.Temporary);
        //        lic.LicenseNo = LicenceHelper.CreateLicenceNumber(BirthDate.Value, _intref, IDPassportNumber, SelectedSex.ID, null);
        //        lic.LicenseStatus = new LicenseStatus() { ID = (int)LicenseStatuses.Active };
        //        lic.Certificate = cert;

        //        DrivingLicenceService.SaveLicence(lic);
        //    }


        //    //close current viewmodel

        //}

        //#endregion
    }
}

