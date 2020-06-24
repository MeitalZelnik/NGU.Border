using NGU.Admin.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGU.Admin.Interfaces;
using MD.App.ePayment.DTO;
using NIP.IoCLib;
using NGU.Admin.Interfaces.Repositories;
using NIP.UnitOfWork;
using NGU.Admin.Core;
using NHibernate;
using NGU.Admin.Enums;
using System.Collections.ObjectModel;
using NIP.Helpers.Base;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using NGU.Admin.Core.Classes;
using System.Globalization;
using System.Configuration;
using NIP.Helpers;
using NIP.Common.Utilities;

namespace NGU.Admin.Services
{
    public class DrivingLicenceService : BaseService, IDrivingLicenceService
    {
        public DrivingLicenceService()
            : base()
        {
        }

        #region props

        private IDrivingLicenceRepository _drivingLicenceRepository;
        public IDrivingLicenceRepository DrivingLicenceRepository
        {
            get
            {
                if (_drivingLicenceRepository == null)
                    _drivingLicenceRepository = IoC.Resolve<IDrivingLicenceRepository>();
                return _drivingLicenceRepository;
            }
        }

        private IValueObjectRepository _valueObjectRepository;
        public IValueObjectRepository ValueObjectRepository
        {
            get
            {
                if (_valueObjectRepository == null)
                    _valueObjectRepository = IoC.Resolve<IValueObjectRepository>();
                return _valueObjectRepository;
            }
        }

        private ISystemService _systemService;

        public ISystemService SystemService
        {
            get
            {
                if (_systemService == null)
                    _systemService = IoC.Resolve<ISystemService>();
                return _systemService;
            }
        }


        #endregion

        public void IsAlive()
        {
        }

        //public Applicant FillApplicantfromCRS(string iDNumber)
        //{
        //    List<Sex> genders = null;
        //    List<Nationality> nationalities = null;
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        genders = ValueObjectRepository.FindAll<Sex>().ToList();
        //        nationalities = ValueObjectRepository.FindAll<Nationality>().ToList();
        //    }

        //    Applicant applicant = new Applicant();
        //    GenericApplicant _genericApplicant = new GenericApplicant();
        //    string result = "";
        //    string webServiceLink = null;

        //    webServiceLink = ConfigurationManager.AppSettings["CrsIP"] + "/apiService.svc/GetPersonByID?key=" + ConfigurationManager.AppSettings["UserKey"] + "&idNumber=" + iDNumber;


        //    HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(webServiceLink);
        //    myRequest.Method = "GET";
        //    using (StreamReader responseReader = new StreamReader(myRequest.GetResponse().GetResponseStream()))
        //    {
        //        result = responseReader.ReadToEnd();
        //    }

        //    string s = JsonConvert.DeserializeObject<string>(result);
        //    _genericApplicant = JsonConvert.DeserializeObject<GenericApplicant>(s);
        //    if (_genericApplicant.Status == "Person Not Found")
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        if (_genericApplicant.Status == "Deceased")
        //        {
        //            applicant.Status = ApplicantStatuses.Deceased;
        //        }
        //        else if (_genericApplicant.Status == "Active")
        //        {
        //            applicant.Status = ApplicantStatuses.Active;
        //        }

        //        try
        //        {
        //            applicant.IDNumber = _genericApplicant.IDNumber;
        //            applicant.Surname = _genericApplicant.Surname;
        //            applicant.OtherNames = _genericApplicant.FirstName;
        //            applicant.Nationality = nationalities.FirstOrDefault(x => x.ID == _genericApplicant.NationalityCode);
        //            applicant.IdCollected = YesNoHelper.ConvertLetterToBool(_genericApplicant.IdCollected);
        //            applicant.Sex = genders.FirstOrDefault(x => x.ID == _genericApplicant.Gender);
        //            CultureInfo provider = CultureInfo.InvariantCulture;
        //            applicant.BirthDate = DateTime.ParseExact(_genericApplicant.BirthDate, "dd/MM/yyyy", provider);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("check that :" + ConfigurationManager.AppSettings["UserKey"] + "has all custom datas in crs");
        //        }
        //    }
        //    return applicant;
        //}

        //public List<ApplicationDTO> GetApplicationsForIssuanceScreen(SearchDTO searchDto)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        var res = DrivingLicenceRepository.GetApplicationsForIssuanceScreen(searchDto);

        //        if (res != null)
        //        {
        //            foreach (var item in res)
        //            {
        //                Unproxy<ApplicationDTO>.UnproxyObject(item).Include(x => x.ApplicationType)
        //                                                           .Include(u => u.CurrentStatus)
        //                                                           .Include(u => u.NextAction)
        //                                                           .Include(u => u.Sex)
        //                                                           .Execute();
        //            }
        //        }

        //        return res;
        //    }
        //}

        //public List<PersonDTO> GetPersonsForEnquiryScreen(SearchDTO searchDto)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        var res = DrivingLicenceRepository.GetPersonsForEnquiryScreen(searchDto);

        //        if (res != null)
        //        {
        //            foreach (var item in res)
        //            {
        //                Unproxy<PersonDTO>.UnproxyObject(item).Include(u => u.Sex)
        //                                                      .Execute();
        //            }
        //        }

        //        return res;
        //    }
        //}

        //public Person GetPersonByIntref(string intref)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        var res = DrivingLicenceRepository.Get<Person>(intref);
        //        Unproxy<Person>.UnproxyObject(res).Include(u => u.Sex)
        //            .Include(u => u.Nationality).Execute();

        //        return res;
        //    }
        //}

        //public Person GetPersonByPassport(string iDNumber)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        var res = DrivingLicenceRepository.FindAll<Person>().Where(x => x.Passport == iDNumber).FirstOrDefault();

        //        return res;
        //    }
        //}

        //public ApplicationDL GetApplicationByAppNo(long appNo)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        ApplicationDL res = DrivingLicenceRepository.Get<ApplicationDL>(appNo);

