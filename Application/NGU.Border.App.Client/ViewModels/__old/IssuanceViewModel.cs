using NGU.Admin.App.Client.Utitlities;
using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using NGU.Admin.Interfaces;
using Pangea.Client.WPF.CustomControls;
using NGU.Common.Structs;
using NGU.Common.Utilities;
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
    public class IssuanceViewModel : BaseViewModel//, IModuleFunctions
    {
        //#region members

        //private bool _setFirstFocus;
        //private Menu _currentMenu;

        //private SearchTypes _searchType;
        //private ICommand _changeCurrentViewCommand;
        //private ICommand _searchCommand;
        //private ICommand _clearCommand;

        //private List<Menu> _allScreens;
        //private List<Menu> _selectedScreens = new List<Menu>();
        //private ApplicationDTO _selectedApplication;
        //private ObservableCollection<ApplicationDTO> _applications;

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


        //#endregion

        #region ctor
        public IssuanceViewModel()
        {
        }
        public IssuanceViewModel(Menu menu)
        {


            //_currentMenu = menu;

            //IntitApplications();

            //#region initiate main buttons

            //RegistrationButton = new ActionButton()
            //{
            //    //ButtonText = "aaaaaa",
            //    ButtonToolTip = Application.Current.Resources["RegisterApp"].ToString(),
            //    ButtonImage = Application.Current.TryFindResource("NewRegistrationImage"),
            //    ButtonCommand = ChangeCurrentViewCommand,
            //    ButtonCommandParameter = ViewModelTypes.RegistraionContainer,
            //    ButtonIsEnabled = LoggedUser.Menus.FirstOrDefault(x => x.MenuId == (int)ViewModelTypes.RegistraionContainer && x.IsPermitted == true) != null
            //};

            //SearchButton = new ActionButton()
            //{
            //    //ButtonText = "",
            //    ButtonToolTip = Application.Current.Resources["Search"].ToString(),
            //    ButtonImage = Application.Current.TryFindResource("SearchImage"),
            //    ButtonCommand = SerachCommand,
            //};

            //ClearButton = new ActionButton()
            //{
            //    //ButtonText = "",
            //    ButtonToolTip = Application.Current.Resources["Clear"].ToString(),
            //    ButtonImage = Application.Current.TryFindResource("ClearImage"),
            //    ButtonCommand = ClearCommand,
            //};
            ////button color 0C3552
            //#endregion
        }

        private void IntitApplications()
        {
            //this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() => SetFirstFocus = true));
            //SearchType = SearchTypes.ApplicationDetails;
            //List<int> alowedStatuses = CalculateAllowedStatuses();

            //SearchDTO searchdto = new SearchDTO()
            //{
            //    SearchType = SearchTypes.ApplicationDetails,
            //    AllowedApplicationStatuses = alowedStatuses
            //};

            //List<ApplicationDTO> res = DrivingLicenceService.GetApplicationsForIssuanceScreen(searchdto);
            //Applications = new ObservableCollection<ApplicationDTO>(res);
        }

        private static List<int> CalculateAllowedStatuses()
        {
            IList<Menu> menus = LoggedUser.Menus.Where(x => x.IsPermitted == true).ToList();
            List<List<ApplicationStatuses>> alowedStatusesList = menus.Select(x => x.FilteredAccessibilityAppStatuses).ToList();
            List<int> alowedStatuses = new List<int>();

            foreach (var asl in alowedStatusesList)
            {
                foreach (var s in asl)
                {
                    if (!alowedStatuses.Contains((int)s))
                    {
                        alowedStatuses.Add((int)s);
                    }
                }
            }

            return alowedStatuses;
        }

        #endregion

        //#region methods

        //private void ChangeCurrentView(object param)
        //{
        //    ////NotifyStatusBar(true);

        //    ////in case newRegbutton has been pressed whhile selectedApplication on grid exists we must ignore it
        //    //if (param != null)
        //    //    SelectedApplication = null;

        //    //Menu menu = param as Menu;

        //    //if (menu == null)
        //    //{
        //    //    if (SelectedApplication != null)
        //    //    {
        //    //        BaseContainerViewModel.CurrentApplication = SelectedApplication;

        //    //        ApplicationDL currApplication = DrivingLicenceService.GetApplicationByAppNo(SelectedApplication.AppNo);

        //    //        WindowModel.CurrentViewModel = AppUtilities.RequestStatusToScreenNavigation(currApplication, _currentMenu.SubMenus.ToList());
        //    //    }
        //    //    else
        //    //    {
        //    //        //if registration
        //    //        if (param != null)
        //    //            WindowModel.CurrentViewModel = AppUtilities.RequestStatusToScreenNavigation(null, _currentMenu.SubMenus.ToList());
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    WindowModel.CurrentViewModel = AppUtilities.GetViewModel(menu.MenuId, param);
        //    //}


        //    //// var menu = LoggedUser.Menus.First(x => x.MenuId == 15);
        //    //// WindowModel.CurrentViewModel = AppUtilities.GetViewModel(ViewModelTypes.QAContainer, menu);
        //}

        //private void Search(object param)
        //{
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

        //    //List<ApplicationDTO> res = DrivingLicenceService.GetApplicationsForIssuanceScreen(searchDto);
        //    //Applications = new ObservableCollection<ApplicationDTO>(res);
        //}

        //private void Clear(object param)
        //{
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

        //    Applications = null;

        //    ProcessHelper.RunMethodOnDifferentTask(() =>
        //    {
        //        SearchDTO searchdto = new SearchDTO()
        //        {
        //            SearchType = SearchTypes.ApplicationDetails,
        //            AllowedApplicationStatuses = AllApplicationStatuses.Select(x => x.ID).ToList()
        //        };

        //        List<ApplicationDTO> res = DrivingLicenceService.GetApplicationsForIssuanceScreen(searchdto);
        //        Applications = new ObservableCollection<ApplicationDTO>(res);
        //    });
        //}

        //public override void Refresh()
        //{
        //    SelectedApplication = null;
        //    IntitApplications();
        //}

        //public override bool IsSaveVisibile()
        //{
        //    return false;
        //}

        //#endregion

        //#region Commands

        ////TODO: move commands to common vm!!!!
        //public ICommand ChangeCurrentViewCommand
        //{
        //    get
        //    {
        //        if (_changeCurrentViewCommand == null)
        //        {
        //            _changeCurrentViewCommand = new RelayCommand(param => ChangeCurrentView(param));
        //        }

        //        return _changeCurrentViewCommand;
        //    }
        //}

        //public ICommand SerachCommand
        //{
        //    get
        //    {
        //        if (_searchCommand == null)
        //            _searchCommand = new RelayCommand(Search);

        //        return _searchCommand;
        //    }
        //}

        //public ICommand ClearCommand
        //{
        //    get
        //    {
        //        if (_clearCommand == null)
        //            _clearCommand = new RelayCommand(Clear);

        //        return _clearCommand;
        //    }
        //}

        //#endregion Commands

        //#region props

        //public bool SetFirstFocus
        //{
        //    get
        //    {
        //        return _setFirstFocus;
        //    }
        //    set
        //    {
        //        _setFirstFocus = value;
        //        NotifyPropertyChanged(() => SetFirstFocus);
        //        if (value)
        //        {
        //            _setFirstFocus = false;
        //            NotifyPropertyChanged(() => SetFirstFocus);
        //        }
        //    }
        //}

        //public ApplicationDTO SelectedApplication
        //{
        //    get
        //    {
        //        return _selectedApplication;
        //    }

        //    set
        //    {
        //        _selectedApplication = value;
        //        NotifyPropertyChanged("SelectedApplicantion");
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

        //public ObservableCollection<ApplicationDTO> Applications
        //{
        //    get
        //    {
        //        if (_applications == null)
        //            _applications = new ObservableCollection<ApplicationDTO>();

        //        return _applications;
        //    }
        //    set
        //    {
        //        _applications = value;
        //        NotifyPropertyChanged(() => Applications);
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

        //public MessageDialogDTO Save()
        //{
        //    return new MessageDialogDTO();
        //}

        //public void Cancel()
        //{

        //}

        //bool IModuleFunctions.IsValid()
        //{
        //    return IsValid;
        //}

        //public void PreSave()
        //{

        //}

        //public bool HasChanged
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        //public bool CanSwitch
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
    }
}
