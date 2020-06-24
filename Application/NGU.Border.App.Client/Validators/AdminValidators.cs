using NGU.App.Client.ViewModels;
using NGU.Enums;
using NGU.Lang;
using NGU.Common.Utilities;
using Pangea.BaseStructures;
using Pangea.Extensions;
using Pangea.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

namespace NGU.App.Client.Validators
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public PasswordValidationAttribute()
        {
            ErrorMessage = Resources.ERR_PasswordSecureValidation;
        }

        public override bool IsValid(object value)
        {
            if (value == null || value.ToString().IsNullOrEmpty())
                return true;

            return PasswordHelper.IsPasswordValid(value.ToString());
        }
    }

    public class NewPasswordRequired : CustomValidatorAttribute
    {
        public NewPasswordRequired()
        {
            ErrorMessage = Resources.ERR_Required;
        }

        public override bool IsValid(object value)
        {
            if (!(value is LoginViewModel))
                return true;

            LoginViewModel vm = value as LoginViewModel;

            if (vm._screenMode == ScreenType.Login)
                return true;

            return !vm.NewPassword.IsNullOrEmpty();
        }
    }

    public class ConfirmPasswordRequired : CustomValidatorAttribute
    {
        public ConfirmPasswordRequired()
        {
            ErrorMessage = Resources.ERR_Required;
        }

        public override bool IsValid(object value)
        {
            if (!(value is LoginViewModel))
                return true;

            LoginViewModel vm = value as LoginViewModel;

            if (vm._screenMode == ScreenType.Login)
                return true;

            return !vm.ConfirmPassword.IsNullOrEmpty();
        }
    }

    public class UpdatedPasswordConfirmation : CustomValidatorAttribute
    {
        public UpdatedPasswordConfirmation()
        {
            ErrorMessage = Resources.ERR_ConfirmPasswordAndNewPasswordnotMatch;
        }

        public override bool IsValid(object value)
        {
            if (!(value is LoginViewModel))
                return true;

            LoginViewModel vm = value as LoginViewModel;

            if (vm._screenMode == ScreenType.Login)
                return true;
            
            return vm.NewPassword == vm.ConfirmPassword;
        }
    }

    public class UpdatedPasswordEqualToOldPassword : CustomValidatorAttribute
    {
        public UpdatedPasswordEqualToOldPassword()
        {
            ErrorMessage = Resources.ERR_NewPassOldPassMustBeDifferent;
        }

        public override bool IsValid(object value)
        {
            if (!(value is LoginViewModel))
                return true;

            LoginViewModel vm = value as LoginViewModel;

            return vm.NewPassword != vm.UserPassword;
        }
    }

   
}