        //        Unproxy<ApplicationDL>.UnproxyObject(res).Include(x => x.ApplicationType)
        //                                                 .Include(x => x.ApplicationStatus)
        //                                                 .Include(x => x.Applicant)
        //                                                 .Include(x => x.Licenses)
        //                                                 .Execute();

        //        return res;
        //    }
        //}

        //public ApplicationDL GetApplicationByAppNoToVerification(long appNo)
        //{
        //    ApplicationDL res = null;
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        res = DrivingLicenceRepository.Get<ApplicationDL>(appNo);

        //        Unproxy<ApplicationDL>.UnproxyObject(res).Include(x => x.ApplicationType)
        //            .Include(x => x.ApplicationStatus)
        //            .Include(x => x.PersonalRestrictions)
        //            .Include(x => x.LicenseTypes)
        //            .Include(x => x.Applicant)
        //            .Include(x => x.Comments)
        //            .Include(x => x.SupportedDocs)
        //            .Include(x => x.ApplicationType.SupDocToAppTypes)
        //            .Execute();

        //        Unproxy<Applicant>.UnproxyObject(res.Applicant).
        //            Include(x => x.DocType)
        //            .Include(u => u.Sex)
        //            .Include(u => u.Nationality)
        //                         .Execute();

        //        //List<Image> images = DrivingLicenceRepository.FindAll<Image>().Where(x => x.AppNo == appNo ).ToList();
        //        //res.Images = images;

        //    }

        //    res.UpdatedLicense = DrivingLicenceRepository.GetLicenceByIntref(res.IntrefNo, LicenseStatuses.InProgress);
        //    res.OldApplicant = GetOldApplicant(res.IntrefNo);
        //    res.OldApplicationLicenseTypes = GetLicenceTypesByAppNo(res.OldApplicant.AppNo);//to patial application
        //    res.Images = GetApplicationImages(res.AppNo);

        //    return res;
        //}

        //public List<CommentDTO> GetCommentsAndLogsForCertainMenuByAppNo(long appNo, int menuId, string loggedUser, int? parentMenuId)
        //{
        //    List<Comment> foundComments = new List<Comment>();
        //    List<ApplicationTracing> foundApplicationTracings = new List<ApplicationTracing>();
        //    List<SupervisorApproval> foundSupervisorApprovals = new List<SupervisorApproval>();

        //    List<CommentDTO> commentDTOList = new List<CommentDTO>();
        //    CommentDTO commentDTO;

        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        #region comments

        //        var res = DrivingLicenceRepository.Get<ApplicationDL>(appNo);

        //        if (res != null)
        //        {
        //            IEnumerable<Comment> query;
        //            if (parentMenuId.HasValue)
        //            {
        //                query = res.Comments.Where(comment => comment.CommentToMenu.Any(x => x.Menu.MenuId == menuId || x.Menu.MenuId == parentMenuId.Value));
        //            }
        //            else
        //            {
        //                query = res.Comments.Where(comment => comment.CommentToMenu.Any(x => x.Menu.MenuId == menuId));
        //            }


        //            foundComments = query.ToList<Comment>();
        //            //foundComments = res.Comments.Where(comment => comment.CommentToMenu.Any(x => x.Menu.MenuId == menuId)).ToList<Comment>();

        //            //DO NOT CHNAGE ORDER OF unproxy!
        //            Unproxy<Comment>.UnproxyCollection(foundComments).IncludeAll().Execute();

        //            foreach (var item in foundComments)
        //            {
        //                //DO NOT CHNAGE ORDER OF unproxy!
        //                Unproxy<CommentToMenu>.UnproxyCollection(item.CommentToMenu).IncludeAll().Execute();
        //            }
        //        }

        //        #endregion

        //        #region logs

        //        foundApplicationTracings = DrivingLicenceRepository.FindAll<ApplicationTracing>().Where(x => x.AppNo == appNo).ToList();
        //        foundSupervisorApprovals = DrivingLicenceRepository.FindAll<SupervisorApproval>().Where(x => x.AppNo == appNo).ToList();

        //        #endregion

        //        List<ApplicationStatus> allAppStatuses = ValueObjectRepository.FindAll<ApplicationStatus>().ToList();

        //        foreach (var item in foundComments)
        //        {
        //            Dictionary<int, bool> assignMenus = new Dictionary<int, bool>();
        //            foreach (var commentToMenu in item.CommentToMenu)
        //            {
        //                bool isread = commentToMenu.IsRead == YesNo.Yes.GetCharValue() ? true : false;
        //                assignMenus.Add(commentToMenu.Menu.MenuId, isread);
        //            }

        //            commentDTO = new CommentDTO()
        //            {
        //                ID = item.ID,
        //                AppNo = item.AppNo,
        //                CommentDtoType = CommentDtoTypes.Comment,
        //                OriginMenu = item.OriginMenu.MenuId,
        //                AssignedMenus = assignMenus,
        //                CommentDate = item.UpdateDate,
        //                CommentUser = item.CreatedBy,
        //                CommentDesc = item.CommentDesc,
        //                CurrentMenuId = menuId,
        //                CurrentParentMenuId = parentMenuId
        //            };

        //            commentDTOList.Add(commentDTO);
        //        }

        //        foreach (var item in foundApplicationTracings)
        //        {
        //            commentDTO = new CommentDTO()
        //            {
        //                ID = item.ID,
        //                AppNo = item.AppNo,
        //                CommentDtoType = CommentDtoTypes.Log,
        //                AssignedMenus = null,
        //                CommentDate = item.LastUpdate,
        //                CommentUser = item.UserUpdate,
        //                CommentDesc = allAppStatuses.FirstOrDefault(x => x.ID == item.NewStatus).Description,
        //                CurrentMenuId = menuId,
        //                CurrentParentMenuId = parentMenuId
        //            };

        //            commentDTOList.Add(commentDTO);
        //        }

