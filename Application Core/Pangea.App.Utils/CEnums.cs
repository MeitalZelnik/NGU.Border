using Pangea.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangea.App.Utils
{
    public enum ViewModelName
    {
        Exit = -1,
        Login = 0,

        WorkspaceContainer = 9,
        MainMenu = 8,
        Welcome = 7,

        RegistrationModule = 1,
        CardIssuingModule = 2,
        AdministrationModule = 3,
        EnquaryModule = 4,
        PrintFormModule = 5,
        EditDetailsModule = 6,

        Sites = 103,
        ResetUsersPassword = 104,
        UsersLog = 105,

        SystemParameters = 200,
        ErrorLog = 201,

        // Registration
        DataEntry = 11,
        CaptureImages = 12,
        ScanDocuments = 13,
        // Card Issuing
        Print = 21,
        QualityAnsurance = 22,
        Collection = 23,

        // Administrator
        Users = 31,
        Roles = 32,
        Permissions = 33,

        // ENQUIRY
        Filter = 41,

        // Print Form
        COPIES = 51,
        PrintForm = 52,
    }

    public enum Operations
    {
        [ResourceKey("Clean")]
        Clean,
        [ResourceKey("Save")]
        Save,
        [ResourceKey("Add")]
        Add,
        [ResourceKey("Print")]
        Print,
        [ResourceKey("Delete")]
        Delete,
        [ResourceKey("Scan")]
        Scan,
        [ResourceKey("ScanFromPaper")]
        ScanFromPaper,
        [ResourceKey("Next")]
        Next,
        [ResourceKey("Startover")]
        Startover,
        [ResourceKey("Cancel")]
        Cancel,
        [ResourceKey("Finish")]
        Finish,
        [ResourceKey("ExportToExcel")]
        ExportToExcel,
        [ResourceKey("Enroll")]
        Enroll,
        [ResourceKey("Btn_Back")]
        Back,
        [ResourceKey("Btn_CaptureAll")]
        CaptureAll,
        [ResourceKey("Btn_CaptureMulti")]
        CaptureMulti,
        [ResourceKey("New")]
        New,
        [ResourceKey("Terminate")]
        Terminate,
        [ResourceKey("BTN_Submit")]
        Submit
    }

    public enum NotificationMessages
    {
        [ResourceKey("NOTIF_SaveYourChanges")]
        SaveYourChanges,
        [ResourceKey("NOTIF_FixValidationErrors")]
        FixValidationErrors,
        [ResourceKey("NOTIF_SavedSuccessfuly")]
        Saved,
        [ResourceKey("NOTIF_EnterSearchParameters")]
        EnterSearchParameters,
        [ResourceKey("NOTIF_NoDataFound")]
        NoDataFound,
        [ResourceKey("NOTIF_NoPersonFound")]
        NoPersonFound,
        [ResourceKey("NOTIF_SavingData")]
        SavingData,
        [ResourceKey("NOTIF_AppAlreadySaved")]
        AppWasSavedByAnotherUser,
        [ResourceKey("NOTIF_HasOpenApplication")]
        HasOpenApplication,
        [ResourceKey("NOTIF_CheckingFingerprintLicense")]
        CheckingFingerprintLicense,
    }

    public enum NotificationAreaType
    {
        Error,
        Success,
    }
}
