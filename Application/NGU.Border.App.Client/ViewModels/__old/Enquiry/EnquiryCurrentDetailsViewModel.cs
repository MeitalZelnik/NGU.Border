using MD.App.ePayment.DTO;
using NGU.Admin.Interfaces;
using Pangea.Client.WPF.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NGU.Admin.App.Client.ViewModels
{
    public class EnquiryCurrentDetailsViewModel : BaseViewModel//, IVerifyFunctions
    {
        #region ctor

        public EnquiryCurrentDetailsViewModel()
        {
            //ProcessHelper.RunMethodOnDifferentTask(() =>
            //{
            //    string intref = BaseContainerViewModel.EquiryPersonIntref;
            //    PersonDto = DrivingLicenceService.GetEnquiryCurrentDetails(int.Parse(intref));
            //});
        }

        #endregion

        //#region members

        //private PersonDTO _personDto;
        //private ICommand _copyToClipBoardCommand;

        //#endregion

        //#region props

        //public PersonDTO PersonDto
        //{
        //    get
        //    {
        //        return _personDto;
        //    }
        //    set
        //    {
        //        _personDto = value;
        //        NotifyPropertyChanged(() => PersonDto);
        //    }
        //}

        //#endregion

        //#region commands

        //public ICommand CopyToClipBoardCommand
        //{
        //    get
        //    {
        //        if (_copyToClipBoardCommand == null)
        //            _copyToClipBoardCommand = new RelayCommand(CopyToClipBoardExecute);

        //        return _copyToClipBoardCommand;
        //    }
        //}

        //#endregion

        //#region IVerifyFunctions

        //public void VerifyPhoto()
        //{

        //}

        //public void VerifyFingerprint()
        //{

        //}

        //#endregion

        //#region methods

        //private void CopyToClipBoardExecute(object param)
        //{
        //    if (param.ToString() == "Intref")
        //        Clipboard.SetText(PersonDto.Interef.ToString());
        //}

        //#endregion
    }
}
