using Pangea.Extensions;
using System.Runtime.Serialization;

namespace NGU.Enums
{
    public enum SystemSettingsKeys
    {
        VERSION_NO_BLACKLIST,
        MAX_SEARCH_RESULTS,
        DEFAULT_LANG_BLACKLIST,
        DEFAULT_LANG_IDENTITY,
        VERSION_NO_IDENTITY
    }

    public enum ScreenType
    {
        Login,
        ChangePassword,
    }

    public enum ViewModelTypes
    {
        Workspace = 100,

        Login = -12,
        Logout = -11,
        MainFlowContainer = -7,
        Exit = -3,
        Back = -2,
        MainMenu = -1,
        MainModule = -4,
        ChangePassword = -6,

        MenuBlackList = 2,



        [ResourceKey("MenuDataEntryMenuImage")]
        ContainerDataEntry = 21,
        DataEntry = 211,
        DataEntryReg = 999,

        [ResourceKey("MenuDecisionMakingMenuImage")]
        ContainerDecisionMaking = 22,
        DecisionMaking = 221,

        [ResourceKey("MenuEnquiryMenuImage")]
        ContainerEnquiries = 23,
        Enquiries = 231
    }

    public enum StatusBarMessageTypes
    {
        FadeMessage = 1,
        RegularMessage = 2
    }

    //public enum DialogButtons
    //{
    //    [ResourceKey("Save")]
    //    Save,

    //    [ResourceKey("BTN_Ok")]
    //    OK,

    //    [ResourceKey("BTN_Cancel")]
    //    Cancel,

    //    [ResourceKey("BTN_Yes")]
    //    Yes,

    //    [ResourceKey("BTN_No")]
    //    No,

    //    [ResourceKey("BTN_ClearData")]
    //    ClearData,

    //    [ResourceKey("BTN_Relogin")]
    //    Relogin,
    //}

    public enum YesNo
    {
        [StringValue("Y")]
        Yes,
        [StringValue("N")]
        No
    }

    public enum ImageTypes
    {
        None = 0,

        [StringValue("IDF1")]
        RightThumb = 1,

        [StringValue("IDF2")]
        RightIndex = 2,

        [StringValue("IDF3")]
        RightMiddle = 3,

        [StringValue("IDF4")]
        RightRing = 4,

        [StringValue("IDF5")]
        RightLittle = 5,

        [StringValue("IDF6")]
        LeftThumb = 6,

        [StringValue("IDF7")]
        LeftIndex = 7,

        [StringValue("IDF8")]
        LeftMiddle = 8,

        [StringValue("IDF9")]
        LeftRing = 9,

        [StringValue("IDF10")]
        LeftLittle = 10,

        [StringValue("IDP")]
        Photo = 11,

        [StringValue("IDS")]
        Signature = 12,
    }

    public enum UserStatuses
    {
        Active = 1,
        Passive = 2
    }

    public enum VersionDownloadStates
    {
        BeforeDownloading,
        Downloading,
        DownloadSucceed,
        DownloadFailed
    }

    //public enum UserValidationTypes
    //{
    //    Faild = 0,
    //    UserNotFound = 1,
    //    PasswordIncorrect = 2,
    //    UserNotActive = 3,
    //    UserLoggedToManyTimes = 4,
    //    NewAndOldPasswordMatch = 5,
    //    Success = 6
    //}

    //public enum UserLoginResultTypes
    //{
    //    Success = 0,
    //    Faild = 1,
    //    ChangePasswordRequired = 2
    //}

    public enum RequestStatuses
    {
        [StringValue("0")]
        Empty = 0,

        [StringValue("80101")]
        Open = 1,

        [StringValue("80102")]
        SentForProcessing = 2,

        [StringValue("80103")]
        Investigation = 3,

        [StringValue("80104")]
        Completed = 4,

        [StringValue("80105")]
        Rejected = 5,

        [StringValue("80106")]
        Terminated = 6
    }

    public enum BlackListStatusTypes
    {
        [StringValue("60501")]
        Active = 1,

        [StringValue("60502")]
        Cancelled = 2,

        [StringValue("60503")]
        Removed = 3,

        [StringValue("60504")]
        Expired = 4
    }

    public enum RequestTypes
    {
        [StringValue("1")]
        Registration = 1,

        [StringValue("2")]
        Search = 2,
    }

    public enum RequestSubTypes
    {
        [StringValue("1")]
        NewPerson = 1,

        [StringValue("2")]
        UpdatePerson = 2,
    }

    public enum DecisionTypes
    {
        Approve = 1,
        Reject = 2,
        Close = 3
    }

    public enum MenuStatusTypes
    {
        Empty,
        OK,
        Error,
        NotValid,
        Saved,
        Visited
    }

    public enum ModuleContextTypes
    {
        Applicant,
        Application,
        CommentsList,
    }

    public enum CommentTypes
    {
        Comments = 1,
        Log = 2,
        Both = 3,
    }

    [DataContract(Name = "CommentDtoTypes")]
    public enum CommentDtoTypes
    {
        [EnumMember]
        Comment = 1,

        [EnumMember]
        Log = 2,

        [EnumMember]
        SupervisorApproval = 3,
    }

    public enum SearchUserControlMode
    {
        DataEntry = 1,
        DecisionMaking = 2,
        Enquiries = 3
    }

    public enum IdenTypes
    {
        Passport = 1,
        IdentityCard = 2,
        BirthCertificate = 3,
        Company = 4,
        ResidentCard = 5,
        RefugeeCard = 6,
        Visa = 7,
        LaissezPasser = 8,
        Others = 9,
        InternalNo = 10
    }

    public enum FPPosition
    {
        Unknown = 0,
        RightThumb = 1,
        RightIndexFinger = 2,
        RightMiddleFinger = 3,
        RightRingFinger = 4,
        RightLittleFinger = 5,
        LeftThumb = 6,
        LeftIndexFinger = 7,
        LeftMiddleFinger = 8,
        LeftRingFinger = 9,
        LeftLittleFinger = 10
    }
}
