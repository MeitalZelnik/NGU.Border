using NGU.App.Client.Utitlities;
using NGU.Core;
using NGU.Enums;
using NGU.Interfaces;
using NGU.Common.Utilities;
using Pangea.Logger;
using Pangea.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using Pangea.Utils;
using System.Collections.ObjectModel;
using Pangea.BaseStructures;
using NGU.Lang;
using Pangea.MultiLanguage;
using NGU.Interfaces.ApiAdmin;
using Pangea.DialogService;
using Languages = Pangea.MultiLanguage.Languages;
using System.Reflection;
using Pangea.App.Services;

namespace NGU.App.Client.ViewModels
{
	public class TopPanelViewModel : BaseViewModel
	{
		#region ctor

		public TopPanelViewModel()
		{
			SelectedLang = AllLanguages.FirstOrDefault(x => x.Code == Language.SystemLanguage.ToString());
			_versionNo = Assembly.GetExecutingAssembly().GetName().Version;
		}

		#endregion

		#region members

		private Version _versionNo;// = typeof(App).Assembly.GetName().Version;
		private string _systemTitle = Resources.MainWindowTitle;
		private string _systemType = null;
		private string _computerName;
		private ICommand _helpCommand = null;
		private ICommand _changeLangCommand;
		private Language _selectedLang;
		private ICommand _minimizeWindowCommand = null;
		private ICommand _changeCurrentViewCommand = null;
		private ICommand _closeSystemCommand = null;
		private ICommand _logoutUserCommand;
		private ICommand _changePasswordCommand;

		#endregion

		#region props

		public string SystemType
		{
			get
			{
				try
				{
					if (_systemType == null)
					{
						_systemType = AppSettingsHelper.IsTestMode() ? "TST" : "PROD"; //ServicesInstances.GetSystemParameterValue(SystemSettingsKeys.TST_PROD).Value; //"DbEnv"
						if (_systemType.Upper() == "PROD") // if the value is PROD disappear it.
							_systemType = string.Empty;
					}
				}
				catch
				{
					_systemType = string.Empty;
				}

				return _systemType;
			}
		}

		public string UnitType { get; set; }

		public string VersionNo
		{
			get
			{
				if (_versionNo != null)
					return _versionNo.ToString(4);

				return null;
			}
		}

		public bool IsModule
		{
			get
			{
				if (BaseViewModel.WindowModel != null)
				{
					//bool result = (BaseViewModel.WindowModel.CurrentViewModel is EnquiryContainerViewModel);

					bool result = (BaseViewModel.WindowModel.CurrentViewModel is MainFlowViewModel || BaseViewModel.WindowModel.CurrentViewModel is SubMainMenuViewModel || BaseViewModel.WindowModel.CurrentViewModel is WorkspaceContainerViewModel);

					return result;
				}

				return false;
			}
		}

		public string BackButtonText
		{
			get
			{
				//if (AppSettingsHelper.IsFlowSchememMode)
				//    return AppSettingsHelper.GetResourceValue("TaskList");

				//Back

				return Resources.MainMenu;
			}
		}

		public bool IsMainMenu
		{
			get
			{
				return !IsModule;
			}
		}

		public string HeaderTitle
		{
			get
			{
				if (BaseViewModel.WindowModel.CurrentViewModel == null)
					return string.Empty;

				if (BaseViewModel.WindowModel.CurrentViewModel.ViewText.IsNullOrEmpty())
					return _systemTitle.ToString();

				if (SystemType.IsNullOrEmpty())
					return string.Format("{0} - {1}", _systemTitle, BaseViewModel.WindowModel.CurrentViewModel.ViewText.Upper());

				return string.Format("{0} - {1} - {2}", SystemType, _systemTitle, BaseViewModel.WindowModel.CurrentViewModel.ViewText.Upper());
			}
		}

		public User User
		{
			get
			{
				return AppSettingsHelper.LoggedUser;
			}
		}

