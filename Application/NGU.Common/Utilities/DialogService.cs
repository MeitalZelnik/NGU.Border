using NGU.Enums;
using NGU.Common.Windows;
using Pangea.Extensions;
using Pangea.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace NGU.Common.Utilities
{
    public class DialogBoxResult
    {
        public DialogButtons? Button;
    }

    public class DialogService 
    {
        #region public props 

        public Dispatcher SystemDispatcher
        {
            get
            {
                return _systemDispatcher;
            }
            set
            {
                _systemDispatcher = value;
            }
        }

        #endregion

        #region members

        private IList<DialogButtons> _buttons;
        private DependencyObject _userControl;
        private string _title;

        private int? _height;
        private int? _width;
        private DialogTypes _dialogTypes = DialogTypes.None;
        private static Dispatcher _systemDispatcher = null;

        #endregion

        #region popup methods

        public DialogBoxResult ShowDialog()
        {
            return ShowWindow(null);
        }

        public DialogBoxResult ShowDialog(string message)
        {
            SetButtons(DialogButtons.OK);
            SetDialogTypes(DialogTypes.Info);
            return ShowWindow(message);
        }

        public DialogBoxResult ShowDialogError(string message)
        {
            SetDialogTypes(DialogTypes.Error);
            return ShowWindow(message);
        }

        public bool ShowQuestionYesNo(string message, DialogTypes? dialogTypes = null)
        {
            SetButtons(DialogButtons.Yes, DialogButtons.No);

            if (dialogTypes != null)
                SetDialogTypes(dialogTypes.Value);
            else
                SetDialogTypes(DialogTypes.Question);

            var res = ShowWindow(message);
            return res.Button == DialogButtons.Yes;
        }

        #endregion

        #region set methods

        public DialogService SetButtons(params DialogButtons[] buttons)
        {
            _buttons = buttons.ToList(); //todo handle multiLanguage!!!!!!!!!!
            return this;
        }

        public DialogService SetUserControl(DependencyObject userControl)
        {
            _userControl = userControl;
            return this;
        }

        public DialogService SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public DialogService SetWindowDimensions(int? height, int? width)
        {
            _height = height;
            _width = width;
            return this;
        }

        public DialogService SetDialogTypes(DialogTypes dialogTypes)
        {
            _dialogTypes = dialogTypes;
            return this;
        }

        #endregion

        #region private methods

        private DialogBoxResult ShowWindow(string msg, params object[] strFormat)
        {
            DialogBoxResult dbr = null;

            if (SystemDispatcher != null)
                SystemDispatcher.Invoke(new Action(() => dbr = ShowWindowExecute(msg, strFormat)));
            else
                dbr = ShowWindowExecute(msg, strFormat);

            return dbr;
        }

        private DialogBoxResult ShowWindowExecute(string msg, params object[] strFormat)
        {
            if (msg != null && strFormat.Count() > 0)
                msg = string.Format(msg, strFormat);

            if (_buttons == null && _userControl == null)
                SetButtons(DialogButtons.OK);

            DialogBoxWindow dialogBox = new DialogBoxWindow(_userControl, msg, _buttons,  _height, _width, _dialogTypes);

            // Fill the Tag so the Application can find it in the current windows
            dialogBox.Tag = "PopupChild";

            try
            {
                //if (Application.Current.MainWindow.IsVisible)
                dialogBox.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            if (!_title.IsNullOrEmpty())
                dialogBox.Title = _title;

            _buttons = null;
            _userControl = null;
            

            _title = null;
            _dialogTypes = DialogTypes.None;

            dialogBox.ShowDialog();

            _height = null;
            _width = null;

            return dialogBox.DialogBoxResult;
        }

        #endregion
    }

    public enum DialogTypes
    {
        None,
        Error,
        Info,
        Question,
        Warning
    }
}
