using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGU.Enums;
using System.Collections.ObjectModel;
using NGU.Core;
using NGU.App.Client.Utitlities;
using System.Windows.Input;
using Pangea.Client.WPF.CustomControls;
using System.Windows;
using NGU.App.DTO;
using Pangea.BaseStructures;
using NGU.Interfaces.ApiAdmin;

namespace NGU.App.Client.ViewModels
{
    public class MainFlowViewModel : BaseViewModel
    {
        #region members

        private ViewModelTypes _selectedMenu;
        private Menu _selectedMenuButton;
        private ObservableCollection<Menu> _menus;

        #endregion

        #region ctor

        public MainFlowViewModel(int parentId)
        {
        }

        public MainFlowViewModel(ViewModelTypes type)
        {
            SelectedMenu = type;
            CurrentContainer = AppUtilities.GetViewModel(SelectedMenu, true);
        }

        #endregion

        #region props

        public PangeaViewModelBase CurrentContainer { get; set; }
                
        public ObservableCollection<Menu> Menus
        {
            get
            {
                if (_menus == null && SelectedMenuButton != null && SelectedMenuButton.ParentID.HasValue)
                {
                    _menus = new ObservableCollection<Menu>(LoggedUser.Menus.Where(x => x.ParentID == SelectedMenuButton.ParentID.Value));
                    foreach (var menu in _menus)
                    {
                        if (menu.ID == (int)SelectedMenu)
                        {
                            menu.IsSelectedMenu = true;
                        }
                        else
                            menu.IsSelectedMenu = false;

                    }
                }

                return _menus;
            }
        }

        public ViewModelTypes SelectedMenu
        {
            get
            {
                return _selectedMenu;
            }

            set
            {
                _selectedMenu = value;
            }
        }

        public Menu SelectedMenuButton
        {
            get
            {
                return _selectedMenuButton;
            }
            set
            {
                if (_selectedMenuButton == value)
                    return;

                _selectedMenuButton = value;
                NotifyPropertyChanged(() => SelectedMenuButton);

            }
        }

        #endregion

        #region override methods

        public override void OnDispose()
        {
            if (CurrentContainer != null)
            {
                CurrentContainer.Dispose();
            }
        }

        #endregion override
    }
}
