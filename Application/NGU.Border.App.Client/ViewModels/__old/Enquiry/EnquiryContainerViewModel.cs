using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using NGU.Admin.Interfaces;
using Pangea.Client.WPF.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NGU.Admin.App.Client.ViewModels
{
    public class EnquiryContainerViewModel : BaseContainerViewModel//, IVerifyFunctions, IPrintingFunctions
    {
        #region ctor

        public EnquiryContainerViewModel(Menu menu) : base(menu)
        {
            ////(CurrentViewModel as EnquirySearchViewModel).NotifyContainer += EnquiryContainerViewModel_NotifyNextMenu;
            //BaseViewModel.NotifyContainer += EnquiryContainerViewModel_NotifyNextMenu;

            //foreach (var item in Menus)
            //{
            //    if (item.MenuId != (int)ViewModelTypes.EnquirySearch)
            //        item.IsPermitted = false;
            //}
        }

        #endregion

        //#region props

        ///// <summary>
        ///// hides the white background from the tabs area
        ///// </summary>
        //public new bool IsTransparentContainer
        //{
        //    get
        //    {
        //        if (CurrentViewModel is EnquirySearchViewModel)
        //            return true;

        //        if (CurrentViewModel is EnquiryCurrentDetailsViewModel)
        //            return false;

        //        if (CurrentViewModel is EnquiryApplicationsViewModel)
        //            return false;

        //        return false;
        //    }
        //}

        //#endregion

        //#region visibility/enabled container buttons

        //public new bool IsPrintVisibile
        //{
        //    get
        //    {
        //        if (CurrentViewModel is EnquiryCurrentDetailsViewModel)
        //            return true;

        //        return false;
        //    }
        //}

        //public new bool IsCheckFingerprintVisibile
        //{
        //    get
        //    {
        //        if (CurrentViewModel is EnquiryCurrentDetailsViewModel)
        //            return true;

        //        return false;
        //    }
        //}

        //public new bool IsVerifyPersonVisibile
        //{
        //    get
        //    {
        //        if (CurrentViewModel is EnquiryCurrentDetailsViewModel)
        //            return true;

        //        return false;
        //    }
        //}

        //private bool _isPrintTempLicenseVisibile;
        //public bool IsPrintTempLicenseVisibile
        //{
        //    get
        //    {
        //        return _isPrintTempLicenseVisibile;
        //    }
        //    set
        //    {
        //        _isPrintTempLicenseVisibile = value;
        //        NotifyPropertyChanged(() => IsPrintTempLicenseVisibile);
        //    }
        //}

        //#endregion

        //#region commands

        //private ICommand _printTempLicenseCommand;
        //public ICommand PrintTempLicenseCommand
        //{
        //    get
        //    {
        //        if (_printTempLicenseCommand == null)
        //            _printTempLicenseCommand = new RelayCommand(PrintTempLicenseExecute);

        //        return _printTempLicenseCommand;
        //    }
        //}

        //#endregion

        //#region methods

        //internal void PrintTempLicenseExecute(object param)
        //{
        //    CurrentIPrintingFunctions.Print();
        //}

        //internal void EnquiryContainerViewModel_NotifyNextMenu(object sender, object param)
        //{
        //    if (param != null && param.ToString() == "clear")
        //    {
        //        //NavigationHistory= null;
        //        NavigationHistory = NavigationHistory.Where(x => (int)x.Key == (int)ViewModelTypes.EnquirySearch).ToDictionary(x => x.Key, y => y.Value);

        //        foreach (var item in Menus)
        //        {
        //            if (item.MenuId != (int)ViewModelTypes.EnquirySearch)
        //                item.IsPermitted = false;
        //        }

        //        return;
        //    }

        //    if (sender is EnquirySearchViewModel)
        //    {
        //        PersonDTO selectedPerson = (sender as EnquirySearchViewModel).SelectedPerson;

        //        //if selected person has value open currentdetails & applications
        //        if (selectedPerson != null)
        //        {
        //            Menus.FirstOrDefault(x => x.MenuId == (int)ViewModelTypes.EnquiryCurrentDetails).IsPermitted = true;
        //            Menus.FirstOrDefault(x => x.MenuId == (int)ViewModelTypes.EnquiryAppplication).IsPermitted = true;
        //        }
        //    }


        //    if (sender is EnquiryApplicationsViewModel)
        //    {
        //        //if selected application open the rest of the enquiry tabs
        //        ApplicationDTO selectedApplication = (sender as EnquiryApplicationsViewModel).SelectedApplication;
        //        if (selectedApplication != null)
        //        {
        //            Menus.FirstOrDefault(x => x.MenuId == (int)ViewModelTypes.EnquiryLicence).IsPermitted = true;
        //            Menus.FirstOrDefault(x => x.MenuId == (int)ViewModelTypes.EnquiryCommentAndLog).IsPermitted = true;
        //        }
        //    }


        //    if (param != null && param.ToString() == "enableTempPrintBtn")
        //    {
        //        bool b = (sender as EnquiryLicenceViewModel).SelectedTabIndex == 0 ? false : true;

        //        IsPrintTempLicenseVisibile = b;
        //    }
        //}

        //public override void Dispose()
        //{
        //    BaseViewModel.NotifyContainer -= EnquiryContainerViewModel_NotifyNextMenu;

        //    base.Dispose();
        //}

        //#endregion
    }
}
