using NGU.App.Client.Utitlities;
using NGU.App.Client.ViewModels;
using NGU.Enums;
using NGU.Interfaces.Services;
using NGU.Common.Utilities;
using Pangea.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows;
using Pangea.Utils;
using NGU.Core;
using Pangea.BaseStructures;
using Pangea.MultiLanguage;
using Pangea.Extensions;
using System.Threading.Tasks;
using Pangea.App.Services;
using Pangea.DialogService;

namespace NGU.App.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region props

        public static DialogService DialogService
        {
            get
            {
                return new DialogService();
            }
        }

        public static ISystemService SystemService
        {
            get
            {
                return Channels.SystemService;
            }
        }

        internal string ProjectEXE
        {
            get
            {
                return "NGU.Border.App.Client.Wpf.exe";
            }
        }

        internal string ProcessName
        {
            get
            {
                return "NGU.Border.App.Client.Wpf";
            }
        }

        #endregion

        #region ctor

        public App()
        {
            InitializeComponent();


            //wpf dispatcher exceptions
            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);

            //app domain exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Register on the main thread so when ProcessHelper throws an excption we show it.
            ProcessHelper.OnThrowExceptionToMainThread += ProcessHelper_OnThrowToMainThread;

            this.Exit += new ExitEventHandler(App_Exit);
            Console.WriteLine();
        }

        #endregion

        #region main public method

        [STAThread]
        public static void Main()
        {
            App app = null;
            SplashScreen splashScreen = null;
            MainWindow mainWindow = null;

            try
            {
#if DEBUG
				//to ensure the service will be active before calling it.
				Thread.Sleep(2000);
#endif

				// Show the SplashScreen on the opening
				splashScreen = new SplashScreen(Assembly.Load("Pangea.App.Design"), @"Splash\SplashImage.png");
				splashScreen.Show(true, true);

				app = new App();

                if (CheckRunningAppConcurrency(app))
                    return;

                if (!CheckServerToNetwork())
                    return;

                // Set the DialogService Dispatcher to work on when using DialogService in threads.  
                //DialogService.SystemDispatcher = Application.Current.Dispatcher;

                try
                {
                    Parallel.Invoke(() => 
                    {
                        // Create MainWindow so app.MainWindow will be set. DialogBox is a window and if created first closing dialog closes app.
                        mainWindow = new MainWindow();
                        BaseViewModel.WindowModel = new MainViewModel();
                        BaseViewModel.DefaultModuleLanguage = SetModuleDefaultLanguage();
                        BaseViewModel.WindowModel.CurrentViewModel = AppUtilities.GetViewModel(ViewModelTypes.Login, null);
                        mainWindow.DataContext = BaseViewModel.WindowModel;

                        // Set the DialogService Dispatcher to work on when using DialogService in threads.  
                        Application.Current.Dispatcher.Invoke(() => DialogService.SystemDispatcher = Application.Current.Dispatcher);
                    },
                        () => Channels.LoadSystemSettings(),
                                            () => RetreiveLocalIPAddress(),
                                            () => app.CreateAppResetTimer());
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    if (ex.InnerException != null)
                        err += $". Details: {ex.InnerException.Message}";
                    MessageBox.Show(err, "Application load error");
                    return;
                }

                //ServicesInstances.LoadSystemSettings();
                //LoadValueObjectHelperProps();
                //RetreiveLocalIPAddress();

                //LoadAllSystemSettings();
                //LoadValueObjectValues();
                //RetreiveLocalIPAddress();

                //app.CreateAppResetTimer();

                #region Check New Version

                if (app.IsThereNewVersion())
                {
                    app.CopyAndUpdateNewVersion();
                    return;
                }

                #endregion

                Log.Info("NGU.Border app started");

                app.Run(mainWindow);
            }
            catch (Exception e)
            {
                HandleException(e);
                return;
            }
        }

        #endregion

        #region private methods
        private static Languages SetModuleDefaultLanguage()
        {
            string defaultLanguage = Channels.GetSystemSettingsValue(SystemSettingsKeys.DEFAULT_LANG_IDENTITY).Value;
            return defaultLanguage.ToEnum<Languages>();
        }

        private static bool CheckRunningAppConcurrency(App app)
        {
            if (AppSettingsHelper.CheckMoreThenOneProcessOpen)
            {
                var exists = Process.GetProcessesByName(app.ProcessName).Count() > 1;
                if (exists)
                {
                    DialogService.ShowDialog(Lang.Resources.MSG_SystemAlreadyOpenOnThisPc);
                    return true;
                }
            }

            return false;
        }

        private static bool CheckServerToNetwork()
        {
#if DEBUG
            // to ensure the service will be active before calling it.
            //Thread.Sleep(5000);
#endif

            try
            {
                SystemService.IsAlive();
            }
            catch (Exception e)
            {
                Log.Error(e);

                DialogService.ShowDialogError(Lang.Resources.MSG_NetworkError);
                return false;
            }

            return true;
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            #region QAReader

            try
            {
                //QAReader.CloseDevice(); TODO handle!!!!!!!
            }
            catch { }

            #endregion QAReader

            #region SignaturePadUtility

            try
            {
                //SignaturePadUtility.ClearScreen();
            }
            catch
            {
                // Catch the exception and dont do anything
            }

            #endregion SignaturePadUtility

            #region LoggedUser

            try
            {
                //f (AppSettingsHelper.LoggedUser != null && AppSettingsHelper.LoggedUser.Key != null)
                //
                //   BaseViewModel.WindowModel.TopPanel.HandleDeleteOfUserAndCrashFile();
                //
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            #endregion LoggedUser

            #region AcroRd32

            //close adobe reader in case got left open after print pdf
            Process[] processes = Process.GetProcessesByName("AcroRd32");
            if (processes != null)
            {
                foreach (var p in processes)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            #endregion AcroRd32

            //7078
            Environment.Exit(0);
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            HandleException(e.Exception);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            HandleException(e);
        }

        private void ProcessHelper_OnThrowToMainThread(List<Exception> exceptions)
        {
            foreach (var e in exceptions)
            {
                // threads dont show any popup message, tehy write logs only!
                HandleException(e, false);
            }
        }

        private static void RetreiveLocalIPAddress()
        {
#if DEBUG
            string ipRegExStr = @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$";
            string correctIP = string.Empty;
            IPAddress[] ips = Dns.GetHostAddresses(Environment.MachineName);

            foreach (IPAddress ip in ips)
            {
                if (Regex.IsMatch(ip.ToString(), ipRegExStr))
                {
                    correctIP = ip.ToString();
                    break;
                }
            }

            Log.Info("Found IP address = " + correctIP);
#endif
        }

        private static void HandleException(Exception e, bool showDialog = true)
        {
            Log.Error(e);

            // if showDialog is set to false then don't show dialog message
            if (!showDialog)
                return;

            if (IsDatabaseException(e))
                DialogService.ShowDialogError(Lang.Resources.MSG_ErorDbConnection);
            else if (e.Message.Contains("request channel timed out while waiting for a reply"))
                DialogService.ShowDialogError(Lang.Resources.MSG_ErrorRequestTimeOut);
            else if (e.Message.Contains("cannot be used for communication because it is in the Faulted state"))
                DialogService.ShowDialogError(Lang.Resources.MSG_ServerConnectionDead);
            else
                DialogService.ShowDialogError(Lang.Resources.MSG_UnexpectedError);
        }

        private static bool IsDatabaseException(Exception e)
        {
            try
            {
                if (!(e is FaultException))
                    return false;
                if (!(e is FaultException<System.ServiceModel.ExceptionDetail>))
                    return false;
                var fe = (FaultException<System.ServiceModel.ExceptionDetail>)e;
                if (fe == null)
                    return false;
                var ed = fe.Detail;
                if (ed == null)
                    return false;
                string t = ed.Type;
                return (t.Contains("NHibernate") || t.Contains("Oracle"));
            }
            catch
            {
                return false;
            }
        }

        private static void LoadAllSystemSettings()
        {
            ProcessHelper.RunMethodOnDifferentTask(() =>
            {
                Channels.LoadSystemSettings();
            });
        }


        private void CreateAppResetTimer()
        {
            double interval = DateTime.Today.AddDays(1).AddHours(4).Subtract(DateTime.Now).TotalMilliseconds;
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.AutoReset = false;
            timer.Elapsed += ResetApp;
            timer.Start();
        }

        private void ResetApp(object sender, ElapsedEventArgs e)
        {
            try
            {
                Log.Info("ResetApp: Application will close");
                Thread t = new Thread(() =>
                {
                    Thread.Sleep(30000);
                    Log.Info("ResetApp: Closing application");
                    Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => Application.Current.Shutdown()));
                });

                t.Start();
            }
            catch (Exception)
            {
                Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() => Application.Current.Shutdown()));
            }
        }


        #endregion

        #region version uploader methods

        public string UpdatedVersionFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["UpdatedVersionFolder"];
            }
        }

        public string VersionZipFileName
        {
            get
            {
                return "client.zip";
            }
        }

        private bool IsThereNewVersion()
        {

#if DEBUG
            return false;
#endif
            try
            {
                var appVersion = AppUtilities.GetCurrentApplicationVersion();

                var serverVersion = GetServerVersion();

                return serverVersion > appVersion;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private Version GetServerVersion()
        {
            string currentVersionNoFromDb = Channels.GetSystemSettingsValue(SystemSettingsKeys.VERSION_NO_IDENTITY).Value;
            Version serverVersion = Version.Parse(currentVersionNoFromDb);

            return serverVersion;
        }

        private void CopyAndUpdateNewVersion()
        {
            try
            {
                UpdaterViewModel updater = new UpdaterViewModel(VersionZipFileName, UpdatedVersionFolder);
                DialogService.SetUserControl(updater).SetWindowDimensions(150, 450).ShowDialog();

                if (updater.VersionDownloadState == VersionDownloadStates.DownloadSucceed)
                {
                    CheckAndUpdateNipVersionUpdater();

                    Thread.Sleep(2000);

                    Process p = new Process();
                    p.StartInfo.FileName = @"NIP.VersionUpdater.exe";
                    p.StartInfo.Arguments = UpdatedVersionFolder + " " + ProjectEXE;
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void CheckAndUpdateNipVersionUpdater()
        {
            string versionFileName = "NIP.VersionUpdater.exe";

            if (File.Exists(UpdatedVersionFolder + @"\" + versionFileName))
            {
                FileVersionInfo ver1 = FileVersionInfo.GetVersionInfo(UpdatedVersionFolder + @"\" + versionFileName);

                if (File.Exists(versionFileName))
                {
                    FileVersionInfo ver2 = FileVersionInfo.GetVersionInfo(versionFileName);

                    Version v1 = Version.Parse(ver1.FileVersion);
                    Version v2 = Version.Parse(ver2.FileVersion);

                    if (v1 > v2)
                        File.Copy(UpdatedVersionFolder + @"\" + versionFileName, versionFileName, true);
                }
                else
                    File.Copy(UpdatedVersionFolder + @"\" + versionFileName, versionFileName);
            }
        }

        #endregion
    }
}
