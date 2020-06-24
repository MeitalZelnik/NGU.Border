using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using Pangea.Client.WPF.CustomControls;
using NGU.Common.Utilities;
using Pangea.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Pangea.BaseStructures;

namespace NGU.Admin.App.Client.ViewModels
{
    public class CommentsViewModel : BaseViewModel
    {
        #region ctor

        public CommentsViewModel(int menuId, int? parentId, long appNo)
        {
            //ProcessHelper.RunMethodOnDifferentTask(() =>
            //{
            //    allFoundCommentsFromDb = null; // DrivingLicenceService.GetCommentsAndLogsForCertainMenuByAppNo(appNo, menuId, LoggedUser.Username, parentId);

            //    currentMenuId = menuId;
            //    currentMenuParentId = parentId.HasValue ? parentId.Value : 0;
            //    currentAppNo = appNo;

            //    CommentListToSave = new List<Comment>();
            //    Comments = new ObservableCollection<CommentDTO>();
            //    CommentType = CommentTypes.Comments;

            //    WasInitialzed = true;
            //});

            //ProcessHelper.RunMethodOnDifferentTask(() =>
            //{
            //    while (allFoundCommentsFromDb == null)
            //    {
            //        if (!_isDisposed)
            //            break;

            //        Thread.Sleep(500);
            //    }
              

            //    int moduleId = (int)ViewModelTypes.Issuance;
            //    var res = LoggedUser.Menus.Where(x => x.MenuId == moduleId).SingleOrDefault().SubMenus.Where(x => x.MenuId != currentMenuId && x.MenuId != currentMenuParentId);

            //    switch ((ViewModelTypes)moduleId)
            //    {
            //        case ViewModelTypes.Issuance:
            //            AllScreens = res.Where(x => x.MenuId != (int)ViewModelTypes.RegistraionContainer).ToList();
            //            break;
            //        case ViewModelTypes.CancellationSuspension:
            //            //TODO: filter first stage of the process
            //            break;
            //        case ViewModelTypes.SchoolsExaminers:
            //            //TODO: filter first stage of the process
            //            break;
            //    }
            //});
        }

        #endregion

        #region members

        CommentTypes? _commentType;
        private ObservableCollection<CommentDTO> _comments;
        private List<Menu> _allScreens;
        private List<Menu> _selectedScreens = new List<Menu>();
        private string _commentDesc;
        private ICommand _saveCommentCommand;

        private long currentAppNo;
        private int currentMenuId;
        private int currentMenuParentId;
        private CommentDTO _selectedComment;
        private List<CommentDTO> allFoundCommentsFromDb;
        private string _commentMsgFailLbl;
        private string _commentMsgSuccessLbl;
        private bool _wasInitialzed = false;
        private bool _isDisposed = true;

        #endregion

        #region props

        public bool IsPinned
        {
            get
            {
                return BaseContainerViewModel.IsCommentsPinned;
            }
            set
            {
                BaseContainerViewModel.IsCommentsPinned = value;
            }
        }

        public CommentTypes? CommentType
        {
            get
            {
                return _commentType;
            }
            set
            {
                _commentType = value;

                if (_commentType.HasValue && allFoundCommentsFromDb != null && allFoundCommentsFromDb.Count > 0)
                {
                    switch (_commentType.Value)
                    {
                        case CommentTypes.Comments:
                            var filteredA = allFoundCommentsFromDb.Where(x => (int)x.CommentDtoType == (int)CommentTypes.Comments);
                            Comments = new ObservableCollection<CommentDTO>(filteredA);
                            break;
                        case CommentTypes.Log:
                            var filteredB = allFoundCommentsFromDb.Where(x => (int)x.CommentDtoType == (int)CommentTypes.Log);
                            Comments = new ObservableCollection<CommentDTO>(filteredB);
                            break;
                        case CommentTypes.Both:
                            Comments = new ObservableCollection<CommentDTO>(allFoundCommentsFromDb);
                            break;
                    }
                }

                NotifyPropertyChanged(() => CommentType);
            }
        }

