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
    public class View13ViewModel : BaseViewModel, IOperationDelete
    {
        public View13ViewModel(View12ViewModel biometricViewModel)
        {
            _biometricViewModel = biometricViewModel;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        private ICommand _myBackCommand;
        private View12ViewModel _biometricViewModel;

        public ICommand MyBackCommand
        {
            get
            {
                if (_myBackCommand == null)
                {
                    _myBackCommand = new RelayCommand(MyBack);
                }

                return _myBackCommand;
            }
        }

        private void MyBack(object obj)
        {
            ChangeViewModelInstance(_biometricViewModel);
        }

        public bool CanExecute(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
