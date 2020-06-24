using NGU.App.Client.Utitlities;
using NGU.Enums;
using System;
using NGU.App.Client.Validators;
using Pangea.Extensions;
using System.Windows.Input;
using Pangea.BaseStructures;
using Pangea.BasicValidators;
using NGU.Lang;
using NGU.Interfaces.ApiAdmin;
using System.Windows;
using System.Windows.Media.Imaging;
using NGU.Common.Utilities;
using Pangea.MultiLanguage;

namespace NGU.App.Client.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private bool _setNewPasswordFocus;
        private bool _showChangePassword;
        private string _errorMsg;
        private string _confirmPassword;
        private string _newPassword;
        private string _password;
        private string _username;
        internal ScreenType _screenMode;
        private ICommand _loginCommand;
        private ICommand _clearCommand;
        private ICommand _changePasswordCommand;
        private bool _setFirstFocus;
        private bool _setEnterPasswordFocus;

        #region ctor

        public LoginViewModel(bool bChangePasswordMode)
        {
            if (bChangePasswordMode)
            {
                Username = LoggedUser.Username;
                ShowChangePassword = bChangePasswordMode;
                ChangeMode(ScreenType.ChangePassword);
                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() => SetEnterPasswordFocus = true));
            }
            else
            {
                ChangeMode(ScreenType.Login);
                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() => SetFirstFocus = true));
            }
        }

        #endregion

        #region Props

        public bool SetEnterPasswordFocus
        {
            get { return _setEnterPasswordFocus; }
            set
            {
                _setEnterPasswordFocus = value;
                NotifyPropertyChanged(() => SetEnterPasswordFocus);
                if (value)
                {
                    _setFirstFocus = false;
                    NotifyPropertyChanged(() => SetEnterPasswordFocus);
                }
            }
        }

        public bool SetFirstFocus
        {
            get { return _setFirstFocus; }
            set
            {
                _setFirstFocus = value;
                NotifyPropertyChanged(() => SetFirstFocus);
                if (value)
                {
                    _setFirstFocus = false;
                    NotifyPropertyChanged(() => SetFirstFocus);
                }
            }
        }

        [PangeaRequired]
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username == value)
                    return;

                if (value != null)
                {
                    //value = value.ToUpper();

                    //if (value != _username)
                    //    ProcessHelper.RunMethodOnDifferentTask(() => LoadAllRequestedUserMenus(value));
                }

                _username = value;

                NotifyPropertyChanged(() => Username);
                NotifyPropertyChanged(() => IsLoginEnabled);
            }
        }

        [PangeaRequired]
        [PasswordValidation]
        public string UserPassword
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    NotifyPropertyChanged(() => UserPassword);
                    NotifyPropertyChanged(() => IsLoginEnabled);
                }
            }
        }


        [UpdatedPasswordConfirmation]
        [NewPasswordRequired]
        [PasswordValidation]
        [UpdatedPasswordEqualToOldPassword]
        public string NewPassword
        {
            get
            {
                return _newPassword;
            }

            set
            {
                _newPassword = value;
                NotifyPropertyChanged(() => NewPassword);
                NotifyPropertyChanged(() => ConfirmPassword);
            }
        }


        [UpdatedPasswordConfirmation]
        [ConfirmPasswordRequired]
        [PasswordValidation]
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }

            set
            {
                _confirmPassword = value;
                NotifyPropertyChanged(() => ConfirmPassword);
                NotifyPropertyChanged(() => NewPassword);
            }
        }

        public string ErrorMsg
        {
            get
            {
                return _errorMsg;
            }
            set
            {
                _errorMsg = value;
                NotifyPropertyChanged(() => ErrorMsg);
            }
        }

        public string ScreenMode
        {
            get
            {
                return _screenMode.ToString();
            }
        }

        public bool ShowChangePassword
        {
            get
            {
                return _showChangePassword;
            }

            set
            {
                if (value)
                    ChangeMode(ScreenType.ChangePassword);
                else
                    ChangeMode(ScreenType.Login);

                _showChangePassword = value;
                NotifyPropertyChanged(() => ShowChangePassword);
                NotifyPropertyChanged(() => NewPassword);
                NotifyPropertyChanged(() => ConfirmPassword);
            }
        }

        public bool IsLoginEnabled
        {
            get
            {
#if DEBUG
                return true;
#else
                return !UserPassword.IsNullOrEmpty() && !Username.IsNullOrEmpty() &&
                        new PasswordValidationAttribute().IsValid(UserPassword) &&
                        NGU.Common.Utilities.PasswordHelper.IsUserNameValid(Username);
#endif
            }
        }

        public bool SetNewPasswordFocus
        {
            get { return _setNewPasswordFocus; }
            set
            {
                _setNewPasswordFocus = value;
                NotifyPropertyChanged(() => SetNewPasswordFocus);
                if (value)
                {
                    _setNewPasswordFocus = false;
                    NotifyPropertyChanged(() => SetNewPasswordFocus);
                }
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new RelayCommand(Login);

                return _loginCommand;
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                    _clearCommand = new RelayCommand(Clear);

                return _clearCommand;
            }
        }

        public ICommand ChangePasswordCommand
        {
            get
            {
                if (_changePasswordCommand == null)
                    _changePasswordCommand = new Pangea.BaseStructures.RelayCommand(ChangePassword);

                return _changePasswordCommand;
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Check if the chnage password is correct
        /// </summary>
        /// <returns></returns>
        private bool ChangePasswordValid()
        {
            // Check if the new or confirm password are not empty
            if (NewPassword.IsNullOrEmpty() || ConfirmPassword.IsNullOrEmpty())
                return false;

            // Check if the new and confirm password equal
            if (!NewPassword.Equals(ConfirmPassword))
                return false;

            // Chcek if the old and new password are equal
            if (NewPassword.Equals(UserPassword))
                return false;

            // Check if the new password is correct
            if (!NGU.Common.Utilities.PasswordHelper.IsPasswordValid(NewPassword))
                return false;

            return true;
        }

        private void Login(object param)
        {
#if DEBUG
            if (Username.IsNullOrEmpty() || UserPassword.IsNullOrEmpty())
            {
                if (System.Environment.MachineName.ToUpper().Contains("MEITAL"))
                {
                    if (Username.IsNullOrEmpty())
                        Username = "MEITALZ";
                }
                else
                {
                    if (Username.IsNullOrEmpty())
                        Username = System.Environment.UserName.ToUpper();
                }

                if (UserPassword.IsNullOrEmpty())
                    UserPassword = "Aa123456";
            }
#endif
            ScreenType state = param.ToString().ToEnum<ScreenType>();

            bool isValid = InitializeDataForUser(Username, UserPassword, NewPassword, state);
            if (!isValid)
            {
                NotifyPropertyChanged(() => ErrorMsg);
                return;
            }

            if (LoggedUser != null)
            {
                ////load menuImages
                //foreach (var m in LoggedUser.Menus)
                //{
                //    string key = m.ViewModelTypeID.ToString().ToEnum<ViewModelTypes>().GetResourceKey();
                //    m.MenuImage = GetMenuImage(key) != null ? GetMenuImage(key) : GetMenuImage("EmptyMenuImage");
                //}

                ViewModelTypes type = ViewModelTypes.MainMenu;
                BaseViewModel.WindowModel.CurrentViewModel = AppUtilities.GetViewModel((int)type, null);
                BaseViewModel.WindowModel.TopPanel.NotifyUser();
            }

            NotifyPropertyChanged(() => ErrorMsg);
        }

        private bool InitializeDataForUser(string username, string password, string newPassword, ScreenType state)
        {
            username = username.ToUpper();

            if (password.IsNullOrEmpty() || username.IsNullOrEmpty())
                return false;

            UserValidation userValidationDto = null;

            //state login
            if (state == ScreenType.Login)
                userValidationDto = UserService.CheckUserValidityWithPassword(username, password, true, BaseViewModel.DefaultModuleLanguage);

            //state ChangePassword
            if (state == ScreenType.ChangePassword)
            {
                if (!ChangePasswordValid())
                {
                    ErrorMsg = Lang.Resources.MSG_FixValidationErrorsFirst;
                    LoggedUser = null;
                    return false;
                }

                if (!NewPassword.IsNullOrEmpty())
                    userValidationDto = UserService.UpdateUserPassWord(username, password, newPassword, BaseViewModel.DefaultModuleLanguage);
            }

            bool isValid = CheckUserValidity(userValidationDto);

            if (!isValid)
                return false;

            return true;
        }

        private bool CheckUserValidity(UserValidation userValidationDto)
        {
            switch (userValidationDto.LoginResult)
            {
                case UserLoginResultTypes.Success:
                    LoggedUser = userValidationDto.LoggedUser;
                    Language.SystemLanguage = userValidationDto.SelectedLanguage;
                    ErrorMsg = null;
                    return true;

                case UserLoginResultTypes.Faild:
                    switch (userValidationDto.UserValidationType)
                    {
                        case UserValidationTypes.UserNotActive:
                            ErrorMsg = Lang.Resources.ERR_UserIsPassive;
                            break;
                        case UserValidationTypes.UserNotFound:
                        case UserValidationTypes.PasswordIncorrect:
                            ErrorMsg = Lang.Resources.ERR_UsernameOrPasswordIncorrect;
                            break;
                        case UserValidationTypes.Faild:
                        case UserValidationTypes.UserLoggedToManyTimes:
                        case UserValidationTypes.NewAndOldPasswordMatch:
                            ErrorMsg = Lang.Resources.ERR_NewOldPasswordsMatch;
                            break;
                    }
                    return false;

                case UserLoginResultTypes.ChangePasswordRequired:
                    ErrorMsg = Lang.Resources.ERR_MustChangePassword;
                    ShowChangePassword = true;
                    return false;
            }

            return false;
        }

        private void ChangeMode(ScreenType type)
        {
            _screenMode = type;

            NotifyPropertyChanged(() => ScreenMode);
        }

        private void ChangePassword(object obj)
        {
            ShowChangePassword = !ShowChangePassword;
        }

        private void Clear(object param)
        {
            ErrorMsg = null;
            Username = null;
            UserPassword = null;

            NewPassword = null;
            ConfirmPassword = null;
        }

        #endregion

        //todo: move to helpers
        private byte[] GetMenuImage(string key)
        {
            if (Application.Current == null)
                return new byte[0];

            object img = null;

            if (!key.IsNullOrEmpty())
                img = Application.Current.TryFindResource(key);

            if (img == null)
                img = Application.Current.TryFindResource("EmptyMenuImage");

            byte[] data = ((BitmapImage)img).ToByteArray(typeof(PngBitmapEncoder));

            return data;
        }
    }
}