        //        foreach (var item in foundSupervisorApprovals)
        //        {
        //            commentDTO = new CommentDTO()
        //            {
        //                ID = item.ID,
        //                AppNo = item.AppNo,
        //                CommentDtoType = CommentDtoTypes.SupervisorApproval,
        //                AssignedMenus = null,
        //                CommentDate = item.LastUpdate,
        //                CommentUser = item.Supervisor,
        //                CommentDesc = item.Approval.Description,
        //            };

        //            commentDTOList.Add(commentDTO);
        //        }
        //    }

        //    foreach (var item in commentDTOList)
        //    {
        //        item.IsCommentUserTheCurrentUser = item.CommentUser == loggedUser;
        //    }

        //    return commentDTOList.OrderBy(x => x.CommentDate).ToList();
        //}

        //public bool CheckIfHasUnreadComments(long appNo, int menuId, int? parentMenuId)
        //{
        //    return DrivingLicenceRepository.CheckIfHasUnreadComments(appNo, menuId, parentMenuId);
        //}

        //public Tuple<List<EnquiryCommentDTO>, List<EnquiryLogDTO>> GetAllCommentsAndLogsForCertainApp(long appNo)
        //{
        //    List<Comment> foundComments = new List<Comment>();
        //    List<ApplicationTracing> foundApplicationTracings = new List<ApplicationTracing>();
        //    List<SupervisorApproval> foundSupervisorApprovals = new List<SupervisorApproval>();

        //    List<EnquiryCommentDTO> commentDTOList = new List<EnquiryCommentDTO>();
        //    EnquiryCommentDTO commentDTO;
        //    List<EnquiryLogDTO> logDTOList = new List<EnquiryLogDTO>();
        //    EnquiryLogDTO logDTO;

        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        #region comments

        //        foundComments = DrivingLicenceRepository.GetAllCommentsForCertainApp(appNo);

        //        //DO NOT CHNAGE ORDER OF unproxy!
        //        Unproxy<Comment>.UnproxyCollection(foundComments).IncludeAll().Execute();

        //        foreach (var item in foundComments)
        //        {
        //            //DO NOT CHNAGE ORDER OF unproxy!
        //            Unproxy<CommentToMenu>.UnproxyCollection(item.CommentToMenu).IncludeAll().Execute();
        //        }

        //        #endregion

        //        #region logs

        //        foundApplicationTracings = DrivingLicenceRepository.FindAll<ApplicationTracing>().Where(x => x.AppNo == appNo).ToList();
        //        foundSupervisorApprovals = DrivingLicenceRepository.FindAll<SupervisorApproval>().Where(x => x.AppNo == appNo).ToList();

        //        #endregion

        //        foreach (var foundComment in foundComments)
        //        {
        //            foreach (var item in foundComment.CommentToMenu)
        //            {
        //                commentDTO = new EnquiryCommentDTO()
        //                {
        //                    CommentDate = foundComment.UpdateDate,
        //                    CommentDesc = foundComment.CommentDesc,
        //                    CommentUser = foundComment.CreatedBy,
        //                    IsRead = item.IsRead == YesNo.Yes.GetCharValue() ? true : false,
        //                    FromScreen = foundComment.OriginMenu.Description,
        //                    ToScreen = item.Menu.Description
        //                };

        //                commentDTOList.Add(commentDTO);
        //            }
        //        }

        //        var allStatuses = ValueObjectRepository.FindAll<ApplicationStatus>().ToList();

        //        foreach (var item in foundApplicationTracings)
        //        {
        //            logDTO = new EnquiryLogDTO()
        //            {
        //                Date = item.LastUpdate,
        //                Operation = allStatuses.FirstOrDefault(x => x.ID == item.NewStatus).Description,
        //                Remarks = "todo...",
        //                User = item.UserUpdate,
        //            };

        //            logDTOList.Add(logDTO);
        //        }

        //        foreach (var item in foundSupervisorApprovals)
        //        {
        //            logDTO = new EnquiryLogDTO()
        //            {
        //                Date = item.LastUpdate,
        //                Operation = "Supervisor approval: " + item.Approval.Description,
        //                Remarks = "todo...",
        //                User = item.Supervisor,
        //            };

        //            logDTOList.Add(logDTO);
        //        }
        //    }

        //    Tuple<List<EnquiryCommentDTO>, List<EnquiryLogDTO>> t = new Tuple<List<EnquiryCommentDTO>, List<EnquiryLogDTO>>(commentDTOList, logDTOList);
        //    return t;
        //}

        //public void DenyApp(long appNo, string user, string reason)
        //{
        //    UpdateApplicationStatus(appNo, ApplicationStatuses.Denied, user, reason);

        //}

        //public void Save(ApplicationDL application, List<Comment> commentList = null)
        //{
        //    Person person = null;
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            person = SavePrson(application.Applicant);
        //            SaveApplicantAndApplication(application, person.Intref);
        //            SaveApplicationTracing(application);
        //            SaveSupportingDocuments(application);
        //            SavePersonalRestriction(application);

        //            ////when comming from verification no need to update the license
        //            if (application.ApplicationStatus.ID == (int)ApplicationStatuses.Registered)
        //            {
        //                SaveLicence(application);
        //            }
        //            else
        //            {
        //                UpdateLicence(application);

        //            }
        //            if (commentList != null && commentList.Count > 0)
        //            {
        //                foreach (var comment in commentList)
        //                {
        //                    comment.AppNo = application.AppNo;
        //                    SaveCommentToDb(comment);
        //                }
        //            }
        //        });
        //    }
        //}

        //private void UpdateLicence(ApplicationDL application)
        //{
        //    License licence = DrivingLicenceRepository.GetLicenceByIntref(application.IntrefNo, LicenseStatuses.InProgress);
        //    licence.LicenseStatus = application.UpdatedLicense.LicenseStatus;
        //    DrivingLicenceRepository.SaveOrUpdate<License>(licence);
        //}

