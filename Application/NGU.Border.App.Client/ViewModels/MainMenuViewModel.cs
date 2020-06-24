using NGU.App.Client.Utitlities;
using NGU.Core;
using NGU.Enums;
using Pangea.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Pangea.BaseStructures;
using NGU.Interfaces.ApiAdmin;
using System.Windows;
using System.Collections.Generic;
using NGU.App.DTO;

namespace NGU.App.Client.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        #region Constructor

        public MainMenuViewModel()
        {
            //_menus = new ObservableCollection<Menu>(LoggedUser.Menus.Where(x => x.ParentID.HasValue && x.ParentID == (int)ViewModelTypes.MenuBlackList));
            //NotifyPropertyChanged(() => Menus);

            AppUtilities.CurrentApp = null;
            _menuTree = Pangea.App.Menu.MenuUtils.GetRootMenu(1000);
        }

        #endregion

        #region private members
        ICommand _changeCurrentViewCommand = null;
        private IList<Pangea.App.Menu.Menu> _menuTree;
        private IList<Pangea.App.Menu.Menu> _utiltyMenu;
        #endregion

        #region actions
        public event Action CloseApplication;
        #endregion

        #region Properties

        public IList<MenuNodeDTO> Menu
        {
            get
            {
                return MenuUtilities.ConvertToMenuDTO(_menuTree);
            }
        }
        #endregion Properties

        #region Methods



        private void OnCloseApplication()
        {
            if (CloseApplication != null)
                CloseApplication();
        }

        private void ChangeCurrentView(object param)
        {
            //AppUtilities.SetMainViewModel(new WorkspaceContainerViewModel((MenuNodeDTO)param));
            MenuNodeDTO moduleMenu = param as MenuNodeDTO;
            if (moduleMenu.ModuleType == "wstype")
                WindowModel.CurrentViewModel = new WorkspaceContainerViewModel(moduleMenu);
            else
                WindowModel.CurrentViewModel = AppUtilities.GetViewModel(moduleMenu.MenuId, param);
        }


        private void ChangeCurrentViewOld(object param)
        {

            //WindowModel.CurrentViewModel = AppUtilities.GetViewModel((ViewModelTypes)(param as Menu).MenuId, null, MenuId);
            if (param is Menu)
            {
                Menu menu = param as Menu;
                WindowModel.CurrentViewModel = AppUtilities.GetViewModel(menu.ID, param);
            }
            else if (param is string)
            {
                string strViewName = (string)param;
                WindowModel.CurrentViewModel = AppUtilities.GetViewModel(strViewName, param);
            }
        }

        #endregion Methods

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
        #endregion Commands
    }
}
