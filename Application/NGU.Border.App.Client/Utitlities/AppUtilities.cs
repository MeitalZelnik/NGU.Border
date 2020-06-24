using NGU.App.Client.ViewModels;
using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.ApiAdmin;
using NGU.Lang;
using NGU.Common.Utilities;
using Pangea.BaseStructures;
using Pangea.Extensions;
using Pangea.Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Admin = NGU.Interfaces.ApiAdmin;
using Pangea.App.Utils;

namespace NGU.App.Client.Utitlities
{
    public static class AppUtilities
    {
        #region privates
        private static Stack _menusStack = new Stack();
        // Login/MainMenu/WorkspaceContainer
        private static BaseViewModel _mainCurrentViewModel = null;
        private static Request _currentApp;
        #endregion


        #region events
        public static event Action OnMainCurrentViewModelChanged;
        public static event Action CurrentAppChanged;
        #endregion

        public static Stack MenusStack
        {
            get
            {

                return _menusStack;
            }

            set
            {
                _menusStack = value;
            }
        }

        public static Request CurrentApp
        {
            get
            {
                return _currentApp;
            }
            set
            {
                _currentApp = value;
                CurrentAppChanged?.Invoke();
            }
        }

        // Login/MainMenu/WorkspaceContainer
        public static BaseViewModel MainCurrentViewModel
        {
            get
            {
                return _mainCurrentViewModel;
            }
            private set
            {
                _mainCurrentViewModel = value;
                OnMainCurrentViewModelChanged();
            }
        }

        #region static methods

        /// <summary>
        /// Returns the current application version.
        /// </summary>
        /// <returns></returns>
        public static Version GetCurrentApplicationVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }

        public static void SetMainViewModel(BaseViewModel viewModel)
        {
            if (MainCurrentViewModel != null && MainCurrentViewModel != viewModel)
                MainCurrentViewModel.Dispose();
            MainCurrentViewModel = viewModel;
        }
        #endregion


        // TODELETE
        public static PangeaViewModelBase GetViewModel(int menuId, object param)
        {
            ViewModelTypes viewEnum = (ViewModelTypes)menuId;
            return GetViewModel(viewEnum, param);
        }

        // TODELETE
        public static PangeaViewModelBase GetViewModel(string menuId, object param)
        {
            ViewModelTypes stringToViewModelName;
            try
            {
                stringToViewModelName = menuId.ToEnum<ViewModelTypes>();
            }
            catch (Exception)
            {
                stringToViewModelName = ViewModelTypes.MainMenu;
            }

            return GetViewModel(stringToViewModelName, param);
        }


        // TODELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="param"></param>
        /// <param name="parent">parent is a temp varible that should be removed once me use the 'RequestStatusToScreenNavigation' function that will make our request status fit the view model</param>
        /// <returns></returns>
        public static PangeaViewModelBase GetViewModel(ViewModelTypes viewName, object param, int parent = 0)
        {
            Menu menuParam = null;
            PangeaViewModelBase currentViewModel = null;
            try
            {
                object viewText = null;
                switch (viewName)
                {
                    case ViewModelTypes.Workspace:
                        break;

                    case ViewModelTypes.ChangePassword:
                        viewText = Resources.ChangePassword;
                        currentViewModel = new LoginViewModel(true);
                        break;

                    case ViewModelTypes.Login:
                        viewText = Resources.Login;
                        currentViewModel = new LoginViewModel(false);
                        break;

                    case ViewModelTypes.MainMenu:
                        viewText = Resources.MainMenu;
                        currentViewModel = new MainMenuViewModel();
                        break;

                    case ViewModelTypes.Exit:
                        System.Windows.Application.Current.Shutdown();
                        return null;

                    case ViewModelTypes.Back:
                        if (MenusStack.Count == 0)
                            currentViewModel = GetViewModel(ViewModelTypes.MainMenu, null);
                        else
                            currentViewModel = (PangeaViewModelBase)MenusStack.Pop();
                        break;

                    default:
                        viewText = Resources.MainMenu;
                        Log.Error("Exception: " + viewName + " is null!");
                        throw new Exception("Exception: " + viewName + " is null!");
                }

                if (currentViewModel != null)
                {
                    // This is for setting up the ViewName so the ViewModel knows whats it's ViewName
                    currentViewModel.ViewName = viewName;
                    currentViewModel.MenuId = (int)viewName;
                    currentViewModel.ParentID = parent;
                    if (viewText != null)
                    {
                        currentViewModel.ViewText = viewText.ToString().ToTitleCase();
                    }
                }
            }
            catch (Exception ex)
            {
                try { }
                catch { }

                throw;
            }

            return currentViewModel;
        }
    }
}
