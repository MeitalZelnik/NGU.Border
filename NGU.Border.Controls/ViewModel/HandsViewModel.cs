using Pangea.BaseStructures;
using Pangea.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Border.Controls.ViewModel
{
    internal class HandsViewModel : PangeaViewModelBase
    {
        private Dictionary<string, FingerStatus> _mapFingers;
        private RelayCommand _selectFingerCommand;
        private bool _isVerifyMode;

        public Dictionary<string, FingerStatus> MapFingers
        {
            get
            {
                return _mapFingers;
            }
            set
            {
                _mapFingers = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand SelectFingerCommand
        {
            get
            {
                if (_selectFingerCommand == null)
                    _selectFingerCommand = new RelayCommand(OnSelectFingerCommand);

                return _selectFingerCommand;
            }
        }

        public string CurrentFinger { get; private set; }

        public bool IsVerifyMode 
        { 
            get
            {
                return _isVerifyMode;
            }
            set
            {
                _isVerifyMode = value;
                NotifyPropertyChanged();
            }
        }

        private void OnSelectFingerCommand(object obj)
        {
            string fingerName = obj.ToString();
            if (fingerName.IsNullOrEmpty())
                return;

            CurrentFinger = fingerName;

            NotifyPropertyChanged(() => CurrentFinger);
        }
    }
}