        //public ObservableCollection<Image> GetApplicationImages(long appNo)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        var res = DrivingLicenceRepository.FindAll<Image>().Where(x => x.AppNo == appNo);
        //        return new ObservableCollection<Image>(res);
        //    }
        //}

        //public List<Image> GetImageByImageTypes(long appNo, List<ImageTypes> imageTypes)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        var res = DrivingLicenceRepository.GetImageByImageTypes(appNo, imageTypes);

        //        return res;
        //    }
        //}

        //public Applicant GetOldApplicant(string intref)
        //{
        //    ApplicationDL latestApp;
        //    // Applicant app = null;
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        List<ApplicationDL> applications = DrivingLicenceRepository.FindAll<ApplicationDL>().Where(x => x.IntrefNo == intref).ToList();
        //        DateTime? maxDate = applications.Max(c => c.ApplicationDate);
        //        latestApp = applications.Where(x => x.ApplicationDate == maxDate).FirstOrDefault();
        //        // app = DrivingLicenceRepository.Get<Applicant>(latestApp.AppNo);

        //        Unproxy<Applicant>.UnproxyObject(latestApp.Applicant).Include(x => x.DocType)
        //                                            .Include(u => u.Sex)
        //                                            .Include(u => u.Nationality)
        //                                            .Execute();
        //    }
        //    return latestApp.Applicant;
        //}

        //public void SaveBiometricsData(IList<Image> imagesToSave, ApplicationStatuses? nextStatus = null)
        //{
        //    if (imagesToSave.Count == 0)
        //        return;

        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            foreach (var image in imagesToSave)
        //            {
        //                DrivingLicenceRepository.SaveOrUpdate<Image>(image);
        //            }

        //            if (nextStatus.HasValue)
        //            {
        //                UpdateApplication(imagesToSave.FirstOrDefault().AppNo, nextStatus.Value, imagesToSave[0].CaptureUser);
        //            }

        //        });
        //    }
        //}

        //public void UpdateApplicationStatus(long appno, ApplicationStatuses nextStatus, string updateUser, string denyReason)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            UpdateApplication(appno, nextStatus, updateUser, denyReason);
        //        });
        //    }
        //}

        //public ObservableCollection<LicenseTypeToApplication> GetLicenceTypesByAppNo(long appNo)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        List<LicenseTypeToApplication> res = DrivingLicenceRepository.FindAll<LicenseTypeToApplication>().Where(x => x.Application.AppNo == appNo).ToList();
        //        return new ObservableCollection<LicenseTypeToApplication>(res);
        //    }
        //}

        //public ObservableCollection<SupportDocToApplication> GetApplicationDocument(long appNo)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        var res = DrivingLicenceRepository.FindAll<SupportDocToApplication>().Where(x => x.Application.AppNo == appNo).ToList();

        //        return new ObservableCollection<SupportDocToApplication>(res);
        //    }
        //}

        //public Applicant GetApplicant(long appNo)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        var res = DrivingLicenceRepository.Get<Applicant>(appNo);

        //        Unproxy<Applicant>.UnproxyObject(res).Include(x => x.DocType)
        //                                             .Include(u => u.Sex)
        //                                             .Include(u => u.Nationality)
        //                                             .Execute();

        //        return res;
        //    }
        //}

        //public Certificate GetCertificateByAppNo(long appNo)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        License foundLicense = DrivingLicenceRepository.GetRegularLicneseByAppNo(appNo);

        //        if (foundLicense != null)
        //        {
        //            Unproxy<Certificate>.UnproxyObject(foundLicense.Certificate).Include(x => x.CertificateStatus)
        //                                                                        .Include(u => u.CollectorRelationship)
        //                                                                        .Include(u => u.CollectorSex)
        //                                                                        .Include(u => u.CollectorNationality)
        //                                                                        .Execute();

        //            return foundLicense.Certificate;
        //        }

        //        return null;
        //    }
        //}

        //public void SaveCollectionData(long appNo, Certificate certificate, Image collectorSignature, string user, ApplicationStatuses? nextStatus = null)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            DrivingLicenceRepository.SaveOrUpdate<Certificate>(certificate);
        //            DrivingLicenceRepository.SaveOrUpdate<Image>(collectorSignature);

        //            if (nextStatus != null)
        //            {
        //                if (appNo > 0)
        //                    UpdateApplication(appNo, nextStatus.Value, user);
        //            }
        //        });
        //    }
        //}

        //public void SaveQAScreen(long appNo, ApplicationStatuses nextStatus, string user)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            UpdateApplication(appNo, nextStatus, user);
        //        });
        //    }
        //}

        //public License GetRegularLicenceByAppNo(long appNo)
        //{
        //    License licence = null;
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            licence = DrivingLicenceRepository.GetRegularLicneseByAppNo(appNo);
        //        });
        //    }
        //    return licence;
        //}

        //public Tuple<EnquiryLicenseDTO, List<EnquiryLicenseDTO>> GetLicenceDataForEnquiryLicneseScreenByAppNo(long appNo)
        //{
        //    License license = null;
        //    List<License> tempLicenses = null;

        //    EnquiryLicenseDTO regularLicenseDto = null;
        //    List<EnquiryLicenseDTO> tempLicenseDtoList = null;
        //    EnquiryLicenseDTO tempLicenseDto = null;

        //    #region regular license

        //    UnitOfWorkOriginal.Transaction(delegate ()
        //    {
        //        license = DrivingLicenceRepository.GetRegularLicneseByAppNo(appNo);

        //        if (license != null && license.Certificate != null)
        //        {
        //            Unproxy<License>.UnproxyObject(license).Include(x => x.LicenseStatus).Execute();
        //        }

        //        tempLicenses = DrivingLicenceRepository.GetTemporaryLicnesesByAppNo(appNo);

        //        foreach (var tempLicense in tempLicenses)
        //        {
        //            if (tempLicense != null && tempLicense.Certificate != null)
        //            {
        //                Unproxy<License>.UnproxyObject(tempLicense).Include(x => x.LicenseStatus).Execute();
        //            }
        //        }
        //    });

