using NGU.App.Client.Validators;
using NGU.App.DTO;
using NGU.Core;
using NGU.Enums;
using Pangea.Extensions;
using Pangea.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin = NGU.Interfaces.ApiAdmin;


namespace NGU.App.Client.ViewModels
{
    public class SearchUserControlViewModel : BaseViewModel
    {
        public SearchUserControlViewModel(SearchUserControlMode searchUserControl)
        {
            FillRequestStatusDtoList();
            SearchMode = searchUserControl;
        }

        #region members

        private Admin.IdenType _selectedIDType;
        private string _iDNumber;
        private Admin.Country _selectedCountry;
        private DateTime? _createdFrom;
        private DateTime? _createdTo;
        private string _firstName;
        private string _lastName;
        private bool _isPartial;
        private RequestType _selectedRequestType;
        private string _requestNo;
        private RequestStatusDTO _selectedRequestStatus;
        private string _internalFileNo;
        private string _blackListRecordNo;
        private List<RequestStatusDTO> _allRequestStatusDTOs;
        private SearchUserControlMode _searchMode;

        #endregion

        #region props 

        public List<RequestStatusDTO> AllRequestStatusDTOs
        {
            get
            {
                if (SearchMode == SearchUserControlMode.DataEntry)
                    return _allRequestStatusDTOs.Where(x => x.Code == RequestStatuses.Open.GetStringValue()).ToList();
                //todo: check regarding waitForApproval and BL-active

                if (SearchMode == SearchUserControlMode.DecisionMaking)
                    return _allRequestStatusDTOs.Where(x => x.Code == RequestStatuses.SentForProcessing.GetStringValue()).ToList();

                if (SearchMode == SearchUserControlMode.Enquiries)
                    return _allRequestStatusDTOs;

                return _allRequestStatusDTOs;
            }
        }

        public SearchUserControlMode SearchMode
        {
            get
            {
                return _searchMode;
            }
            set
            {
                _searchMode = value;

                if (_searchMode == SearchUserControlMode.DecisionMaking || _searchMode == SearchUserControlMode.DataEntry)
                    _selectedRequestStatus = AllRequestStatusDTOs.First();

                NotifyPropertyChanged(() => SearchMode);
            }
        }

        public Admin.IdenType SelectedIDType
        {
            get
            {
                return _selectedIDType;
            }
            set
            {
                _selectedIDType = value;
                NotifyPropertyChanged(() => SelectedIDType);
            }
        }

        public string IDNumber
        {
            get
            {
                return _iDNumber;
            }
            set
            {
                _iDNumber = value;
                NotifyPropertyChanged(() => IDNumber);
            }
        }

        public Admin.Country SelectedCountry
        {
            get
            {
                return _selectedCountry;
            }
            set
            {
                _selectedCountry = value;
                NotifyPropertyChanged(() => SelectedCountry);
            }
        }

        [CreatedDateFromBeforeDateTo]
        public DateTime? CreatedFrom
        {
            get
            {
                return _createdFrom;
            }
            set
            {
                _createdFrom = value;
                NotifyPropertyChanged(() => CreatedFrom);
                NotifyPropertyChanged(() => CreatedTo);
            }
        }

        [CreatedDateFromBeforeDateTo]
        public DateTime? CreatedTo
        {
            get
            {
                return _createdTo;
            }
            set
            {
                _createdTo = value;
                NotifyPropertyChanged(() => CreatedTo);
                NotifyPropertyChanged(() => CreatedFrom);
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyPropertyChanged(() => FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyPropertyChanged(() => LastName);
            }
        }

        public bool IsPartial
        {
            get
            {
                return _isPartial;
            }
            set
            {
                _isPartial = value;
                NotifyPropertyChanged(() => IsPartial);
            }
        }

        public RequestType SelectedRequestType
        {
            get
            {
                return _selectedRequestType;
            }
            set
            {
                _selectedRequestType = value;
                NotifyPropertyChanged(() => SelectedRequestType);
            }
        }

        public string RequestNo
        {
            get
            {
                return _requestNo;
            }
            set
            {
                _requestNo = value;
                NotifyPropertyChanged(() => RequestNo);
            }
        }

        public RequestStatusDTO SelectedRequestStatus
        {
            get
            {
                return _selectedRequestStatus;
            }
            set
            {
                _selectedRequestStatus = value;
                NotifyPropertyChanged(() => SelectedRequestStatus);
            }
        }

        public string InternalFileNo
        {
            get
            {
                return _internalFileNo;
            }
            set
            {
                _internalFileNo = value;
                NotifyPropertyChanged(() => InternalFileNo);
            }
        }

        public string BlackListRecordNo
        {
            get
            {
                return _blackListRecordNo;
            }
            set
            {
                _blackListRecordNo = value;
                NotifyPropertyChanged(() => BlackListRecordNo);
            }
        }

        public bool IsSelectedRequestStatusEnabled
        {
            get
            {
                switch (SearchMode)
                {
                    case SearchUserControlMode.DataEntry:
                        return false;
                    case SearchUserControlMode.DecisionMaking:
                        return false;
                    case SearchUserControlMode.Enquiries:
                    default:
                        return true;
                        break;
                }
            }
        }

        #endregion

        #region private methods

        private void FillRequestStatusDtoList()
        {
            _allRequestStatusDTOs = new List<RequestStatusDTO>();

            foreach (var item in Lookups.RequestStatuses)
            {
                _allRequestStatusDTOs.Add(new RequestStatusDTO() { ID = item.ID, Code = item.Code, Name = item.Name, Description = item.Description });
            }
        }

        #endregion
    }
}
