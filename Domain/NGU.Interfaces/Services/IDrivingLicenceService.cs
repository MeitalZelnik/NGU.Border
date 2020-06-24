using MD.App.ePayment.DTO;
using NIP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using NGU.Admin.Core;
using NGU.Admin.Enums;
using System.Collections.ObjectModel;

namespace NGU.Admin.Interfaces.Services
{
    [ServiceContract]
    public interface IDrivingLicenceService : IBaseService
    {
        [OperationContract]
        [UseNetDataContractSerializer]
        void IsAlive();

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //List<ApplicationDTO> GetApplicationsForIssuanceScreen(SearchDTO searchDto);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //List<PersonDTO> GetPersonsForEnquiryScreen(SearchDTO searchDto);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //Person GetPersonByIntref(string intref);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //ApplicationDL GetApplicationByAppNo(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //List<CommentDTO> GetCommentsAndLogsForCertainMenuByAppNo(long appNo, int menuId, string loggedUser, int? parentMenuId);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //bool CheckIfHasUnreadComments(long appNo, int menuId, int? parentMenuId);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //Tuple<List<EnquiryCommentDTO>, List<EnquiryLogDTO>> GetAllCommentsAndLogsForCertainApp(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void Save(ApplicationDL application, List<Comment> commentList = null);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //List<Image> GetImageByImageTypes(long appNo, List<ImageTypes> imageTypes);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //Person GetPersonByPassport(string iDNumber);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //Applicant GetOldApplicant(string intref);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void SaveBiometricsData(IList<Image> imagesToSave, ApplicationStatuses? nextStatus = null);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void UpdateApplicationStatus(long appno, ApplicationStatuses nextStatus,string UpdateUser, string denyReason = null);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //Applicant GetApplicant(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //bool FiveFieldsExistnessCheck(string passportNumber, string surname, string otherNames, Sex sex, DateTime? birthDate);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //Certificate GetCertificateByAppNo(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void SaveCollectionData(long appNo, Certificate certificate, Image collectorSignature, string user, ApplicationStatuses? nextStatus = null);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void SaveQAScreen(long appNo, ApplicationStatuses nextStatus,string user);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void SaveComment(Comment comment);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //bool PersonExistInLocalDBbyIDNumber(string iDNumber);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //License GetRegularLicenceByAppNo(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //Tuple<EnquiryLicenseDTO, List<EnquiryLicenseDTO>> GetLicenceDataForEnquiryLicneseScreenByAppNo(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //ObservableCollection<LicenseTypeToApplication> GetLicenceTypesByAppNo(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //ObservableCollection<Image> GetApplicationImages(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //ObservableCollection<SupportDocToApplication> GetApplicationDocument(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //bool UpdateCommentAsRead(int id, int menuId, long currentAppNo, int parentMenuId);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //Applicant FillApplicantfromCRS(string iDNumber);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //ApplicationDL GetApplicationByAppNoToVerification(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //PersonDTO GetEnquiryCurrentDetails(int intref);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //List<ApplicationDTO> GetApplicationsByIntref(int intref);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //License GetLicenceByIntref(string intref, LicenseStatuses active);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //List<PersonalRestriction> GetPersonalRestriction(long appNo);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void SaveLicence(License licence);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //List<ApplicationDL> GetOpenApplicationsByIntref(string intref);
        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void DenyApp(long appNo,string user,string reason);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void SavePermissions(List<int> permittedMenuIds, List<int> unpermittedMenuIds, string roleName);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void SaveUser(User selectedUser);

        //[OperationContract]
        //[UseNetDataContractSerializer]
        //void UpdateSupDocToAppTypes(List<SupDocToAppType> updated, List<SupDocToAppType> added, List<SupDocToAppType> deleted, string userName);
    }
}
