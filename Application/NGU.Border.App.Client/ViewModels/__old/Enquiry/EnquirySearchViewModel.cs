using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using NGU.Admin.Interfaces;
using Pangea.Client.WPF.CustomControls;
using NGU.Common.Structs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NGU.Admin.App.Client.ViewModels
{
    public class EnquirySearchViewModel : BaseViewModel
    {
        #region ctor

        public EnquirySearchViewModel()
        {
            //SearchButton = new ActionButton()
            //{
            //    ButtonToolTip = Application.Current.Resources["Search"].ToString(),
            //    ButtonImage = Application.Current.TryFindResource("SearchImage"),
            //    ButtonCommand = SearchCommand,
            //};

            //ClearButton = new ActionButton()
            //{
            //    ButtonToolTip = Application.Current.Resources["Clear"].ToString(),
            //    ButtonImage = Application.Current.TryFindResource("ClearImage"),
            //    ButtonCommand = ClearCommand,
            //};
        }

        #endregion

        //#region members

        //private SearchTypes _searchType;
        //private List<Menu> _allScreens;
        //private List<Menu> _selectedScreens = new List<Menu>();
        //private PersonDTO _selectedPerson;
        //private ObservableCollection<PersonDTO> _persons;

        //private string _appNo;
        //private DateTime? _appRegDate;
        //private DateTime? _appIssueDate;
        //private ApplicationType _selectedAppType;
        //private ApplicationStatus _selectedAppCurrentStatus;
        //private string _personIDNumber;
        //private string _personIntrefNo;
        //private string _personSurname;
        //private string _personOtherNames;
        //private bool _personExactNames;
        //private DateTime? _personBirthDate;
        //private Sex _selectedPersonSex;
        //private string _licenseIntrefNo;
        //private DateTime? _licenseIssueDate;
        //private LicenseType _selectedLicenseType;
        //private string _licenseSerialNo;
        //private string _licenseNo;

        //private ICommand _searchCommand;
        //private ICommand _clearCommand;

        //#endregion

        //#region props

        //public PersonDTO SelectedPerson
        //{
        //    get
        //    {
        //        return _selectedPerson;
        //    }

        //    set
        //    {
        //        _selectedPerson = value;
        //        NotifyPropertyChanged(() => SelectedPerson);

        //        //save aside for future use
        //        if (_selectedPerson != null && _selectedPerson.Interef > 0)
        //        {
        //            OnNotifyContainer("clear");
        //            BaseContainerViewModel.EquiryPersonIntref = _selectedPerson.Interef.ToString();
        //        }

        //        //notify container to re-enable menus
        //        OnNotifyContainer(null);
        //    }
        //}

        //public List<Menu> SelectedScreens
        //{
        //    get
        //    {
        //        return _selectedScreens;
        //    }
        //    set
        //    {
        //        _selectedScreens = value;

        //        if (_selectedScreens == null)
        //            _selectedScreens = new List<Menu>();

        //        NotifyPropertyChanged(() => SelectedScreens);
        //    }
        //}

        //#region datasources and lists

        //public ObservableCollection<PersonDTO> Persons
        //{
        //    get
        //    {
        //        if (_persons == null)
        //            _persons = new ObservableCollection<PersonDTO>();

        //        return _persons;
        //    }
        //    set
        //    {
        //        _persons = value;
        //        NotifyPropertyChanged(() => Persons);
        //    }
        //}

        //public List<Menu> AllScreens
        //{
        //    get
        //    {
        //        if (_allScreens == null)
        //        {
        //            _allScreens = new List<Menu>();
        //            foreach (var menu in LoggedUser.Menus)
        //            {
        //                foreach (ApplicationStatuses status in menu.FilteredAccessibilityAppStatuses)
        //                {
        //                    if (AllApplicationStatuses.Any(x => x.ID == (int)status))
        //                    {
        //                        if (_allScreens.All(x => x.MenuId != menu.MenuId) && menu.MenuId != (int)ViewModelTypes.RegistraionContainer && menu.ParentID != null)
        //                            _allScreens.Add(menu);
        //                    }
        //                }
        //            }
        //        }

        //        return _allScreens;
        //    }
        //}

        //#endregion

        //#region applicationDeatils

        //public SearchTypes SearchType
        //{
        //    get
        //    {
        //        return _searchType;
        //    }

        //    set
        //    {
        //        _searchType = value;
        //        NotifyPropertyChanged(() => SearchType);
        //    }
        //}

        //[ApplicationNumberLengthValidator]
        //public string AppNo
        //{
        //    get
        //    {
        //        return _appNo;
        //    }

        //    set
        //    {
        //        _appNo = value;
        //        NotifyPropertyChanged(() => AppNo);
        //    }
        //}

        //public DateTime? AppRegDate
        //{
        //    get
        //    {
        //        return _appRegDate;
        //    }

        //    set
        //    {
        //        _appRegDate = value;
        //        NotifyPropertyChanged(() => AppRegDate);
        //    }
        //}

        //public DateTime? AppIssueDate
        //{
        //    get
        //    {
        //        return _appIssueDate;
        //    }

        //    set
        //    {
        //        _appIssueDate = value;
        //        NotifyPropertyChanged(() => AppIssueDate);
        //    }
        //}

        //public ApplicationType SelectedAppType
        //{
        //    get
        //    {
        //        return _selectedAppType;
        //    }

        //    set
        //    {
        //        _selectedAppType = value;
        //        NotifyPropertyChanged(() => SelectedAppType);
        //    }
        //}

        //public ApplicationStatus SelectedAppCurrentStatus
        //{
        //    get
        //    {
        //        return _selectedAppCurrentStatus;
        //    }

        //    set
        //    {
        //        _selectedAppCurrentStatus = value;
        //        NotifyPropertyChanged(() => SelectedAppCurrentStatus);
        //    }
        //}

        //#endregion

        //#region personalDeatils

        //public string PersonIDNumber
        //{
        //    get
        //    {
        //        return _personIDNumber;
        //    }

        //    set
        //    {
        //        _personIDNumber = value;
        //        NotifyPropertyChanged(() => PersonIDNumber);
        //    }
        //}

        //[PersonIntrefNoLengthValidator]
        //public string PersonIntrefNo
        //{
        //    get
        //    {
        //        return _personIntrefNo;
        //    }

        //    set
        //    {
        //        _personIntrefNo = value;
        //        NotifyPropertyChanged(() => PersonIntrefNo);
        //    }
        //}

        //public string PersonSurname
        //{
        //    get
        //    {
        //        return _personSurname;
        //    }

        //    set
        //    {
        //        _personSurname = value;
        //        NotifyPropertyChanged(() => PersonSurname);
        //    }
        //}

        //public string PersonOtherNames
        //{
        //    get
        //    {
        //        return _personOtherNames;
        //    }

        //    set
        //    {
        //        _personOtherNames = value;
        //        NotifyPropertyChanged(() => PersonOtherNames);
        //    }
        //}

        //public bool PersonExactNames
        //{
        //    get
        //    {
        //        return _personExactNames;
        //    }

        //    set
        //    {
        //        _personExactNames = value;
        //        NotifyPropertyChanged(() => PersonExactNames);
        //    }
        //}

        //public DateTime? PersonBirthDate
        //{
        //    get
        //    {
        //        return _personBirthDate;
        //    }

        //    set
        //    {
        //        _personBirthDate = value;
        //        NotifyPropertyChanged(() => PersonBirthDate);
        //    }
        //}

        //public Sex SelectedPersonSex
        //{
        //    get
        //    {
        //        return _selectedPersonSex;
        //    }

        //    set
        //    {
        //        _selectedPersonSex = value;
        //        NotifyPropertyChanged(() => SelectedPersonSex);
        //    }
        //}

        //#endregion

        //#region licenseDetails

        //[LicenseIntrefNoLengthValidator]
        //public string LicenseIntrefNo
        //{
        //    get
        //    {
        //        return _licenseIntrefNo;
        //    }

        //    set
        //    {
        //        _licenseIntrefNo = value;
        //        NotifyPropertyChanged(() => LicenseIntrefNo);
        //    }
        //}

        //public DateTime? LicenseIssueDate
        //{
        //    get
        //    {
        //        return _licenseIssueDate;
        //    }

        //    set
        //    {
        //        _licenseIssueDate = value;
        //        NotifyPropertyChanged(() => LicenseIssueDate);
        //    }
        //}

        //public LicenseType SelectedLicenseType
        //{
        //    get
        //    {
        //        return _selectedLicenseType;
        //    }

        //    set
        //    {
        //        _selectedLicenseType = value;
        //        NotifyPropertyChanged(() => SelectedLicenseType);
        //    }
        //}

        //[LicenseSerialNoLengthValidator]
        //public string LicenseSerialNo
        //{
        //    get
        //    {
        //        return _licenseSerialNo;
        //    }

        //    set
        //    {
        //        _licenseSerialNo = value;
        //        NotifyPropertyChanged(() => LicenseSerialNo);
        //    }
        //}

        //public string LicenseNo
        //{
        //    get
        //    {
        //        return _licenseNo;
        //    }

        //    set
        //    {
        //        _licenseNo = value;
        //        NotifyPropertyChanged(() => LicenseNo);
        //    }
        //}

        //#endregion

        //#endregion

        //#region commands

        //public ICommand SearchCommand
        //{
        //    get
        //    {
        //        if (_searchCommand == null)
        //            _searchCommand = new RelayCommand(SearchExecute);

        //        return _searchCommand;
        //    }
        //}

        //public ICommand ClearCommand
        //{
        //    get
        //    {
        //        if (_clearCommand == null)
        //            _clearCommand = new RelayCommand(ClearExecute);

        //        return _clearCommand;
        //    }
        //}

        //#endregion

        //#region methods

        //private void ClearAndResetGrid()
        //{
        //    Persons = null;
        //    SelectedPerson = null;
        //    BaseContainerViewModel.EquiryPersonIntref = null;
        //    OnNotifyContainer("clear");
        //}

        //private void SearchExecute(object param)
        //{
        //    ClearAndResetGrid();
            
        //    SearchDTO searchDto = new SearchDTO()
        //    {
        //        SearchType = SearchType,
        //        AppNo = !AppNo.IsNullOrEmpty() ? long.Parse(AppNo) : (long?)null,
        //        AppRegDate = AppRegDate,
        //        AppIssueDate = AppIssueDate,
        //        AppTypeID = SelectedAppType != null ? SelectedAppType.ID : (int?)null,
        //        AppCurrentStatusID = SelectedAppCurrentStatus != null ? SelectedAppCurrentStatus.ID : (int?)null,
        //        SelectedScreens = SelectedScreens.Select(x => x.MenuId).ToList<int>(),
        //        AllowedApplicationStatuses = AllApplicationStatuses.Select(x => x.ID).ToList(),
        //        PersonIDNumber = PersonIDNumber,
        //        PersonIntrefNo = PersonIntrefNo,
        //        PersonSurname = PersonSurname,
        //        PersonOtherNames = PersonOtherNames,
        //        PersonExactNames = PersonExactNames,
        //        PersonBirthDate = PersonBirthDate,
        //        PersonSex = SelectedPersonSex != null ? SelectedPersonSex.ID : null,
        //        LicenseIntrefNo = LicenseIntrefNo,
        //        LicenseIssueDate = LicenseIssueDate,
        //        LicenseTypeID = SelectedLicenseType != null ? SelectedLicenseType.ID : (int?)null,
        //        LicenseSerialNo = !LicenseSerialNo.IsNullOrEmpty() ? int.Parse(LicenseSerialNo) : (int?)null,
        //        LicenseNo = LicenseNo
        //    };

        //    //TODO::::: check legality of search params

        //    List<PersonDTO> res = DrivingLicenceService.GetPersonsForEnquiryScreen(searchDto);
        //    Persons = new ObservableCollection<PersonDTO>(res);
        //}

        //private void ClearExecute(object param)
        //{
        //    //search params
        //    AppNo = null;
        //    AppRegDate = null;
        //    AppIssueDate = null;
        //    SelectedAppType = null;
        //    SelectedAppCurrentStatus = null;
        //    SelectedScreens = null;

        //    PersonIDNumber = null;
        //    PersonIntrefNo = null;
        //    PersonSurname = null;
        //    PersonOtherNames = null;
        //    PersonExactNames = false;
        //    PersonBirthDate = null;
        //    SelectedPersonSex = null;

        //    LicenseIntrefNo = null;
        //    LicenseIssueDate = null;
        //    SelectedLicenseType = null;
        //    LicenseSerialNo = null;
        //    LicenseNo = null;

        //    ClearAndResetGrid();
        //}

        //#endregion
    }
}
