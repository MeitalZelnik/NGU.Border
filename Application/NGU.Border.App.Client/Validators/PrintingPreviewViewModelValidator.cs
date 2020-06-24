using MD.App.ePayment.Client.ViewModels;
using NIP.BasicValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.App.ePayment.Client.Validators
{
    public class SerialNumberMustBeEntered : CustomValidator
    {
        public SerialNumberMustBeEntered()
        {
            this.ErrorMessage = System.Windows.Application.Current.Resources["LangDict_SerialNumberMustBeEntered"].ToString();
        }

        public override bool IsValid(object value)
        {
            //PrintingPreviewViewModel vm = value as PrintingPreviewViewModel;

            //if (vm == null)
            //    return true;

            //// We check if the card was not printed we don't show any Validation on the Serial Number
            //if (!vm.WasPrinted)
            //    return true;

            //if (!vm.SerialNumber.IsNullOrEmpty())
                return true;

            return false;
        }
    }
}
