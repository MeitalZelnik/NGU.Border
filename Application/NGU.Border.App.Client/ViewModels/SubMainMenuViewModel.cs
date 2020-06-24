using NGU.App.Client.Utitlities;
using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.ApiAdmin;
using Pangea.BaseStructures;
using Pangea.Client.WPF.CustomControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NGU.App.Client.ViewModels
{
    class SubMainMenuViewModel : BaseViewModel
    {
        #region members

        private ObservableCollection<Menu> _menus = null;
        private ICommand _changeCurrentViewCommand;

        #endregion

        #region ctor

        public SubMainMenuViewModel(Menu menu)
        {
            _menus = new ObservableCollection<Menu>(menu.SubMenus.ToList());
            NotifyPropertyChanged(() => Menus);
        }

        #endregion

        #region commands

        public ICommand ChangeCurrentViewCommand
        {
            get
            {
                if (_changeCurrentViewCommand == null)
                    _changeCurrentViewCommand = new RelayCommand(ChangeCurrentView);

                return _changeCurrentViewCommand;
            }
        }

        #endregion

        #region props

        public ObservableCollection<Menu> Menus
        {
            get
            {
                return _menus;
            }
        }

        #endregion

        #region methods

        private void ChangeCurrentView(object param)
        {
            Menu menu = param as Menu;

            if (menu != null)
                BaseViewModel.WindowModel.CurrentViewModel = AppUtilities.GetViewModel(menu.ID, param);
        }

        #endregion
    }
}
