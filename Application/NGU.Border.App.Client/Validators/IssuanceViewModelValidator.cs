using MD.App.ePayment.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.App.ePayment.Client.Validators
{
    public class ApplicationNumberLengthValidator : ValidationAttribute
    {
        public ApplicationNumberLengthValidator()
        {
            this.ErrorMessage = "Application No must have 13 digits";
        }

        public override bool IsValid(object value)
        {
            IssuanceViewModel vm = value as IssuanceViewModel;

            //if (vm == null || vm.AppNo.IsNullOrEmpty())
            //    return true;

            //if (vm.AppNo.Length == 13)
            //    return true;

            return false;
        }
    }

    public class PersonIntrefNoLengthValidator : ValidationAttribute
    {
        public PersonIntrefNoLengthValidator()
        {
            this.ErrorMessage = "Interef No must have 6 digits";
        }

        public override bool IsValid(object value)
        {
            IssuanceViewModel vm = value as IssuanceViewModel;

            //if (vm == null || vm.PersonIntrefNo.IsNullOrEmpty())
            //    return true;

            //if (vm.PersonIntrefNo.Length == 6)
            //    return true;

            return false;
        }
    }

    public class LicenseIntrefNoLengthValidator : ValidationAttribute
    {
        public LicenseIntrefNoLengthValidator()
        {
            this.ErrorMessage = "Interef No must have 6 digits";
        }

        public override bool IsValid(object value)
        {
            IssuanceViewModel vm = value as IssuanceViewModel;

            //if (vm == null || vm.LicenseIntrefNo.IsNullOrEmpty())
            //    return true;

            //if (vm.LicenseIntrefNo.Length == 6)
            //    return true;

            return false;
        }
    }

    public class LicenseSerialNoLengthValidator : ValidationAttribute
    {
        public LicenseSerialNoLengthValidator()
        {
            this.ErrorMessage = "Serial No must have 8 digits";
        }

        public override bool IsValid(object value)
        {
            IssuanceViewModel vm = value as IssuanceViewModel;

            //if (vm == null || vm.LicenseSerialNo.IsNullOrEmpty())
            //    return true;

            //if (vm.LicenseSerialNo.Length == 8)
            //    return true;

            return false;
        }
    }
}
