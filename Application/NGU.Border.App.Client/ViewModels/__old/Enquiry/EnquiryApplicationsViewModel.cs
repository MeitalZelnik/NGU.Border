using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Admin.App.Client.ViewModels
{
    public class EnquiryApplicationsViewModel : BaseViewModel
    {
        #region ctor

        public EnquiryApplicationsViewModel()
        {
            //ProcessHelper.RunMethodOnDifferentTask(() =>
            //{
            //    string intref = BaseContainerViewModel.EquiryPersonIntref;
            //    var res = DrivingLicenceService.GetApplicationsByIntref(int.Parse(intref));

            //    Applications = new ObservableCollection<ApplicationDTO>(res);
            //});
        }

        #endregion

        //#region memebers

        //private ObservableCollection<ApplicationDTO> _applications;

        //#endregion

        //private ApplicationDTO _selectedApplication;

        //#region props

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


        //public ApplicationDTO SelectedApplication
        //{
        //    get
        //    {
        //        return _selectedApplication;
        //    }

        //    set
        //    {
        //        _selectedApplication = value;
        //        NotifyPropertyChanged(() => SelectedApplication);

        //        //save aside for future use
        //        BaseContainerViewModel.EquiryApplicationAppNo = _selectedApplication != null && _selectedApplication.AppNo > 0 ? _selectedApplication.AppNo : 0;

        //        //notify container to re-enable menus
        //        OnNotifyContainer(null);
        //    }
        //}
        //#endregion
    }
}