		public string ComputerName
		{
			get
			{
				return _computerName;
			}

			set
			{
				_computerName = value;
				NotifyPropertyChanged("ComputerName");
			}
		}

		public string ComputerHeader
		{
			get
			{
				return Resources.ComputerName;
			}
		}

		public string UserName
		{
			get
			{
				if (User != null)
					return User.Username;
				return string.Empty;
			}
		}

		public string UserFullName
		{
			get
			{
				if (User != null)
					return "todo:fullname " + User.Username;
				return string.Empty;
			}
		}

		public string UserFirstNames
		{
			get
			{
				if (User != null)
					return "";
				return string.Empty;
			}
		}

		public string LocationHeader
		{
			get
			{
				return Resources.Location;
			}
		}

		public string Location
		{
			get
			{
				if (User == null)
					return null;

				//return AllLocations.FirstOrDefault(x => x.Code == User.Location.Code).Description();
				return "todo!!";
			}
		}

		public string UserFullNameHeader
		{
			get
			{
				return Resources.UserDetails;
			}
		}

		public string UserLastName
		{
			get
			{
				if (User != null)
					return "";
				return string.Empty;
			}
		}

		public byte[] UserPhoto
		{
			get
			{
				if (User != null && User.Photo != null)
					return User.Photo; //return new byte[0];
				else
					return null;
			}
		}

		public string Role
		{
			get
			{
				if (User != null)
				{
					StringBuilder sbRole = new StringBuilder();
					foreach (Role role in User.Roles)
					{
						if (sbRole.Length > 0)
							sbRole.Append(", ");

						sbRole.Append(role.Name);
					}

					return sbRole.ToString();
				}

				return string.Empty;
			}
		}

		public string RoleHeader
		{
			get
			{
				return Resources.Role;
			}
		}

		public Language SelectedLang

		{
			get
			{
				return _selectedLang;

			}
			set
			{
				_selectedLang = value;
				NotifyPropertyChanged("SelectedLang");
			}
		}

		public bool IsUserLogged
		{
			get
			{
				return User != null;
			}
		}

		public string Unit
		{
			get
			{
				if (User == null || User.Site == null)
					return null;

				return User.Site.Name;
			}
		}

		public string UnitHeader
		{
			get
			{
				return Resources.Site;
			}
		}

		public string Title
		{
			get
			{
				return _systemTitle;
			}
		}

		public string LogoutBtnText
		{
			get
			{
				return Resources.Logout;
			}
		}

		public string ChangePasswordBtnText
		{
			get
			{
				return Resources.ChangePassword;
			}
		}

		#endregion

		#region Command

		public ICommand ChangeLangCommand
		{
			get
			{
				if (_changeLangCommand == null)
				{
					_changeLangCommand = new RelayCommand(ChangeLang);
				}
				return _changeLangCommand;
			}
		}

		public ICommand ChangePasswordCommand
		{
			get
			{
				if (_changePasswordCommand == null)
				{
					_changePasswordCommand = new RelayCommand(ChangeUserPassword);
				}
				return _changePasswordCommand;
			}
		}

		public ICommand LogoutUserCommand
		{
			get
			{
				if (_logoutUserCommand == null)
				{
					_logoutUserCommand = new RelayCommand(UserLogout);
				}

				return _logoutUserCommand;
			}
		}

		public ICommand CloseSystemCommand
		{
			get
			{
				if (_closeSystemCommand == null)
				{
					_closeSystemCommand = new RelayCommand(CloseSystem);
				}

				return _closeSystemCommand;
			}
		}

		public ICommand MinimizeWindowCommand
		{
			get
			{
				if (_minimizeWindowCommand == null)
				{
					_minimizeWindowCommand = new RelayCommand(MinimizeWindow);
				}

				return _minimizeWindowCommand;
			}
		}

