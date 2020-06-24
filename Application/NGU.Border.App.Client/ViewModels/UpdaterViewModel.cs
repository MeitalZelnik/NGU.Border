using NGU.App.DTO;
using NGU.Enums;
using Pangea.Client.WPF.CustomControls;
using NGU.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Pangea.Utils;
using Pangea.BaseStructures;
using NGU.Lang;

namespace NGU.App.Client.ViewModels
{
    public class UpdaterViewModel : PangeaViewModelBase
    {
        #region Members

        private ICommand _startDownloadCommand;
        private ICommand _okCommand;

        private string _versionZipFileName;
        private string _extractFolderPath;
        public event EventHandler CloseVMEvent;

        private VersionDownloadStates _versionDownloadState;

        #endregion Members

        #region Ctor

        public UpdaterViewModel(string VersionZipFileName, string ExtractFolderPath)
        {
            _versionZipFileName = VersionZipFileName;
            _extractFolderPath = ExtractFolderPath;

            VersionDownloadState = VersionDownloadStates.BeforeDownloading;
        }

        #endregion Ctor

        #region commands

        public ICommand StartDownloadCommand
        {
            get
            {
                if (_startDownloadCommand == null)
                    _startDownloadCommand = new RelayCommand(StartDownload);

                return _startDownloadCommand;
            }
        }

        public ICommand OKCommand
        {
            get
            {
                if (_okCommand == null)
                    _okCommand = new RelayCommand(OK);

                return _okCommand;
            }
        }

        #endregion

        #region Properties

        public string Title
        {
            get
            {
                return Resources.UpdateVersionWindowTitle;
            }
        }

        public VersionDownloadStates VersionDownloadState
        {
            get { return _versionDownloadState; }
            set
            {
                _versionDownloadState = value;

                NotifyPropertyChanged(() => VersionDownloadState);
            }
        }

        public SystemUpdateDTO SystemUpdateDTO { get; set; }

        #endregion

        #region Methods

        public void StartDownload(object param)
        {
            VersionDownloadState = VersionDownloadStates.Downloading;
            
            ProcessHelper.RunMethodOnDifferentTask(() =>
            {
                System.Threading.Thread.Sleep(1500);

                bool succeed = Download();

                CloseViewModel(succeed);
            });
        }

        private bool Download()
        {
            try
            {
                SystemUpdateDTO = GetSystemUpdate();
            }
            catch (Exception e)
            {
                return false;
            }

            if (!SystemUpdateDTO.Successful)
                return false;

            try
            {
                if (Directory.Exists(_extractFolderPath))
                {
                    DirectoryInfo info = new DirectoryInfo(_extractFolderPath);
                    foreach (var file in info.GetFiles())
                    {
                        file.Delete();
                    }

                    foreach (var dir in info.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
                else
                {
                    Directory.CreateDirectory(_extractFolderPath);
                }

                string fullUpdatedZipPath = _extractFolderPath + @"\" + _versionZipFileName;

                File.WriteAllBytes(fullUpdatedZipPath, SystemUpdateDTO.ZipData);
                //ZipFile.ExtractToDirectory(fullUpdatedZipPath, _extractFolderPath);
                File.Delete(fullUpdatedZipPath);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private void OK(object param)
        {
            if (CloseVMEvent != null)
                CloseVMEvent(null, EventArgs.Empty);
        }

        private void CloseViewModel(bool succedDownloading)
        {
            if (succedDownloading)
                VersionDownloadState = VersionDownloadStates.DownloadSucceed;
            else
                VersionDownloadState = VersionDownloadStates.DownloadFailed;
        }

        private SystemUpdateDTO GetSystemUpdate()
        {
            SystemUpdateDTO systemUpdateDTO = null;

            try
            {
                //systemUpdateDTO = SystemService.GetSystemUpdate();
            }
            catch (Exception ex)
            {
                systemUpdateDTO = new SystemUpdateDTO() { Message = "failed on SystemService.GetSystemUpdate()", Successful = false };
            }

            return systemUpdateDTO;
        }

        #endregion
    }
}
