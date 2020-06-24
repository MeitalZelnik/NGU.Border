using NGU.Lang;

namespace NGU.App.DTO
{
    public class MessageDialogDTO
    {
        public string Message { get; set; }

        /// <summary>
        /// returns true if messagefinder is a succeffull message
        /// like : 1. SaveSuccessfully 2.  to be continue
        /// 
        /// </summary>
        public bool IsSuccessfull
        {
            get
            {
                return Message == Resources.MSG_SaveSuccessfully;
            }
        }
    }
}
