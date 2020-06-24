using MD.App.ePayment.DTO;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Admin.App.Client.ViewModels
{
    public class EnquiryCommentAndLogViewModel : BaseViewModel
    {
        #region ctor

        public EnquiryCommentAndLogViewModel()
        {
            CommentType = CommentTypes.Comments;

            //ProcessHelper.RunMethodOnDifferentTask(() =>
            //{
                long appNo = BaseContainerViewModel.EquiryApplicationAppNo;
            //});
        }

        #endregion

        #region members

        private CommentTypes _commentType;
        private ObservableCollection<EnquiryCommentDTO> _comments;
        private ObservableCollection<EnquiryLogDTO> _logs;

        #endregion

        #region props

        public CommentTypes CommentType
        {
            get
            {
                return _commentType;
            }
            set
            {
                _commentType = value;


                if (_commentType == CommentTypes.Comments)
                {
                }
                if (_commentType == CommentTypes.Log)
                {
                }

                NotifyPropertyChanged(() => CommentType);
            }
        }

        public ObservableCollection<EnquiryCommentDTO> Comments
        {
            get
            {
                if (_comments == null)
                    _comments = new ObservableCollection<EnquiryCommentDTO>();

                return _comments;
            }
            set
            {
                _comments = value;
                NotifyPropertyChanged(() => Comments);
            }
        }

        public ObservableCollection<EnquiryLogDTO> Logs
        {
            get
            {
                if (_logs == null)
                    _logs = new ObservableCollection<EnquiryLogDTO>();

                return _logs;
            }
            set
            {
                _logs = value;
                NotifyPropertyChanged(() => Logs);
            }
        }

        #endregion
    }
}
