using NGU.App.Client.ViewModels;
using NGU.Enums;
using NGU.Lang;
using Pangea.BaseStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NGU.App.Client.Validators
{
    //public class IdOrPassportValidator : GenericValidatorAttribute
    //{
    //    private Regex passportRegex = new Regex(@"^[a-zA-Z0-9]{9}\z");
    //    private Regex idCardRegex = new Regex(@"^[0-9]{13}\z");

    //    public IdOrPassportValidator()
    //    {
    //        ErrorMessage = Resources.MSG_IDPasswordFormatError;
    //    }

    //    public override bool IsValid(object viewModel, object propertyValue)
    //    {
    //        RegistrationViewModel vm = viewModel as RegistrationViewModel;
    //        if (vm == null || vm.SelectedIdType == null)
    //            return false;

    //        switch(vm.SelectedIdType.ID)
    //        {
    //            case (int)IdenTypes.Passport:
    //                return passportRegex.IsMatch(vm.IdNumber.Trim());
    //            case (int)IdenTypes.IdentityCard:
    //                return idCardRegex.IsMatch(vm.IdNumber.Trim());
    //            default:
    //                return vm.IdNumber.Trim().Length > 0;
    //        }
    //    }
    //}

}
