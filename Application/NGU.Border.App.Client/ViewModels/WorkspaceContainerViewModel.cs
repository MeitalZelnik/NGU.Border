using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using NGU.Core;
using NGU.App.Client.Utitlities;
using NGU.App.DTO;
using Pangea.App.Utils;
using Pangea.Extensions;
using Pangea.BaseStructures;
using NGU.Enums;
using NGU.Common.Utilities;
using System.Windows;

namespace NGU.App.Client.ViewModels
{
    class WorkspaceContainerViewModel : BaseViewModel
    {
        #region privates
        #endregion
        private ICommand _changeCurrentViewCommand = null;
        private string _notificationText;
        private NotificationAreaType _notificationType;
        private MenuNodeDTO _module;
        private MenuNodeDTO _currentMenu;
        private MenuNodeDTO _selectedMenu;
        private IList<Pangea.App.Menu.Menu> _subMenu;
        private IList<MenuNodeDTO> _subMenuDTO;
        public BaseViewModel _currentViewModel;
        private DetailsViewModel _detailsViewModel;
        private static IList<MenuNodeDTO> _rootMenu;
        private Dictionary<OperationButton, bool> _buttonsStatus;

        #region Ctor
        public WorkspaceContainerViewModel(MenuNodeDTO module)
        {
            Module = module;

            //ViewText = module.Name;

            OnReadOnlyMode += MainWindowViewModel_OnReadOnlyMode;
            OnIsEnableOperation += MainWindowViewModel_OnIsEnableOperation;
            OnRaisCanExecuteOperation += WorkspaceContainerViewModel_OnRaisCanExecuteOperation;
            ViewModelInstanceChanged += WorkspaceContainerViewModel_ViewModelInstanceChanged;
            AppUtilities.CurrentAppChanged += JumpToSubMenu;

            Buttons = new ObservableCollection<OperationButton>();

            // Initalize the menu
            _subMenu = Pangea.App.Menu.MenuUtils.GetSubMenus(_module.MenuId);
            var x3 = MenuUtilities.ConvertToMenuDTO(_subMenu, _module);
            var v = x3.FirstOrDefault();

            if (_module.IsProcess)
            {
                AppUtilities.CurrentApp = new Request();
                // FOR DEBUG
                SelectedMenu = Menu.FirstOrDefault();
                //SelectedMenu = Menu.Where(x => x.MenuId == 12).FirstOrDefault();
            }
            else
                CurrentViewModel = new WelcomeViewModel(module.Name);
        }

        private void WorkspaceContainerViewModel_ViewModelInstanceChanged(BaseViewModel obj)
        {
            Application.Current.Dispatcher.Invoke(() => CurrentViewModel = obj);
        }

        public override string ViewText
        {
            get
            {
                if (Module != null)
                    return Module.Name;
                else
                    return "";
            }
        }

        void MainWindowViewModel_OnReadOnlyMode(bool value)
        {
            OperationButton button = Buttons.FirstOrDefault(b => b.Text == Lang.Resources.ResourceManager.GetString(Operations.Add.GetResourceKey()));
            if (button != null)
            {
                button.IsEnabled = !value;
            }
        }
        #endregion


        #region Props

        public Request CurrentApp
        {
            get { return AppUtilities.CurrentApp; }
        }

        public DetailsViewModel DetailsViewModel
        {
            get
            {
                if (_detailsViewModel == null)
                {
                    _detailsViewModel = new DetailsViewModel();
                    _detailsViewModel.OnNotifcation += CurrentViewModel_OnNotifcation;
                }
                return _detailsViewModel;
            }
            set
            {
                _detailsViewModel = value;
                if (_detailsViewModel != null)
                    _detailsViewModel.OnNotifcation += CurrentViewModel_OnNotifcation;
                NotifyPropertyChanged();
            }
        }

        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                WindowModel.CurrentViewModel = _currentViewModel;

                if (CurrentViewModel != null)
                {
                    CurrentViewModel.OnNotifcation += CurrentViewModel_OnNotifcation;
                    NotificationText = null;
                    SetOperationButtons(CurrentViewModel);
                }