		public ICommand ChangeCurrentViewCommand
		{
			get
			{
				if (_changeCurrentViewCommand == null)
				{
					_changeCurrentViewCommand = new RelayCommand(ChangeCurrentView);
				}

				return _changeCurrentViewCommand;
			}
		}

		public ICommand HelpCommand
		{
			get
			{
				if (_helpCommand == null)
				{
					//_helpCommand = new RelayCommand(Help);
				}

				return _helpCommand;
			}
		}

		#endregion Command

		#region Method

		private void ChangeLang(object param)
		{
			Utilities.ChangeDefaultLanguage(SelectedLang.Code.ToEnum<Languages>());

			var current = BaseViewModel.WindowModel.CurrentViewModel;
			BaseViewModel.WindowModel = new MainViewModel();
			BaseViewModel.WindowModel.CurrentViewModel = current;

			Utilities.RefreshView(SelectedLang.Code, BaseViewModel.WindowModel);
		}

		private void UserLogout(object param)
		{
			//DialogService.NotifyStatusBar(string.Empty, StatusBarMessageTypes.RegularMessage);

			//bool isIModuleFunctions = WindowModel.CurrentViewModel is IModuleFunctions;
			//// If user enter changes, ask for discard changes before loging out.
			//if (!isIModuleFunctions ||
			//   ((isIModuleFunctions && !((IModuleFunctions)WindowModel.CurrentViewModel).HasChanged) ||
			//     DialogService.ShowDialogYesNo(MessagesFinder.ChangesWillBeDiscarded, DialogTypes.Warning)))
			//{
			//    CallCancelBase();

			Logout();
			//  }
		}

		public void Logout()
		{
			//Channels.UserService.InsertLogoutUserLog(LoggedUser);

			if (LoggedUser != null)
				LoggedUser = null;
			//   HandleDeleteOfUserAndCrashFile();

			//// Close all open windos excpt the main windos
			//foreach (Window win in Application.Current.Windows)
			//{
			//    if (win.Tag == "PopupChild")
			//        win.Close();
			//}

			NotifyUser();

			//// Reset main-menu's menus.
			//MainMenuViewModel.ClearMenus();
			//MainStartViewModel.ClearMenus();

			//BaseContainerViewModel.ContextCollection.Clear();
			//BaseContainerViewModel.CurrentRequest = null;

			// Go to login page.
			BaseViewModel.WindowModel.CurrentViewModel = AppUtilities.GetViewModel(ViewModelTypes.Login, ViewModelTypes.Logout);
		}

		private void ChangeUserPassword(object param)
		{
			bool isIModuleFunctions = WindowModel.CurrentViewModel is IModuleFunctions;
			// If user enter changes, ask for discard changes before changing password.
			if (!isIModuleFunctions ||
				((isIModuleFunctions && !((IModuleFunctions)WindowModel.CurrentViewModel).HasChanged) ||
				DialogService.ShowQuestionYesNo(Resources.MSG_ChangesWillBeDiscarded, DialogTypes.Warning)))
			{
				BaseViewModel.WindowModel.CurrentViewModel = AppUtilities.GetViewModel(ViewModelTypes.ChangePassword, null);
			}
		}

		public void CloseSystem(object param)
		{
			//if (LoggedUser != null)
			//	UserService.InsertLogoutUserLog(LoggedUser);

			if (DialogService.ShowQuestionYesNo(Resources.MSG_AreYouSureYouWantToExit, DialogTypes.Warning))
			{
				string paramStr = (string)param;
				WindowModel.CurrentViewModel = AppUtilities.GetViewModel(paramStr, WindowModel.CurrentViewModel);
			}

			//if ((WindowModel.CurrentViewModel is BaseContainerViewModel) &&
			//	((WindowModel.CurrentViewModel as BaseContainerViewModel).CurrentIModuleFunction.HasChanged))
			//{
			//	if (DialogService.ShowQuestionYesNo(Resources.MSG_ChangesWillBeDiscarded, DialogTypes.Warning))
			//	{
			//		string paramStr = (string)param;
			//		WindowModel.CurrentViewModel = AppUtilities.GetViewModel(paramStr, WindowModel.CurrentViewModel);
			//	}
			//}
			//else if (DialogService.ShowQuestionYesNo(Resources.MSG_AreYouSureYouWantToExit, DialogTypes.Warning))
			//{
			//	string paramStr = (string)param;
			//	WindowModel.CurrentViewModel = AppUtilities.GetViewModel(paramStr, WindowModel.CurrentViewModel);
			//}
		}