        //    if (license != null && license.Certificate != null)
        //    {
        //        regularLicenseDto = new EnquiryLicenseDTO();

        //        regularLicenseDto.CollectorSurname = license.Certificate.CollectorSurname;
        //        regularLicenseDto.CollectorOthername = license.Certificate.CollectorOtherNames;
        //        regularLicenseDto.CollectorSex = license.Certificate.CollectorSex != null ? license.Certificate.CollectorSex.Description : null;
        //        regularLicenseDto.CollectorBirthDate = license.Certificate.CollectorBirthDate;
        //        regularLicenseDto.CollectorIDDocType = !license.Certificate.CollectorIDNumber.IsNullOrEmpty() ? DocumentTypes.LesothoID.GetFullName() : DocumentTypes.Passport.GetFullName();
        //        regularLicenseDto.CollectorIDNumber = !license.Certificate.CollectorIDNumber.IsNullOrEmpty() ? license.Certificate.CollectorIDNumber : license.Certificate.CollectorPassportNo;
        //        regularLicenseDto.CollectorNationality = license.Certificate.CollectorNationality != null ? license.Certificate.CollectorNationality.Description : null;
        //        regularLicenseDto.CollectorPhysicalAddress = license.Certificate.CollectorPhysicalAddress;
        //        regularLicenseDto.CollectorPostalAddress = license.Certificate.CollectorPostalAddress;
        //        regularLicenseDto.CollectorTelephone = license.Certificate.CollectorTelephone;
        //        regularLicenseDto.CollectorRealtionshipWithApplicant = license.Certificate.CollectorRelationship != null ? license.Certificate.CollectorRelationship.Description : null;
        //        regularLicenseDto.CollectorCollectionDate = license.Certificate.DateCollected;
        //    }

        //    #endregion

        //    #region remp licenses

        //    if (tempLicenses != null && tempLicenses.Count > 0)
        //    {
        //        tempLicenseDtoList = new List<EnquiryLicenseDTO>();

        //        foreach (var tempLicense in tempLicenses)
        //        {
        //            if (tempLicense.Certificate != null)
        //            {
        //                tempLicenseDto = new EnquiryLicenseDTO();

        //                tempLicenseDto.SerialNumber = tempLicense.Certificate.SerialNo;
        //                tempLicenseDto.PrintUser = tempLicense.Certificate.UserPrinted;
        //                tempLicenseDto.PrintDate = tempLicense.Certificate.DatePrinted;

        //                tempLicenseDto.CollectorSurname = tempLicense.Certificate.CollectorSurname;
        //                tempLicenseDto.CollectorOthername = tempLicense.Certificate.CollectorOtherNames;
        //                tempLicenseDto.CollectorSex = tempLicense.Certificate.CollectorSex != null ? tempLicense.Certificate.CollectorSex.Description : null;
        //                tempLicenseDto.CollectorBirthDate = tempLicense.Certificate.CollectorBirthDate;
        //                tempLicenseDto.CollectorIDDocType = !tempLicense.Certificate.CollectorIDNumber.IsNullOrEmpty() ? DocumentTypes.LesothoID.GetFullName() : DocumentTypes.Passport.GetFullName();
        //                tempLicenseDto.CollectorIDNumber = !tempLicense.Certificate.CollectorIDNumber.IsNullOrEmpty() ? tempLicense.Certificate.CollectorIDNumber : tempLicense.Certificate.CollectorPassportNo;
        //                tempLicenseDto.CollectorNationality = tempLicense.Certificate.CollectorNationality != null ? tempLicense.Certificate.CollectorNationality.Description : null;
        //                tempLicenseDto.CollectorPhysicalAddress = tempLicense.Certificate.CollectorPhysicalAddress;
        //                tempLicenseDto.CollectorPostalAddress = tempLicense.Certificate.CollectorPostalAddress;
        //                tempLicenseDto.CollectorTelephone = tempLicense.Certificate.CollectorTelephone;
        //                tempLicenseDto.CollectorRealtionshipWithApplicant = tempLicense.Certificate.CollectorRelationship != null ? tempLicense.Certificate.CollectorRelationship.Description : null;
        //                tempLicenseDto.CollectorCollectionDate = tempLicense.Certificate.DateCollected;

        //                tempLicenseDtoList.Add(tempLicenseDto);
        //            }
        //        }
        //    }

        //    #endregion

        //    Tuple<EnquiryLicenseDTO, List<EnquiryLicenseDTO>> res = new Tuple<EnquiryLicenseDTO, List<EnquiryLicenseDTO>>(regularLicenseDto, tempLicenseDtoList);

        //    return res;
        //}

        //public void SaveComment(Comment comment)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            SaveCommentToDb(comment);
        //        });
        //    }
        //}

        //public bool UpdateCommentAsRead(int id, int menuId, long currentAppNo, int parentMenuId)
        //{
        //    bool foundUnReadCommentsForApp = false;

        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            CommentToMenu found = DrivingLicenceRepository.GetCommentToMenu(id, menuId, parentMenuId);

        //            if (found != null)
        //            {
        //                found.IsRead = YesNo.Yes.GetCharValue();
        //                DrivingLicenceRepository.SaveOrUpdate<CommentToMenu>(found);
        //            }
        //        });
        //    }

        //    //workaround: must be after transaction commited to have the session.flush()
        //    foundUnReadCommentsForApp = CheckIfHasUnreadComments(currentAppNo, menuId, parentMenuId);

        //    return foundUnReadCommentsForApp;
        //}

        //public PersonDTO GetEnquiryCurrentDetails(int intref)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        License license = DrivingLicenceRepository.GetActiveLicneseByIntref(intref);
        //        Applicant applicant = DrivingLicenceRepository.Get<Applicant>(license.AppNo);
        //        List<PersonToPersonalRestriction> personalRestrictions = DrivingLicenceRepository.GetPersonalRestrictions(intref);
        //        ApplicationDL application = DrivingLicenceRepository.Get<ApplicationDL>(license.AppNo);