                NotifyPropertyChanged(() => CurrentViewModel);
            }
        }

        public MenuNodeDTO Module
        {
            get
            {
                return _module;
            }
            set
            {
                _module = value;
                NotifyPropertyChanged();
            }
        }

        public IList<MenuNodeDTO> Menu
        {
            get
            {
                if (_subMenuDTO == null)
                    _subMenuDTO = MenuUtilities.ConvertToMenuDTO(_subMenu, _module);
                return _subMenuDTO;
            }
        }

        public MenuNodeDTO SelectedMenu
        {
            get
            {
                return _selectedMenu;
            }
            set
            {
                _selectedMenu = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(() => IsSearchEnabled);
                NotifyPropertyChanged(() => ShowDetailsBox);
                ChangeCurrentView();
            }
        }


        public override bool HasChanged
        {
            get
            {
                return _currentViewModel.HasChanged;
            }
        }

        public ObservableCollection<OperationButton> Buttons { get; set; }

        public string NotificationText
        {
            get
            {
                return _notificationText;
            }
            set
            {
                _notificationText = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(() => NotificationVisibillity);
            }
        }

        public NotificationAreaType NotificationType
        {
            get
            {
                return _notificationType;
            }
            set
            {
                _notificationType = value;
                NotifyPropertyChanged();
            }
        }

        public bool NotificationVisibillity
        {
            get
            {
                return !string.IsNullOrEmpty(NotificationText);
            }
        }

        public bool IsSearchEnabled
        {
            get
            {
                return SelectedMenu != null && SelectedMenu.Equals(Menu.FirstOrDefault());
            }
        }

        public bool ShowDetailsBox
        {
            get
            {
                return SelectedMenu != null && SelectedMenu.ShowDetailsBox;
            }
        }

        public static IList<MenuNodeDTO> RootMenu
        {
            get
            {
                if (_rootMenu == null)
                {
                    IList<Pangea.App.Menu.Menu> menus = Pangea.App.Menu.MenuUtils.GetRootMenu(1000);
                    _rootMenu = MenuUtilities.ConvertToMenuDTO(menus);
                }
                return _rootMenu;
            }
        }

        #endregion

        #region Commands
        /// <summary>
        /// Gets a command to change the view
        /// </summary>
        public ICommand ChangeCurrentViewCommand
        {
            get
            {
                if (_changeCurrentViewCommand == null)
                {
                    _changeCurrentViewCommand = new RelayCommand(ChangeCurrentView);
                }

                return _changeCurrentViewCommand;
            }
        }

        #endregion

        #region Private Methodes

        private void ChangeCurrentView(object param = null)
        {
            if (_module.IsProcess || CurrentViewModel == null || CurrentViewModel.HasChanged == false)
            {
                _currentMenu = SelectedMenu;

                object param1 = null;
                BaseViewModel viewModel = null;
                MethodInfo paramFunctionMI = null;

                Assembly assembley = Assembly.Load(SelectedMenu.AssembleyName);
                Type viewModelType = assembley.GetType(SelectedMenu.ViewModelName);
                string paramFunction = SelectedMenu.ParamFunction;

                if (paramFunction.IsNullOrEmpty() == false)
                {
                    Type appUtilType = typeof(AppUtilities);
                    paramFunctionMI = appUtilType.GetMethod(paramFunction);
                    if (paramFunctionMI != null)
                    {
                        param1 = paramFunctionMI.Invoke(null, null);
                        viewModel = (BaseViewModel)Activator.CreateInstance(viewModelType, param1);
                    }
                }

                if (paramFunction.IsNullOrEmpty() == true || paramFunctionMI == null)
                    viewModel = (BaseViewModel)Activator.CreateInstance(viewModelType);

                //Type viewModelType = Assembly.GetExecutingAssembly().GetType(SelectedMenu.AssembleyName + "." + SelectedMenu.ViewModelName);


                if (CurrentViewModel != null)
                    CurrentViewModel.Dispose();

                // Current viewmodel updated
                Dispatcher.BeginInvoke(new Action(() => CurrentViewModel = viewModel)).Wait();

                // If it is the last menu or you have no permission to the next menu, disable the next button
                MenuNodeDTO nextMenu = Menu.ElementAtOrDefault(Menu.IndexOf(SelectedMenu) + 1);
                if (nextMenu == null)
                    SetIsEnableOperation(false, Operations.Next);
            }
            else
            {
                NotificationText = Lang.Resources.ResourceManager.GetString(NotificationMessages.SaveYourChanges.GetResourceKey());
                NotificationType = NotificationAreaType.Error;
                //SelectedMenu = _currentMenu;
            }
        }

        private void CurrentViewModel_OnNotifcation(string notification, NotificationAreaType type)
        {
            NotificationText = string.Empty;
            NotificationText = notification;
            NotificationType = type;
        }

        private void SetFunctionToButton(Operations operation, Action action, Func<object, bool> canExecute, System.Windows.Media.Brush background = null)
        {
            OperationButton button = new OperationButton();
            button.Text = Lang.Resources.ResourceManager.GetString(operation.GetResourceKey());
            button.OperationAction = ExecuteOperation;
            button.OperationParameter = action;
            button.CanExecuteOperation = canExecute;

            if (background == null)
                button.Background = (System.Windows.Media.Brush)System.Windows.Application.Current.TryFindResource("ButtonBrush");
            else
                button.Background = background;


            Buttons.Add(button);
        }

        private void WorkspaceContainerViewModel_OnRaisCanExecuteOperation(Operations operation)
        {
            var button = Buttons.FirstOrDefault(b => b.Text == Lang.Resources.ResourceManager.GetString(operation.GetResourceKey()));
            Application.Current.Dispatcher.Invoke(button.RaisCanExecute);
        }

        private void MainWindowViewModel_OnIsEnableOperation(bool value, Operations? buttonOperation)
        {
            // If has no operation change the all buttons
            if (!buttonOperation.HasValue)
            {
                Buttons.ForEach(b =>
                {
                    if (_buttonsStatus == null)
                        b.IsEnabled = value;
                    else
                        _buttonsStatus[b] = value;
                });

                return;
            }

            OperationButton button = Buttons.FirstOrDefault(b => b.Text == Lang.Resources.ResourceManager.GetString(buttonOperation.Value.GetResourceKey()));
            if (button != null)
            {
                if (_buttonsStatus == null)
                    button.IsEnabled = value;
                else
                    _buttonsStatus[button] = value;
            }
        }

        private void ExecuteOperation(object obj)
        {
            if (obj is Action)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                Task.Run(() =>
                {
                    // Save the status of each operation button and disable them all
                    _buttonsStatus = new Dictionary<OperationButton, bool>();
                    Buttons.ForEach(b =>
                    {
                        _buttonsStatus.Add(b, b.IsEnabled);
                        // Set button to disable
                        b.IsEnabled = false;
                    });


                    ((Action)obj)();

                    // Set back the opertionbutton status
                    _buttonsStatus.ForEach(b => b.Key.IsEnabled = b.Value);
                    _buttonsStatus = null;
                    Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() => Mouse.OverrideCursor = null));
                });
            }
        }

        #endregion

        #region Public Methodes

        public override void OnDispose()
        {
            OnReadOnlyMode -= MainWindowViewModel_OnReadOnlyMode;
            OnIsEnableOperation -= MainWindowViewModel_OnIsEnableOperation;
            AppUtilities.CurrentAppChanged -= JumpToSubMenu;
            this.CurrentViewModel.Dispose();
        }

        private void JumpToSubMenu()
        {
            if (CurrentApp == null || CurrentApp.RequestStatus == null || CurrentApp.RequestStatus.Name.IsNullOrEmpty() || CurrentApp.RequestStatus.Name == RequestStatuses.Empty.GetStringValue())
                return;

            // Search the current menu by status
            var subMenu = Menu.FirstOrDefault(i => i.Accessibility.Contains(CurrentApp.RequestStatus.Name));
            if (subMenu != null && SelectedMenu.MenuId != subMenu.MenuId)
            {
                SelectedMenu = subMenu;
                Dispatcher.Invoke(DetailsViewModel.Refresh);
            }

            if (subMenu == null)
            {
                // Search the current menu by status on other modules
                MenuNodeDTO menu = RootMenu.FirstOrDefault(m => m.Accessibility.Contains(CurrentApp.RequestStatus.Name));
                Startover();
                if (menu != null)
                    //CurrentViewModel_OnNotifcation(string.Format(MessageManager.GetMessage(MessagesFinder.AppInDifferentModule), menu.Name), NotificationAreaType.Error);
                    CurrentViewModel_OnNotifcation(string.Format("Application is being processed in the {0} module", menu.Name), NotificationAreaType.Error);
                else
                    CurrentViewModel_OnNotifcation("The application has finished processing. To find out more, go to the Enquiry screen", NotificationAreaType.Error);
            }
        }

        public void SetOperationButtons(IViewModel view)
        {
            Buttons.Clear();

            if (CurrentViewModel is IOperationBack)
                SetFunctionToButton(Operations.Back, ((IOperationBack)view).Back, ((IOperationBack)view).CanExecute);

            //if (_module.IsProcess && Menu.Any(m => m.ViewModelName == view.GetType().FullName))
            //    SetFunctionToButton(Operations.Startover, Startover, new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 153, 0)));

            if (CurrentViewModel is IOperationAdd)
                SetFunctionToButton(Operations.Add, ((IOperationAdd)view).Add, ((IOperationAdd)view).CanExecute);

            if (CurrentViewModel is IOperationExport)
                SetFunctionToButton(Operations.ExportToExcel, ((IOperationExport)view).ExportToExcel, ((IOperationExport)view).CanExecute);

            if (CurrentViewModel is IOperationClear)
                SetFunctionToButton(Operations.Clean, ((IOperationClear)view).Clear, ((IOperationClear)view).CanExecute);

            if (CurrentViewModel is IOperationPrint)
                SetFunctionToButton(Operations.Print, ((IOperationPrint)view).Print, ((IOperationPrint)view).CanExecute);

            if (CurrentViewModel is IOperationDelete)
                SetFunctionToButton(Operations.Delete, ((IOperationDelete)view).Delete, ((IOperationDelete)view).CanExecute);

            if (CurrentViewModel is IOperationScan)
                SetFunctionToButton(Operations.Scan, ((IOperationScan)view).Scan, ((IOperationScan)view).CanExecute);

            if (CurrentViewModel is IOperationCaptureAll)
                SetFunctionToButton(Operations.CaptureAll, ((IOperationCaptureAll)view).CaptureAll, ((IOperationCaptureAll)view).CanExecute);

            if (CurrentViewModel is IOperationCaptureMulti)
                SetFunctionToButton(Operations.CaptureMulti, ((IOperationCaptureMulti)view).CaptureMulti, ((IOperationCaptureMulti)view).CanExecute);

            if (CurrentViewModel is IOperationScanFromPaper)
                SetFunctionToButton(Operations.ScanFromPaper, ((IOperationScanFromPaper)view).ScanFromPaper, ((IOperationScanFromPaper)view).CanExecute);

            if (CurrentViewModel is IOperationCancel)
                SetFunctionToButton(Operations.Cancel, ((IOperationCancel)view).Cancel, ((IOperationCancel)view).CanExecute);

            if (CurrentViewModel is IOperationNew)
                SetFunctionToButton(Operations.New, ((IOperationNew)view).New, ((IOperationNew)view).CanExecuteNew);

            if (CurrentViewModel is IOperationTerminate)
                SetFunctionToButton(Operations.Terminate, ((IOperationTerminate)view).Terminate, ((IOperationTerminate)view).CanExecuteTerminate);

            if (_module.IsProcess &&
                Menu.Count > 1 &&
                Menu.Any(m => m.ViewModelName == view.GetType().FullName))
                SetFunctionToButton(Operations.Next, GoToNextMenu, null);

            if (CurrentViewModel is IOperationSave)
                SetFunctionToButton(Operations.Save, Save, null);

            if (CurrentViewModel is IOperationSubmit)
                SetFunctionToButton(Operations.Submit, ((IOperationSubmit)view).Submit, ((IOperationSubmit)view).CanExecuteSubmit);

            if (CurrentViewModel is IOperationSaveRequest)
                SetFunctionToButton(Operations.Save, ((IOperationSaveRequest)view).Save, ((IOperationSaveRequest)view).CanExecuteSaveRequest);

            if (CurrentViewModel is IOperationEnroll)
                SetFunctionToButton(Operations.Enroll, ((IOperationEnroll)view).Enroll, ((IOperationEnroll)view).CanExecute);
        }

        private void Startover()
        {
            AppUtilities.CurrentApp = new Request();
            DetailsViewModel = new DetailsViewModel();
            SelectedMenu = Menu.First();
        }

        public void Save()
        {
            NotificationMessages msg = NotificationMessages.FixValidationErrors;
            if (Dispatcher.Invoke<bool>(() => CurrentViewModel.Validate(ref msg)) == false)
            {
                CurrentViewModel.ShowNotification(msg, NotificationAreaType.Error);
                return;
            }

            bool saveSuccess = true;

            if (CurrentViewModel is IOperationSave)
            {
                if (Module.IsProcess && HasPageBeenAlreadySaved())
                {
                    CurrentViewModel.ShowNotification(NotificationMessages.AppWasSavedByAnotherUser, NotificationAreaType.Error);
                    return;
                }
                saveSuccess = ((IOperationSave)CurrentViewModel).Save();
                ((IViewModel)CurrentViewModel).ResetPage();
            }

            if (Module.IsProcess)
            {
                if (SelectedMenu.Equals(Menu.Last()))
                    if (saveSuccess)
                    {
                        Dispatcher.Invoke(() => DialogService.ShowDialog("Process Completed Successfuly"));
                        Startover();
                    }
            }
        }

        public void GoToNextMenu()
        {
            NotificationMessages msg = NotificationMessages.FixValidationErrors;
            if (Dispatcher.Invoke<bool>(() => CurrentViewModel.Validate(ref msg)) == false)
            {
                CurrentViewModel.ShowNotification(msg, NotificationAreaType.Error);
                return;
            }

            // Save the current viewmodel
            if (CurrentViewModel is IOperationSave)
            {
                if (Module.IsProcess && HasPageBeenAlreadySaved())
                {
                    CurrentViewModel.ShowNotification(NotificationMessages.AppWasSavedByAnotherUser, NotificationAreaType.Error);
                    return;
                }
                (CurrentViewModel as IOperationSave).Save();
                // IMPORTANT TO IMPLEMENT
                //CurrentApp.AppStatus = Services.FormService.GetAppStatus(CurrentApp.FormNumber).GetStringValue();
                //CurrentApp.RequestStatus = ServicesInstances.RequestService.GetRequestStatus((int.Parse(CurrentApp.Num));
            }

            if (CurrentApp == null || CurrentApp.RequestStatus.Name.IsNullOrEmpty())
                return;

            int currentIndex = Menu.IndexOf(_currentMenu);
            MenuNodeDTO nextMenu = Menu.ElementAtOrDefault(currentIndex + 1);

            if (nextMenu != null && nextMenu.Accessibility.Contains(CurrentApp.RequestStatus.Name))
            {
                SelectedMenu = nextMenu;
            }
            else
            {
                JumpToSubMenu();
            }

            Dispatcher.Invoke(DetailsViewModel.Refresh);
        }

        private bool HasPageBeenAlreadySaved()
        {
            // IMPORTANT TO IMPLEMENT
            //AppStatuses CurrentAppStatus = Services.FormService.GetAppStatus(CurrentApp.FormNumber);
            //if (CurrentAppStatus == AppStatuses.Empty)
            //    return false;
            //return (_currentMenu.Accessibility.Contains(CurrentAppStatus.GetStringValue()) == false);
            return false;
        }

        #endregion
    }


}
