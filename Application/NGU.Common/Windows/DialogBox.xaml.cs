using NGU.Enums;
using NGU.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pangea.Extensions;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pangea.BaseStructures;
using Lang = NGU.Lang;
using Pangea.Logger;

namespace NGU.Common.Windows
{
    /// <summary>
    /// Interaction logic for DialogBoxWindow.xaml
    /// </summary>
    public partial class DialogBoxWindow : Window
    {
        #region props

        public DialogBoxResult DialogBoxResult { get; private set; }

        public DialogService DialogService
        {
            get
            {
                return new DialogService();
            }
        }

        #endregion

        public DialogBoxWindow(DependencyObject userControl, string msg, IList<DialogButtons> dialogBoxButtons, int? height, int? width, DialogTypes dialogTypes = DialogTypes.None)
        {
            InitializeComponent();

            // Change mouse Cursor so it will not be Waiting.
            Mouse.OverrideCursor = null;
            this.Topmost = false;
            Title = Lang.Resources.MessageHeader;
            DialogBoxResult = new DialogBoxResult();
            lbl.Text = msg;

            // if no text enterd then Collapse the lbl.
            if (lbl.Text.IsNullOrEmpty())
                lbl.Visibility = System.Windows.Visibility.Collapsed;

            ContentControlArea.Content = userControl;

            if (dialogTypes != DialogTypes.None)
            {
                object img = Application.Current.TryFindResource(dialogTypes.ToString() + "DialogIcon");
                if (img != null)
                {
                    ImageSource bmpImg = img as ImageSource;
                    if (bmpImg != null)
                    {
                        DialogTypesArea.Visibility = System.Windows.Visibility.Visible;
                        DialogTypesArea.Source = bmpImg;
                    }
                }
            }

            if (height.HasValue)
                ContentControlArea.Height = height.Value;

            if (width.HasValue)
                ContentControlArea.Width = width.Value;

            CreateButtons(dialogBoxButtons);

            if (userControl != null)
            {
                var pi = userControl.GetType().GetProperty("Title");
                if (pi != null)
                    Title = pi.GetValue(userControl, null) as string;

                var ei = userControl.GetType().GetEvent("CloseVMEvent");
                if (ei != null)
                {
                    MethodInfo handler = typeof(DialogBoxWindow).GetMethod("CloseHandler");
                    Delegate del = Delegate.CreateDelegate(ei.EventHandlerType, this, handler);
                    ei.AddEventHandler(userControl, del);
                }

                this.Closing += ClosingDialogBox;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                DialogBoxResult.Button = btn.Tag as DialogButtons?;

                if (!CheckIfContentControlValid())
                {
                    // if content not valid set the return button value to null and do not close this window.
                    DialogBoxResult.Button = null;
                    return;
                }

                this.Close();
            }
        }

        private void CreateButtons(IList<DialogButtons> dialogBoxButtons)
        {
            if (dialogBoxButtons != null)
            {
                foreach (var dialogBtn in dialogBoxButtons)
                {
                    var btn = new Button()
                    {
                        Content = Lang.Resources.ResourceManager.GetString(dialogBtn.GetResourceKey()),
                        Tag = dialogBtn,
                    };

                    int? currwidth = 100;
                    if (currwidth.HasValue)
                        btn.Width = currwidth.Value;

                    btn.Click += btn_Click;
                    DialogBtnContainer.Children.Add(btn);
                }

                if (DialogBtnContainer.Children.Count > 0)
                    DialogBtnContainer.Children[DialogBtnContainer.Children.Count - 1].Focus();
            }
        }

        public void CloseHandler(object sender, EventArgs args)
        {
            try
            {
                Close();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private void ClosingDialogBox(object sender, CancelEventArgs e)
        {
            if (ContentControlArea.Content != null && DialogBoxResult.Button != DialogButtons.OK)
            {
                var propertyInfo = ContentControlArea.Content.GetType().GetProperty("HasChanged");

                if (propertyInfo != null)
                {
                    bool _hasChanged = (bool)propertyInfo.GetValue(ContentControlArea.Content, null);

                    if (_hasChanged && !DialogService.ShowQuestionYesNo(Lang.Resources.MSG_ChangesWillBeDiscarded, DialogTypes.Warning))
                        e.Cancel = true;
                }
            }
        }

        private bool CheckIfContentControlValid()
        {
            bool returnValue = true;

            // Check if OK pressed nad there is a Control set.
            if (DialogBoxResult.Button == DialogButtons.OK && ContentControlArea.Content != null)
            {
                ValidationViewModelBase baseValidation = ContentControlArea.Content as ValidationViewModelBase;
                // Check if control is type of ValidationViewModelBase and that its Valid.
                if (baseValidation != null && !baseValidation.IsValid())
                {
                    DialogService.SetDialogTypes(DialogTypes.Error).ShowDialog(Lang.Resources.MSG_FixValidationErrorsFirst);
                    //this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() => baseValidation.ValidateAndFocus = true));
                    returnValue = false;
                }
            }

            return returnValue;
        }

        private void tbViewMore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (innerLbl.Visibility == System.Windows.Visibility.Visible)
            //{
            //    innerLbl.Visibility = System.Windows.Visibility.Collapsed;
            //    tbViewMore.Text = Application.Current.FindResource("ViewMore").ToString();
            //}
            //else
            //{
            //    innerLbl.Visibility = System.Windows.Visibility.Visible;
            //    tbViewMore.Text = Application.Current.FindResource("ViewLess").ToString();
            //}

        }
    }
}
