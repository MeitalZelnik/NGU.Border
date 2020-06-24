using Pangea.App.Utils;
using Pangea.BaseStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NGU.App.Client.ViewModels
{
    public class View12ViewModel : BaseViewModel, IOperationPrint
    {
        public void Print()
        {
            throw new NotImplementedException();
        }

        private ICommand _captureCommand;

        public ICommand CaptureCommand
        {
            get
            {
                if (_captureCommand == null)
                {
                    _captureCommand = new RelayCommand(Capture);
                }

                return _captureCommand;
            }
        }

        private void Capture(object obj)
        {
            ChangeViewModelInstance(new View13ViewModel(this));
        }

        public bool CanExecute(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
