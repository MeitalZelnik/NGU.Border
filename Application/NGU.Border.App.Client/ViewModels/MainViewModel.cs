using Pangea.BaseStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NGU.App.Client.ViewModels
{
    public class MainViewModel : PangeaViewModelBase
    {
        #region members

        private PangeaViewModelBase _currentViewModel = null;
        private TopPanelViewModel _topPanel;

        #endregion

        #region props

        public PangeaViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                NotifyPropertyChanged(() => CurrentViewModel);

                TopPanel.NotifyTopPanel();
            }
        }
        
        public TopPanelViewModel TopPanel
        {
            get
            {
                if (_topPanel == null)
                {
                    _topPanel = new TopPanelViewModel();

                    _topPanel.ComputerName = Environment.MachineName.ToUpper();
                }

                return _topPanel;
            }
            set
            {
                _topPanel = value;
                NotifyPropertyChanged(() => TopPanel);
            }
        }

        #endregion


        //get from baseStructures
        private readonly DispatcherTimer _timer;

        public MainViewModel()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Start();
            _timer.Tick += (o, e) => NotifyPropertyChanged(() => CurrentTime);
        }

        public DateTime CurrentTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        //-----get from baseStructures
    }
}