        //        List<ImageTypes> imageTypes = new List<ImageTypes>();
        //        imageTypes.Add(ImageTypes.Photo);
        //        imageTypes.Add(ImageTypes.Signature);
        //        imageTypes.Add(ImageTypes.Fingerprint);
        //        List<Image> images = DrivingLicenceRepository.GetImageByImageTypes(license.AppNo, imageTypes);

        //        List<TypeToLicense> TypeToLicenses = DrivingLicenceRepository.GetTypeToLicenseList(license.ID);


        //        PersonDTO dto = new PersonDTO();
        //        dto.Interef = int.Parse(applicant.IntrefNo);
        //        dto.Surname = applicant.Surname;
        //        dto.OtherNames = applicant.OtherNames;
        //        dto.SexDesc = applicant.Sex.Description;
        //        dto.BirthDate = applicant.BirthDate;
        //        dto.IdDocTypeDesc = applicant.DocType.Description;
        //        dto.IDNumber = applicant.IDNumber;
        //        dto.NationalityDesc = applicant.Nationality.Description;
        //        dto.Height = applicant.Height.Value;
        //        dto.PhysicalAddress = applicant.PhysicalAddress;
        //        dto.PostalAddress = applicant.PostalAddress;
        //        dto.Phone = applicant.Phone;
        //        dto.PersonalRestrictions = string.Join(", ", personalRestrictions.Select(x => x.Restriction.Description).ToList());

        //        Wsq2Bmp.WsqDecoder wsqDecoder = new Wsq2Bmp.WsqDecoder();

        //        try
        //        {
        //            dto.Photo = images.FirstOrDefault(x => x.ImageType.ID == ImageTypes.Photo.GetStringValue()).BinaryData;
        //        }
        //        catch (Exception e)
        //        {
        //        }

        //        try
        //        {

        //            var found = images.FirstOrDefault(x => x.ImageType.ID == ImageTypes.Fingerprint.GetStringValue());
        //            if (found != null)
        //            {
        //                if (found.BinaryData != null)
        //                    dto.FingerprintBmp = wsqDecoder.DecodeToByte(found.BinaryData);

        //                if (found.BinaryData == null && found.IsWaived == YesNo.Yes.GetCharValue())
        //                    dto.IsFingerprintWaived = true;
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //        }

        //        try
        //        {
        //            dto.Signature = images.FirstOrDefault(x => x.ImageType.ID == ImageTypes.Signature.GetStringValue()).BinaryData;

        //        }
        //        catch (Exception e)
        //        {
        //        }


        //        dto.CurrentLicenseNo = license.LicenseNo;
        //        dto.CurrentLicenseValidFrom = license.IssueDate;
        //        dto.CurrentLicenseValidTo = license.ExpiryDate;
        //        dto.CurrentLicenseIssuuingCenter = "??????";


        //        dto.TypeToLicenses = new List<TypeToLicenseDTO>();
        //        foreach (var item in TypeToLicenses)
        //        {
        //            dto.TypeToLicenses.Add(new TypeToLicenseDTO()
        //            {
        //                FirstIssueDate = item.FirstIssueDate,
        //                IsSuspended = item.IsSuspended == YesNo.Yes.GetCharValue() ? true : false,
        //                LicenseSerialNo = item.License.ID,
        //                LicenseTypeDesc = item.LicenseType.Description,
        //                SuspendedUntilDate = item.SuspendedUntilDate,
        //                VehicleRestrictionDesc = item.VehicleRestriction.Description
        //            });
        //        }

        //        return dto;
        //    }
        //}

        //public List<ApplicationDTO> GetApplicationsByIntref(int intref)
        //{
        //    List<ApplicationDTO> list = new List<ApplicationDTO>();

        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            list = DrivingLicenceRepository.GetApplicationsByIntref(intref);

        //            Unproxy<ApplicationDTO>.UnproxyCollection(list).Include(x => x.ApplicationType)
        //                                                           .Include(u => u.CurrentStatus)
        //                                                           .Execute();

        //        });
        //    }

        //    return list;
        //}

        //public License GetLicenceByIntref(string intref, LicenseStatuses status)
        //{
        //    License license = null;

        //    UnitOfWorkOriginal.Transaction(delegate ()
        //    {
        //        license = DrivingLicenceRepository.GetLicenceByIntref(intref, status);
        //    });

        //    return license;


        //}

        //public List<PersonalRestriction> GetPersonalRestriction(long appNo)
        //{
        //    List<PersonalRestriction> restrictions = null;
        //    UnitOfWorkOriginal.Transaction(delegate ()
        //    {

        //        restrictions = DrivingLicenceRepository.Get<ApplicationDL>(appNo).PersonalRestrictions.ToList();
        //    });

        //    return restrictions;
        //}

        //public void SaveLicence(License licence)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        int seq = GetLicenseIDNextSequence();

        //        licence.ID = seq;
        //        licence.Certificate.LicenseID = seq;

        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            DrivingLicenceRepository.SaveOrUpdate<License>(licence);
        //        });
        //    }
        //}

        //public List<ApplicationDL> GetOpenApplicationsByIntref(string intref)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        return DrivingLicenceRepository.GetOpenApplicationsByIntref(intref);
        //    }
        //}

        //#region private methods

        //private void SavePersonalRestriction(ApplicationDL application)
        //{
        //    foreach (PersonalRestriction pr in application.PersonalRestrictions)
        //    {
        //        DrivingLicenceRepository.SaveOrUpdate<PersonalRestriction>(pr);
        //    }
        //}