        public ObservableCollection<CommentDTO> Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                _comments = value;
                NotifyPropertyChanged(() => Comments);
            }
        }

        public List<Menu> AllScreens
        {
            get
            {
                return _allScreens;
            }
            set
            {
                _allScreens = value;
                NotifyPropertyChanged(() => AllScreens);
            }
        }

        public string CommentDesc
        {
            get
            {
                return _commentDesc;
            }
            set
            {
                _commentDesc = value;
                NotifyPropertyChanged(() => CommentDesc);
            }
        }

        public List<Menu> SelectedScreens
        {
            get
            {
                return _selectedScreens;
            }
            set
            {
                _selectedScreens = value;

                NotifyPropertyChanged(() => SelectedScreens);
            }
        }

        //public List<Comment> CommentListToSave { get; set; }

        public CommentDTO SelectedComment
        {
            get
            {
                return _selectedComment;
            }
            set
            {
                if (_selectedComment == value)
                    return;

                _selectedComment = value;

                if (_selectedComment != null && _selectedComment.CommentDtoType == CommentDtoTypes.Comment)
                {
                    var found = _selectedComment.AssignedMenus.FirstOrDefault(x => x.Key == currentMenuId || x.Key == currentMenuParentId);
                    if (found.Key != 0 && found.Value == false)
                    {
                        //save to db
                        bool foundUnReadCommentsForApp = true;// DrivingLicenceService.UpdateCommentAsRead(_selectedComment.ID, currentMenuId, currentAppNo, currentMenuParentId);
                        if (!foundUnReadCommentsForApp)
                            OnNotifyContainer("AllCommentsAreRead");

                        //refresh screen
                        var itemToRefresh = _selectedComment.AssignedMenus.FirstOrDefault(x => x.Key == currentMenuId || x.Key == currentMenuParentId);

                        if (itemToRefresh.Key>0)
                        {
                            _selectedComment.AssignedMenus.Remove(itemToRefresh.Key);
                            _selectedComment.AssignedMenus.Add(found.Key, true);
                        }

                        List<CommentDTO> commentsCloned = new List<CommentDTO>(Comments);
                        Comments = new ObservableCollection<CommentDTO>();
                        foreach (var item in commentsCloned)
                        {
                            Comments.Add(item);
                        }
                    }
                }

                NotifyPropertyChanged(() => SelectedComment);
            }
        }

        public string CommentMsgSuccessLbl
        {
            get
            {
                return _commentMsgSuccessLbl;
            }
            set
            {
                _commentMsgSuccessLbl = value;
                NotifyPropertyChanged(() => CommentMsgSuccessLbl);
            }
        }

        public string CommentMsgFailLbl
        {
            get
            {
                return _commentMsgFailLbl;
            }
            set
            {
                _commentMsgFailLbl = value;
                NotifyPropertyChanged(() => CommentMsgFailLbl);
            }
        }

        public bool WasInitialzed
        {
            get
            {
                return _wasInitialzed;
            }
            set
            {
                _wasInitialzed = value;
                NotifyPropertyChanged(() => WasInitialzed);
            }
        }

        #endregion

        #region commands

        public ICommand SaveCommentCommand
        {
            get
            {
                if (_saveCommentCommand == null)
                    _saveCommentCommand = new RelayCommand(SaveCommentExecute);

                return _saveCommentCommand;
            }
        }

        #endregion

        #region methods

        private void SaveCommentExecute(object param)
        {
            if (SelectedScreens.Count == 0 || CommentDesc.IsNullOrEmpty())
            {
                CommentMsgFailLbl = System.Windows.Application.Current.Resources["CommentSavedFailed"].ToString();
                return;
            }

            //Comment comment = new Comment()
            //{
            //    AppNo = currentAppNo,
            //    //ID = ???
            //    UpdateDate = DateTime.Now,
            //    CreatedBy = LoggedUser.Username,
            //    CommentDesc = CommentDesc,
            //    OriginMenu = new Menu() { MenuId = currentMenuId },
            //};

            //foreach (var selectedScreen in SelectedScreens)
            //{
            //    CommentToMenu commentToMenu = new CommentToMenu()
            //    {
            //        Comment = comment,
            //        Menu = selectedScreen,
            //        IsRead = YesNo.No.GetCharValue()
            //    };

            //    comment.CommentToMenu.Add(commentToMenu);
            //}


            //if (currentMenuId == (int)ViewModelTypes.RegistraionContainer)
            //{
            //    //save im memory for future usage in registrationScreen.Save
            //    if (BaseContainerViewModel.CommentListToSave == null)
            //        BaseContainerViewModel.CommentListToSave = new List<Comment>();

            //    BaseContainerViewModel.CommentListToSave.Add(comment);
            //}
            //else
            //{
            //    //save to server immidiatly
            //    //DrivingLicenceService.SaveComment(comment);
            //}

            SelectedScreens = new List<Menu>();
            CommentDesc = null;


            CommentMsgSuccessLbl = System.Windows.Application.Current.Resources["CommentSavedSuccess"].ToString();
        }

        #endregion

        #region override methods

        public override void OnDispose()
        {
            _isDisposed = true;

            base.Dispose();
        }

        #endregion
    }
}
