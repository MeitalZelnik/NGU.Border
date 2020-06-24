using NGU.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.App.DTO
{
    public class CommentDTO : DTOBase
    {
        public int ID { get; set; }

        public long AppNo { get; set; }

        public CommentDtoTypes CommentDtoType { get; set; }

        public int OriginMenu { get; set; }

        public Dictionary<int, bool> AssignedMenus { get; set; }

        public string CommentDesc { get; set; }

        public string CommentUser { get; set; }

        public DateTime? CommentDate { get; set; }

        //readonly props
        public bool IsLogType
        {
            get
            {
                if (CommentDtoType != CommentDtoTypes.Comment)
                    return true;

                return false;
            }
        }

        public bool IsSupervisorApprovalType
        {
            get
            {
                if (CommentDtoType == CommentDtoTypes.SupervisorApproval)
                    return true;

                return false;
            }
        }

        public bool IsCommentUserTheCurrentUser { get; set; }





        //------

        public int? CurrentMenuId { get; set; }

        public int? CurrentParentMenuId { get; set; }

        public bool HasUnreadMessageOnCurrentMenu
        {
            get
            {
                if (!CurrentMenuId.HasValue)
                    return false;

                if (AssignedMenus == null || AssignedMenus.Count == 0)
                    return false;

                if (CurrentParentMenuId.HasValue)
                    return AssignedMenus.Any(x => !x.Value && (x.Key == CurrentMenuId.Value || x.Key == CurrentParentMenuId.Value));

                return AssignedMenus.Any(x => !x.Value && x.Key == CurrentMenuId.Value);
            }
        }
    }
}
