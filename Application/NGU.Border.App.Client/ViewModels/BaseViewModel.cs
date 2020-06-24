using NGU.App.DTO;
using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.ApiAdmin;
using NGU.Interfaces.Services;
using NGU.Common.Utilities;
using Pangea.BaseStructures;
using Pangea.Extensions;
using Pangea.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Admin = NGU.Interfaces.ApiAdmin;
using Pangea.App.Utils;
using Pangea.App.Services;
using Languages = Pangea.MultiLanguage.Languages;

namespace NGU.App.Client.ViewModels
{
    [class: NonSerialized]
    public abstract class BaseViewModel : ValidationViewModelBase, Interfaces.INotifier, IViewModel
    {
        public static MainViewModel WindowModel = null;

        private ObservableCollection<Language> _allLanguages;
   

        #region ctor

        public BaseViewModel()
        {
        }

        #endregion

        #region props

        public static Languages DefaultModuleLanguage { get; set; }

        public DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }

        public object RegistrationButton { get; set; }

        public object SearchButton { get; set; }

        public object ClearButton { get; set; }

        public static User LoggedUser
        {
            get
            {
                return AppSettingsHelper.LoggedUser;
            }
            set
            {
                AppSettingsHelper.LoggedUser = value;
            }
        }

        public int AmountColumns
        {
            get
            {
                //too: calc dynamically
                return 1;
            }
        }

        public ObservableCollection<Language> AllLanguages
        {
            get
            {
                if (_allLanguages != null && _allLanguages.Count > 0)
                    return _allLanguages;

                _allLanguages = new ObservableCollection<Language>();

                IEnumerable<Languages> values = Enum.GetValues(typeof(Languages)).Cast<Languages>();
                foreach (Languages item in values)
                {
                    Language lng = new Language();
                    lng.Code = item.ToString();
                    lng.Name = item.GetStringValue();
                    object obj = Application.Current.TryFindResource(item.GetResourceKey());
                    lng.Image = obj;
                    _allLanguages.Add(lng);
                }

                return _allLanguages;
            }
        }

        public ValueObjectProxy Lookups
        {
            get
            {
                return ValueObjectProxy.Instance;
            }
        }



      
        public static int MaxSearchResults
        {
            get
            {
                SystemParameter param = Channels.GetSystemSettingsValue(SystemSettingsKeys.MAX_SEARCH_RESULTS);
                if (param != null)
                    return int.Parse(param.Value);

                return 0;
            }
        }

        #endregion

        #region event

        public delegate void NotifyContainerEventHandler(object sender, object param);

        public static event NotifyContainerEventHandler NotifyContainer;

        protected virtual void OnNotifyContainer(object param)
        {
            if (NotifyContainer != null)
                NotifyContainer(this, param);
        }

        #endregion

        #region services instances

        public static Pangea.DialogService.DialogService DialogService
        {
            get
            {
                return new Pangea.DialogService.DialogService();
            }
        }

        public static IUserService UserService
        {
            get
            {
                return Channels.UserService; 
            }
        }

        public static IValueObjectService ValueObjectService
        {
            get
            {
                return Channels.ValueObjectService;
            }
        }

        public static ISystemService SystemService
        {
            get
            {
                return Channels.SystemService;
            }
        }

        #endregion

        #region Workflow pages
        #region IViewInfo Implementation
        //public virtual string ViewText { get; set; }
        //public ViewModelName ViewName { get; set; }

        #endregion

        public event Action<string, NotificationAreaType> OnNotifcation;

        public event Action<ViewModelName> ViewModelChange;
        public static event Action<BaseViewModel> ViewModelInstanceChanged;

        public static event Action<bool> OnReadOnlyMode;

        public static event Action<bool, Operations?> OnIsEnableOperation;
        public static event Action<Operations> OnRaisCanExecuteOperation;

        protected void ChangeViewModel(ViewModelName viewModel)
        {
            if (ViewModelChange != null)
            {
                ViewModelChange(viewModel);
            }
        }

        protected void ChangeViewModelInstance(BaseViewModel viewModel)
        {
            if (ViewModelInstanceChanged != null)
            {
                ViewModelInstanceChanged(viewModel);
            }
        }

        public void ShowNotification(string notification, NotificationAreaType type)
        {
            if (OnNotifcation != null)
            {
                OnNotifcation(notification, type);
            }
        }

        public void ShowNotification(NotificationMessages message, NotificationAreaType type)
        {
            if (OnNotifcation != null)
            {
                string resourceKey = message.GetResourceKey();
                string resource = Lang.Resources.ResourceManager.GetString(resourceKey);
                if (resource != null)
                {
                    OnNotifcation(resource, type);
                }
            }
        }

        protected void SetReadOnlyMode(bool value)
        {
            if (OnReadOnlyMode != null)
                OnReadOnlyMode(value);
        }

        protected void RaisCanExecuteOperation(Operations operation)
        {
            OnRaisCanExecuteOperation?.Invoke(operation);
        }

        protected void SetIsEnableOperation(bool value, Operations? buttonOperation)
        {
            if (OnIsEnableOperation != null)
                OnIsEnableOperation(value, buttonOperation);
        }

        protected void ClearNotification()
        {
            if (OnNotifcation != null)
            {
                OnNotifcation(string.Empty, NotificationAreaType.Success);
            }
        }

        public virtual bool HasChanged { get; }
        private bool _scrollToNewRow;


        public bool ScrollToNewRow
        {
            set
            {
                _scrollToNewRow = value;

                NotifyPropertyChanged(() => ScrollToNewRow);
            }
            get
            {
                return _scrollToNewRow;
            }
        }

        public virtual bool Validate(ref NotificationMessages msg)
        {
            return true;
        }

        public virtual void ResetPage()
        {
        }
        #endregion
    }
}
