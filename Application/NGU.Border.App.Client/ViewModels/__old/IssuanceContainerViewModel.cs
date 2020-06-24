using NGU.Admin.App.Client.Utitlities;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Admin.App.Client.ViewModels
{
    public class IssuanceContainerViewModel: SearchContainerViewModel
    {
        public IssuanceContainerViewModel(Menu menu) : base()
        {
            SelectedMenuButton = menu;
            //CurrentViewModel = AppUtilities.GetViewModel(ViewModelTypes.Issuance, this);
        }

        public override void Refresh()
        {
            CurrentViewModel.Refresh();
        }

    }
}