		public void MinimizeWindow(object param)
		{
			if (param is Window)
				((Window)param).WindowState = WindowState.Minimized;
		}

		public void ChangeCurrentView(object param)
		{
			bool isIModuleFunctions = WindowModel.CurrentViewModel is IModuleFunctions;

			if (!isIModuleFunctions || ((isIModuleFunctions && !((IModuleFunctions)WindowModel.CurrentViewModel).HasChanged) || DialogService.ShowQuestionYesNo(Resources.MSG_ChangesWillBeDiscarded, DialogTypes.Warning)))
			{
				if (param is Menu)
				{
					WindowModel.CurrentViewModel = AppUtilities.GetViewModel(((Menu)param).ID, param);
				}
				else if (param is string)
				{
					bool changeCurrentView = true;

					try
					{
						if (param.ToString().ToUpper() == "EXIT")
						{
							try
							{
								// dialog reterns 'false' when we do not want to exit (so dont change the current view)
								changeCurrentView = DialogService.ShowQuestionYesNo(Resources.MSG_AreYouSureYouWantToExit, DialogTypes.Warning);

								if (changeCurrentView)
								{
									//CallCancelBase();

									//HandleDeleteOfUserAndCrashFile();
								}
							}
							catch (Exception ex)
							{
								// in case we get stuck on 'Exit' it just thrwos us out.
								Log.Error(ex);
								changeCurrentView = true;
							}
						}
					}
					finally
					{
						if (changeCurrentView)
						{
							// check if the CurrentViewModel is not null so we can Clean it.
							if (WindowModel.CurrentViewModel != null)
								WindowModel.CurrentViewModel.Dispose();


							string paramStr = (string)param;

							WindowModel.CurrentViewModel = AppUtilities.GetViewModel(paramStr, WindowModel.CurrentViewModel);

							if (WindowModel.CurrentViewModel != null)
								WindowModel.CurrentViewModel.Refresh();
						}
					}

				}
			}
		}

		public void NotifyTopPanel()
		{
			NotifyPropertyChanged(() => IsModule);
			NotifyPropertyChanged(() => IsMainMenu);
			NotifyPropertyChanged(() => BackButtonText);
			NotifyPropertyChanged(() => HeaderTitle);
		}

		public void NotifyUser()
		{
			NotifyPropertyChanged(() => User);
			NotifyPropertyChanged(() => UserName);
			NotifyPropertyChanged(() => UserPhoto);
			NotifyPropertyChanged(() => UserFullName);
			NotifyPropertyChanged(() => IsUserLogged);
			NotifyPropertyChanged(() => ComputerHeader);

			NotifyPropertyChanged(() => UserFirstNames);
			NotifyPropertyChanged(() => UserLastName);
			NotifyPropertyChanged(() => UserFullNameHeader);

			NotifyPropertyChanged(() => UnitHeader);
			NotifyPropertyChanged(() => Unit);

			NotifyPropertyChanged(() => RoleHeader);
			NotifyPropertyChanged(() => Role);

			NotifyPropertyChanged(() => LocationHeader);
			NotifyPropertyChanged(() => Location);
		}

		#endregion Method

		internal void SetUserPreferredLanguage()
		{
			if (LoggedUser != null && !LoggedUser.Language.IsNullOrEmpty())
				SelectedLang = AllLanguages.FirstOrDefault(x => x.Code == LoggedUser.Language);
		}
	}
}
