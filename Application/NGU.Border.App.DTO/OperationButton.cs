using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Pangea.BaseStructures;

namespace NGU.App.DTO
{
    public class OperationButton : ObjectValidationBase
    {
        public string Text { get; set; }
        public Action<object> OperationAction { private get; set; }
        public object OperationParameter { get; set; }
        public Brush Background { get; set; }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                NotifyPropertyChanged();
            }
        }
        
        #region private

        private RelayCommand _operationCommand = null;
        private bool _isEnabled = true;

        #endregion

        public RelayCommand OperationCommand
        {
            get
            {
                if (_operationCommand == null)
                    _operationCommand = new RelayCommand(Operation, CanOperaionExecute);

                return _operationCommand;
            }
        }

        public Func<object, bool> CanExecuteOperation { get; set; }

        private bool CanOperaionExecute(object obj)
        {
            if (CanExecuteOperation != null)
                return CanExecuteOperation(obj);

            return true;
        }

        private void Operation(object obj)
        {
            if (OperationAction != null)
                OperationAction(obj);
        }

        public void RaisCanExecute()
        {
            OperationCommand.RaiseCanExecuteChanged();
        }
    }
}