        //private void SaveApplicationTracing(ApplicationDL application)
        //{
        //    ApplicationTracing tracing = new ApplicationTracing();
        //    tracing.LastUpdate = DateTime.Now;
        //    tracing.NewStatus = application.ApplicationStatus.ID;
        //    tracing.AppNo = application.AppNo;
        //    if (tracing.NewStatus > 0)
        //        tracing.OldStatus = tracing.NewStatus - 1;
        //    //else
        //    //    tracing.OldStatus = null;

        //    tracing.UserUpdate = application.UserUpdate;
        //    DrivingLicenceRepository.SaveOrUpdate<ApplicationTracing>(tracing);
        //}

        //private void UpdateApplication(long appno, ApplicationStatuses nextStatus, string user, string denyReason = null)
        //{
        //    var app = DrivingLicenceRepository.Get<ApplicationDL>(appno);
        //    SaveApplicationTracing(nextStatus, user, app);

        //    app.ApplicationStatus = new ApplicationStatus() { ID = (int)nextStatus };
        //    app.DateUpdate = DateTime.Now;
        //    app.UserUpdate = user;
        //    app.DenyReason = denyReason;
        //    DrivingLicenceRepository.SaveOrUpdate<ApplicationDL>(app);
        //}

        //private void SaveApplicationTracing(ApplicationStatuses nextStatus, string user, ApplicationDL app)
        //{
        //    ApplicationTracing appTracing = new ApplicationTracing();
        //    appTracing.AppNo = app.AppNo;
        //    appTracing.OldStatus = app.ApplicationStatus.ID;
        //    appTracing.UserUpdate = user;
        //    appTracing.LastUpdate = DateTime.Now;
        //    appTracing.NewStatus = (int)nextStatus;
        //    DrivingLicenceRepository.SaveOrUpdate<ApplicationTracing>(appTracing);
        //}

        //public bool PersonExistInLocalDBbyIDNumber(string iDNumber)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        Person person = DrivingLicenceRepository.FindAll<Person>().Where(x => x.IdNumber == iDNumber).FirstOrDefault();
        //        if (person == null)
        //            return false;
        //        else
        //            return true;
        //    }
        //}

        //public bool FiveFieldsExistnessCheck(string passportNumber, string surname, string otherNames, Sex sex, DateTime? birthDate)
        //{
        //    Person person = DrivingLicenceRepository.FindAll<Person>().Where(x => x.Passport == passportNumber && x.Surname == surname &&
        //     x.OtherNames == otherNames && x.Sex.ID == sex.ID && x.BirthDate == birthDate).FirstOrDefault();
        //    if (person == null)
        //        return false;
        //    else
        //        return true;
        //}

        //private void SaveLicence(ApplicationDL application)
        //{
        //    application.UpdatedLicense.ID = GetLicenseIDNextSequence();

        //    application.UpdatedLicense.AppNo = application.AppNo;
        //    application.UpdatedLicense.IntrefNo = application.IntrefNo;
        //    var licNum = LicenceHelper.CreateLicenceNumber(application.Applicant.BirthDate.Value, application.IntrefNo, application.Applicant.IDNumber, application.Applicant.Sex.ID, application.Applicant.Height);
        //    application.UpdatedLicense.LicenseNo = licNum;

        //    DrivingLicenceRepository.SaveOrUpdate<License>(application.UpdatedLicense);
        //}

        //private int GetLicenseIDNextSequence()
        //{
        //    int seq = UnitOfWorkOriginal.Session.CreateSQLQuery(" select LICENSE_SEQ.NEXTVAL as SEQ from dual ").AddScalar("SEQ", NHibernateUtil.Int32).UniqueResult<int>();
        //    return seq;
        //}
        

        //public void SaveUser(User user)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            DrivingLicenceRepository.SaveOrUpdate(user);
        //        });
        //    }
        //}

        //private void SaveApplicantAndApplication(ApplicationDL application, string intref)
        //{
        //    application.IntrefNo = intref;
        //    application.Applicant.IntrefNo = intref;


        //    //if geting here for the first time (from registration)
        //    if (application.AppNo == 0)
        //    {
        //        long appId = UnitOfWorkOriginal.Session.CreateSQLQuery("select APP_ID_SEQ.NEXTVAL as SEQ from dual ").AddScalar("SEQ", NHibernateUtil.Int64).UniqueResult<long>();
        //        application.AppNo = appId;
        //        application.Applicant.AppNo = appId;
        //    }



        //    DrivingLicenceRepository.SaveOrUpdate<ApplicationDL>(application);
        //    DrivingLicenceRepository.SaveOrUpdate<Applicant>(application.Applicant);

        //    foreach (LicenseTypeToApplication item in application.LicenseTypes)
        //    {
        //        item.Application = application;
        //        DrivingLicenceRepository.SaveOrUpdate<LicenseTypeToApplication>(item);
        //    }
        //}

        //private void SaveSupportingDocuments(ApplicationDL application)
        //{
        //    //when from registration
        //    if (application.ApplicationType.SupDocToAppTypes != null)
        //    {
        //        foreach (SupDocToAppType supdoc in application.ApplicationType.SupDocToAppTypes)
        //        {

        //            SupportDocToApplication appDoc = new SupportDocToApplication();
        //            // appDoc.Id = seq++;

        //            appDoc.Application = application;
        //            appDoc.SubmitionDate = DateTime.Now;
        //            appDoc.SupportingDocument = supdoc.SupportingDocument;
        //            if (supdoc.IsProvided)
        //                appDoc.Submited = 'T';
        //            else
        //                appDoc.Submited = 'F';

        //            if (supdoc.Mandatory == 1)
        //                appDoc.Mandatory = 'T';
        //            else
        //                appDoc.Mandatory = 'F';


        //            DrivingLicenceRepository.SaveOrUpdate<SupportDocToApplication>(appDoc);

        //        }
        //    }
        //    else
        //    {

        //        //when from verification
        //        if (application.SupportedDocs != null && application.SupportedDocs.Count != 0)
        //            foreach (SupportDocToApplication supdoc in application.SupportedDocs)
        //            {
        //                if (supdoc.IsProvided)
        //                    supdoc.Submited = 'T';
        //                else
        //                    supdoc.Submited = 'F';

