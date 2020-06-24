using NGU.App.Client.ViewModels;
using NGU.Lang;
using Pangea.BaseStructures;
using Pangea.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.App.Client.Validators
{

    public class CreatedDateFromBeforeDateTo : CustomValidatorAttribute
    {
        public CreatedDateFromBeforeDateTo()
        {
            ErrorMessage = Resources.ERR_DateFromBeforeDateTo;
        }

        public override bool IsValid(object value)
        {
            if (!(value is SearchUserControlViewModel))
                return true;

            SearchUserControlViewModel vm = value as SearchUserControlViewModel;

            if (!vm.CreatedFrom.HasValue || !vm.CreatedTo.HasValue)
                return true;

            return vm.CreatedFrom <= vm.CreatedTo;
        }
    }
    
    public class FieldRequired : ValidationAttribute
    {
        public FieldRequired()
        {
            ErrorMessage = "todo: pangeaRequired";
        }

        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().IsNullOrEmpty())
                return false;

            return true;
        }
    }
}