        //                if (supdoc.Mandatory == 1)
        //                    supdoc.Mandatory = 'T';
        //                else
        //                    supdoc.Mandatory = 'F';

        //                DrivingLicenceRepository.SaveOrUpdate<SupportDocToApplication>(supdoc);
        //            }
        //    }

        //    if (application.Images != null)
        //    {
        //        foreach (Image im in application.Images)
        //        {
        //            im.AppNo = application.AppNo;
        //            DrivingLicenceRepository.SaveOrUpdate<Image>(im);
        //        }
        //    }
        //}

        //private Person SavePrson(Applicant applicant)
        //{
        //    Person person = null;

        //    if (applicant.IntrefNo == null)//if from registration
        //    {
        //        if (applicant.IDNumber != null)
        //        {
        //            person = DrivingLicenceRepository.FindAll<Person>().Where(x => x.IdNumber == applicant.IDNumber).FirstOrDefault();
        //            //if(person==null)
        //            //    person = new Person();
        //        }
        //        //else
        //        //{
        //        //    person = new Person();
        //        //    int intref = UnitOfWorkOriginal.Session.CreateSQLQuery(" select INTREF_SEQ.NEXTVAL as SEQ from dual ").AddScalar("SEQ", NHibernateUtil.Int32).UniqueResult<int>();
        //        //    person.Intref = intref.ToString();
        //        //}
        //    }
        //    else// from verification
        //    {
        //        person = DrivingLicenceRepository.FindAll<Person>().Where(x => x.Intref == applicant.IntrefNo).FirstOrDefault();
        //    }

        //    if (person == null)
        //    {
        //        person = new Person();
        //        int intref = UnitOfWorkOriginal.Session.CreateSQLQuery(" select INTREF_SEQ.NEXTVAL as SEQ from dual ").AddScalar("SEQ", NHibernateUtil.Int32).UniqueResult<int>();
        //        person.Intref = intref.ToString();
        //    }


        //    person.Passport = applicant.PassportNumber;
        //    person.IdNumber = applicant.IDNumber;
        //    person.Surname = applicant.Surname;
        //    person.OtherNames = applicant.OtherNames;
        //    person.Sex = applicant.Sex;
        //    person.Nationality = applicant.Nationality;
        //    person.PhysicalAddress = applicant.PhysicalAddress;
        //    person.PostalAddress = applicant.PostalAddress;
        //    person.BirthDate = applicant.BirthDate;
        //    person.Height = applicant.Height.Value;
        //    person.Phone = applicant.Phone;
        //    DrivingLicenceRepository.SaveOrUpdate<Person>(person);

        //    return person;
        //}

        //private void SaveCommentToDb(Comment comment)
        //{
        //    int maxId = DrivingLicenceRepository.GetCommentMaxID();
        //    comment.ID = ++maxId;

        //    DrivingLicenceRepository.SaveOrUpdate<Comment>(comment);

        //    foreach (var commentToMenu in comment.CommentToMenu)
        //    {
        //        DrivingLicenceRepository.SaveOrUpdate<CommentToMenu>(commentToMenu);
        //    }
        //}

        //#region Printing

        //private PrintingDataDrivingLicenceDTO CreatePrintingDataDTO(ApplicationDL applicationDL, Person person)
        //{
        //    PrintingDataDrivingLicenceDTO returnValue = new PrintingDataDrivingLicenceDTO();

        //    returnValue.IntRef = person.Intref;
        //    returnValue.FirstNames = person.OtherNames;
        //    returnValue.LastName = person.Surname;
        //    if (person.BirthDate.HasValue)
        //        returnValue.BirthDate = person.BirthDate.Value.ToShortDateString();
        //    returnValue.BarcodeString = "";


        //    return returnValue;
        //}

        //#endregion Printing

        //#endregion

        //public void SavePermissions(List<int> permittedMenuIds, List<int> unpermittedMenuIds, string roleName)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            Role role = DrivingLicenceRepository.Load<Role>(roleName);

        //            if (role != null && role.Menus != null)
        //            {
        //                foreach (var id in unpermittedMenuIds)
        //                {
        //                    Menu menu = DrivingLicenceRepository.Load<Menu>(id);
        //                    if (menu != null)
        //                    {
        //                        role.Menus.Remove(menu);
        //                    }
        //                }

        //                foreach (var id in permittedMenuIds)
        //                {
        //                    Menu menu = DrivingLicenceRepository.Load<Menu>(id);
        //                    if (menu != null)
        //                    {
        //                        role.Menus.Add(menu);
        //                    }
        //                }

        //                DrivingLicenceRepository.SaveOrUpdate<Role>(role);
        //            }
        //        });
        //    }
        //}

        //public void UpdateSupDocToAppTypes(List<SupDocToAppType> updated, List<SupDocToAppType> added, List<SupDocToAppType> deleted, string userName)
        //{
        //    using (UnitOfWorkOriginal.Start())
        //    {
        //        UnitOfWorkOriginal.Transaction(delegate ()
        //        {
        //            SupDocToAppType supDocToAppType = null;

        //            foreach (var item in deleted)
        //            {
        //                //supDocToAppType = DrivingLicenceRepository.Get<SupDocToAppType>(item);

        //                DrivingLicenceRepository.Delete<SupDocToAppType>(item);
        //            }

        //            foreach (var item in updated)
        //            {
        //                //supDocToAppType = DrivingLicenceRepository.Get<SupDocToAppType>(item);

        //                DrivingLicenceRepository.SaveOrUpdate<SupDocToAppType>(item);
        //            }

        //            foreach (var item in added)
        //            {
        //                //supDocToAppType = DrivingLicenceRepository.Get<SupDocToAppType>(item);

        //                DrivingLicenceRepository.Save<SupDocToAppType>(item);
        //            }
        //        });
        //    }
        //}
    }
}
