using NGU.Admin.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD.App.ePayment.DTO;
using NHibernate;
using NGU.Admin.Core;
using NHibernate.Criterion;
using NGU.Admin.Enums;

namespace NGU.Admin.Repositories
{
    public class DrivingLicenceRepository : BaseRepository, IDrivingLicenceRepository
    {
        #region oldCode
        
        //public List<ApplicationDTO> GetApplicationsForIssuanceScreen(SearchDTO searchDto)
        //{
        //    List<ApplicationDTO> listToReturn = new List<ApplicationDTO>();
        //    ApplicationDTO dto;
        //    Applicant applicant;
        //    ApplicationDL application;

        //    switch (searchDto.SearchType)
        //    {
        //        case Enums.SearchTypes.ApplicationDetails:

        //            #region ApplicationDetails

        //            var queryByApplicationDetails = SessionOriginal.QueryOver<ApplicationDL>().Where(x => x.AppNo > 0);

        //            if (searchDto.AppNo.HasValue)
        //                queryByApplicationDetails.And(Restrictions.Eq(ApplicationDL.Props.AppNo, searchDto.AppNo.Value));

        //            if (searchDto.AppTypeID.HasValue)
        //                queryByApplicationDetails.And(Restrictions.Eq(ApplicationDL.Props.ApplicationType.ID, searchDto.AppTypeID.Value));

        //            if (searchDto.AppRegDate.HasValue)
        //            {
        //                DateTime startDate = searchDto.AppRegDate.Value.Date;
        //                DateTime endDate = searchDto.AppRegDate.Value.Date.AddDays(1).AddSeconds(-1);

        //                queryByApplicationDetails.And(Restrictions.Ge(ApplicationDL.Props.RegistrationDate, startDate));
        //                queryByApplicationDetails.And(Restrictions.Le(ApplicationDL.Props.RegistrationDate, endDate));
        //            }

        //            if (searchDto.AppIssueDate.HasValue)
        //            {
        //                DateTime startDate = searchDto.AppIssueDate.Value.Date;
        //                DateTime endDate = searchDto.AppIssueDate.Value.Date.AddDays(1).AddSeconds(-1);

        //                queryByApplicationDetails.JoinQueryOver<License>(x => x.Licenses).Where(Restrictions.Ge(License.Props.IssueDate, startDate))
        //                                                                                  .And(Restrictions.Le(License.Props.IssueDate, endDate));
        //            }

        //            //if selected app status does not exist, then filter only open applications
        //            if (searchDto.AppCurrentStatusID.HasValue)
        //                queryByApplicationDetails.And(Restrictions.Eq(ApplicationDL.Props.ApplicationStatus.ID, searchDto.AppCurrentStatusID.Value));
        //            else
        //                queryByApplicationDetails.And(Restrictions.Lt(ApplicationDL.Props.ApplicationStatus.ID, (int)ApplicationStatuses.Collected));


        //            if (searchDto.SelectedScreens != null && searchDto.SelectedScreens.Count > 0)
        //            {
        //                //TODO: filter by menu.accesibility
        //                List<int> filterList = new List<int>();

        //                foreach (var menuId in searchDto.SelectedScreens)
        //                {
        //                    foreach (var dicItem in DicMenuApplicationStatus)
        //                    {
        //                        if (dicItem.Key.MenuId == menuId)
        //                            filterList.AddRange(dicItem.Value.Select(x => (int)x));
        //                    }
        //                }

        //                filterList = filterList.Distinct().ToList();

        //                if (filterList.Count > 0)
        //                    queryByApplicationDetails.And(Restrictions.In(ApplicationDL.Props.ApplicationStatus.ID.ToString(), filterList));
        //            }

        //            //filter out unallowed application statuses by user's role
        //            if (searchDto.AllowedApplicationStatuses != null && searchDto.AllowedApplicationStatuses.Count > 0)
        //                queryByApplicationDetails.And(Restrictions.In(ApplicationDL.Props.ApplicationStatus.ID.ToString(), searchDto.AllowedApplicationStatuses));


        //            IList<ApplicationDL> resByApplicationDetails = queryByApplicationDetails.Take(50).List<ApplicationDL>();

        //            #endregion

        //            #region prepare data to return

        //            foreach (var itemApplication in resByApplicationDetails)
        //            {
        //                applicant = SessionOriginal.QueryOver<Applicant>().Where(x => x.AppNo == itemApplication.AppNo).SingleOrDefault();

        //                dto = new ApplicationDTO()
        //                {
        //                    AppNo = itemApplication.AppNo,
        //                    ApplicationType = itemApplication.ApplicationType,
        //                    Interef = itemApplication.IntrefNo,
        //                    CurrentStatus = itemApplication.ApplicationStatus,
        //                    NextAction = GetNextAction(itemApplication.ApplicationStatus),
        //                    RegistrationDate = itemApplication.RegistrationDate,
        //                    Surname = applicant != null ? applicant.Surname : null,
        //                    OtherNames = applicant != null ? applicant.OtherNames : null,
        //                    Sex = applicant != null ? applicant.Sex : null,
        //                    BirthDate = applicant != null ? applicant.BirthDate : null,
        //                    IDNumber = applicant != null ? applicant.IDNumber : null,
        //                };

        //                listToReturn.Add(dto);
        //            }

        //            #endregion

        //            break;
        //        case Enums.SearchTypes.PersonalDetails:

        //            #region PersonalDetails

        //            var queryByPersonalDetails = SessionOriginal.QueryOver<Applicant>().Where(x => x.AppNo > 0);

        //            if (!searchDto.PersonIDNumber.IsNullOrEmpty())
        //                queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.IDNumber, searchDto.PersonIDNumber));

        //            if (!searchDto.PersonIntrefNo.IsNullOrEmpty())
        //                queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.IntrefNo, searchDto.PersonIntrefNo));

        //            if (!searchDto.PersonSurname.IsNullOrEmpty())
        //            {
        //                if (searchDto.PersonExactNames)
        //                    queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.Surname, searchDto.PersonSurname).IgnoreCase());
        //                else
        //                    queryByPersonalDetails.And(Restrictions.InsensitiveLike(Applicant.Props.Surname, searchDto.PersonSurname.LikeString()));
        //            }

        //            if (!searchDto.PersonOtherNames.IsNullOrEmpty())
        //            {
        //                if (searchDto.PersonExactNames)
        //                    queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.OtherNames, searchDto.PersonOtherNames).IgnoreCase());
        //                else
        //                    queryByPersonalDetails.And(Restrictions.InsensitiveLike(Applicant.Props.OtherNames, searchDto.PersonOtherNames.LikeString()));
        //            }

        //            if (searchDto.PersonBirthDate.HasValue)
        //            {
        //                DateTime startDate = searchDto.PersonBirthDate.Value.Date;
        //                DateTime endDate = searchDto.PersonBirthDate.Value.Date.AddDays(1).AddSeconds(-1);

        //                queryByPersonalDetails.And(Restrictions.Ge(Applicant.Props.BirthDate, startDate));
        //                queryByPersonalDetails.And(Restrictions.Le(Applicant.Props.BirthDate, endDate));
        //            }

        //            if (!searchDto.PersonSex.IsNullOrEmpty())
        //                queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.Sex.ID, searchDto.PersonSex));

        //            IList<Applicant> resByPersonalDetails = queryByPersonalDetails.Take(50).List<Applicant>();

        //            #endregion

        //            #region prepare data to return

        //            foreach (var itemApplicant in resByPersonalDetails)
        //            {
        //                application = SessionOriginal.QueryOver<ApplicationDL>().Where(x => x.AppNo == itemApplicant.AppNo).SingleOrDefault();

        //                dto = new ApplicationDTO()
        //                {
        //                    AppNo = itemApplicant.AppNo,
        //                    ApplicationType = application.ApplicationType,
        //                    Interef = itemApplicant.IntrefNo,
        //                    CurrentStatus = application.ApplicationStatus,
        //                    NextAction = GetNextAction(application.ApplicationStatus),
        //                    RegistrationDate = application.RegistrationDate,
        //                    Surname = itemApplicant.Surname,
        //                    OtherNames = itemApplicant.OtherNames,
        //                    Sex = itemApplicant.Sex,
        //                    BirthDate = itemApplicant.BirthDate,
        //                    IDNumber = itemApplicant.IDNumber,
        //                };


        //                listToReturn.Add(dto);
        //            }

        //            #endregion

        //            break;
        //        case Enums.SearchTypes.LicenseDetails:

        //            #region LicenseDetails

        //            var queryByLicenseDetails = SessionOriginal.QueryOver<License>().Where(x => x.ID > 0);

        //            if (!searchDto.LicenseIntrefNo.IsNullOrEmpty())
        //                queryByLicenseDetails.And(Restrictions.Eq(License.Props.IntrefNo, searchDto.LicenseIntrefNo));

        //            if (searchDto.LicenseIssueDate.HasValue)
        //            {
        //                DateTime startDate = searchDto.LicenseIssueDate.Value.Date;
        //                DateTime endDate = searchDto.LicenseIssueDate.Value.Date.AddDays(1).AddSeconds(-1);

        //                queryByLicenseDetails.And(Restrictions.Ge(License.Props.IssueDate, startDate));
        //                queryByLicenseDetails.And(Restrictions.Le(License.Props.IssueDate, endDate));
        //            }

        //            //TODO
        //            ////if (searchDto.LicenseTypeID.HasValue)
        //            ////    queryByLicenseDetails.And(Restrictions.Where<License>(x => x.LicenseType == searchDto.LicenseTypeID));

        //            if (!searchDto.LicenseNo.IsNullOrEmpty())
        //                queryByLicenseDetails.And(Restrictions.Eq(License.Props.LicenseNo, searchDto.LicenseNo));

        //            if (searchDto.LicenseSerialNo.HasValue)
        //                queryByLicenseDetails.JoinQueryOver<Certificate>(x => x.Certificate).Where(Restrictions.Eq(Certificate.Props.SerialNo, searchDto.LicenseSerialNo));


        //            IList<License> resByLicenseDetails = queryByLicenseDetails.Take(50).List<License>();

        //            #endregion

        //            #region prepare data to return

        //            foreach (var itemLicense in resByLicenseDetails)
        //            {
        //                application = SessionOriginal.QueryOver<ApplicationDL>().Where(x => x.AppNo == itemLicense.AppNo).SingleOrDefault();
        //                applicant = SessionOriginal.QueryOver<Applicant>().Where(x => x.IntrefNo == itemLicense.IntrefNo).SingleOrDefault();

        //                dto = new ApplicationDTO()
        //                {
        //                    AppNo = itemLicense.AppNo,
        //                    ApplicationType = application.ApplicationType,
        //                    Interef = itemLicense.IntrefNo,
        //                    CurrentStatus = application.ApplicationStatus,
        //                    NextAction = GetNextAction(application.ApplicationStatus),
        //                    RegistrationDate = application.RegistrationDate,
        //                    Surname = applicant.Surname,
        //                    OtherNames = applicant.OtherNames,
        //                    Sex = applicant.Sex,
        //                    BirthDate = applicant.BirthDate,
        //                    IDNumber = applicant.IDNumber,
        //                };


        //                listToReturn.Add(dto);
        //            }

        //            #endregion

        //            break;
        //    }

        //    return listToReturn.OrderByDescending(x => x.AppNo).ToList<ApplicationDTO>();
        //}

        //public List<PersonDTO> GetPersonsForEnquiryScreen(SearchDTO searchDto)
        //{
        //    List<PersonDTO> listToReturn = new List<PersonDTO>();
        //    PersonDTO dto;

        //    switch (searchDto.SearchType)
        //    {
        //        case Enums.SearchTypes.ApplicationDetails:

        //            #region ApplicationDetails

        //            var queryByApplicationDetails = SessionOriginal.QueryOver<ApplicationDL>().Where(x => x.AppNo > 0);

        //            if (searchDto.AppNo.HasValue)
        //                queryByApplicationDetails.And(Restrictions.Eq(ApplicationDL.Props.AppNo, searchDto.AppNo.Value));

        //            if (searchDto.AppTypeID.HasValue)
        //                queryByApplicationDetails.And(Restrictions.Eq(ApplicationDL.Props.ApplicationType.ID, searchDto.AppTypeID.Value));

        //            if (searchDto.AppRegDate.HasValue)
        //            {
        //                DateTime startDate = searchDto.AppRegDate.Value.Date;
        //                DateTime endDate = searchDto.AppRegDate.Value.Date.AddDays(1).AddSeconds(-1);

        //                queryByApplicationDetails.And(Restrictions.Ge(ApplicationDL.Props.RegistrationDate, startDate));
        //                queryByApplicationDetails.And(Restrictions.Le(ApplicationDL.Props.RegistrationDate, endDate));
        //            }

        //            if (searchDto.AppIssueDate.HasValue)
        //            {
        //                DateTime startDate = searchDto.AppIssueDate.Value.Date;
        //                DateTime endDate = searchDto.AppIssueDate.Value.Date.AddDays(1).AddSeconds(-1);

        //                queryByApplicationDetails.JoinQueryOver<License>(x => x.Licenses).Where(Restrictions.Ge(License.Props.IssueDate, startDate))
        //                                                                                  .And(Restrictions.Le(License.Props.IssueDate, endDate));
        //            }

        //            //if selected app status does not exist, then filter only open applications
        //            if (searchDto.AppCurrentStatusID.HasValue)
        //                queryByApplicationDetails.And(Restrictions.Eq(ApplicationDL.Props.ApplicationStatus.ID, searchDto.AppCurrentStatusID.Value));
        //            else
        //                queryByApplicationDetails.And(Restrictions.Lt(ApplicationDL.Props.ApplicationStatus.ID, (int)ApplicationStatuses.Collected));


        //            if (searchDto.SelectedScreens != null && searchDto.SelectedScreens.Count > 0)
        //            {
        //                //TODO: filter by menu.accesibility
        //                List<int> filterList = new List<int>();

        //                foreach (var menuId in searchDto.SelectedScreens)
        //                {
        //                    foreach (var dicItem in DicMenuApplicationStatus)
        //                    {
        //                        if (dicItem.Key.MenuId == menuId)
        //                            filterList.AddRange(dicItem.Value.Select(x => (int)x));
        //                    }
        //                }

        //                filterList = filterList.Distinct().ToList();

        //                if (filterList.Count > 0)
        //                    queryByApplicationDetails.And(Restrictions.In(ApplicationDL.Props.ApplicationStatus.ID.ToString(), filterList));
        //            }

        //            //////filter out unallowed application statuses by user's role
        //            ////if (searchDto.AllowedApplicationStatuses != null && searchDto.AllowedApplicationStatuses.Count > 0)
        //            ////    queryByApplicationDetails.And(Restrictions.In(ApplicationDL.Props.ApplicationStatus.ID.ToString(), searchDto.AllowedApplicationStatuses));


        //            IList<string> appsInteref = queryByApplicationDetails.Select(x => x.IntrefNo).List<string>();
        //            IList<Applicant> resApplicants = SessionOriginal.QueryOver<Applicant>().Where(x => x.IntrefNo.IsIn(appsInteref.ToArray())).Take(100).List<Applicant>();

        //            #endregion

        //            #region prepare data to return

        //            foreach (var item in resApplicants)
        //            {
        //                dto = new PersonDTO()
        //                {
        //                    Interef = int.Parse(item.IntrefNo),
        //                    Surname = item != null ? item.Surname : null,
        //                    OtherNames = item != null ? item.OtherNames : null,
        //                    Sex = item != null ? item.Sex : null,
        //                    BirthDate = item != null ? item.BirthDate : null,
        //                    IDNumber = item != null ? item.IDNumber : null,
        //                    LastUpdate = null
        //                };

        //                listToReturn.Add(dto);
        //            }

        //            #endregion

        //            break;
        //        case Enums.SearchTypes.PersonalDetails:

        //            #region PersonalDetails

        //            var queryByPersonalDetails = SessionOriginal.QueryOver<Applicant>().Where(x => x.AppNo > 0);

        //            if (!searchDto.PersonIDNumber.IsNullOrEmpty())
        //                queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.IDNumber, searchDto.PersonIDNumber));

        //            if (!searchDto.PersonIntrefNo.IsNullOrEmpty())
        //                queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.IntrefNo, searchDto.PersonIntrefNo));

        //            if (!searchDto.PersonSurname.IsNullOrEmpty())
        //            {
        //                if (searchDto.PersonExactNames)
        //                    queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.Surname, searchDto.PersonSurname).IgnoreCase());
        //                else
        //                    queryByPersonalDetails.And(Restrictions.InsensitiveLike(Applicant.Props.Surname, searchDto.PersonSurname.LikeString()));
        //            }

        //            if (!searchDto.PersonOtherNames.IsNullOrEmpty())
        //            {
        //                if (searchDto.PersonExactNames)
        //                    queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.OtherNames, searchDto.PersonOtherNames).IgnoreCase());
        //                else
        //                    queryByPersonalDetails.And(Restrictions.InsensitiveLike(Applicant.Props.OtherNames, searchDto.PersonOtherNames));
        //            }

        //            if (searchDto.PersonBirthDate.HasValue)
        //            {
        //                DateTime startDate = searchDto.PersonBirthDate.Value.Date;
        //                DateTime endDate = searchDto.PersonBirthDate.Value.Date.AddDays(1).AddSeconds(-1);

        //                queryByPersonalDetails.And(Restrictions.Ge(Applicant.Props.BirthDate, startDate));
        //                queryByPersonalDetails.And(Restrictions.Le(Applicant.Props.BirthDate, endDate));
        //            }

        //            if (!searchDto.PersonSex.IsNullOrEmpty())
        //                queryByPersonalDetails.And(Restrictions.Eq(Applicant.Props.Sex.ID, searchDto.PersonSex));

        //            IList<Applicant> resByPersonalDetails = queryByPersonalDetails.Take(100).List<Applicant>();

        //            #endregion

        //            #region prepare data to return

        //            foreach (var itemApplicant in resByPersonalDetails)
        //            {
        //                dto = new PersonDTO()
        //                {
        //                    Interef = int.Parse(itemApplicant.IntrefNo),
        //                    Surname = itemApplicant.Surname,
        //                    OtherNames = itemApplicant.OtherNames,
        //                    Sex = itemApplicant.Sex,
        //                    BirthDate = itemApplicant.BirthDate,
        //                    IDNumber = itemApplicant.IDNumber,
        //                    LastUpdate = null
        //                };


        //                listToReturn.Add(dto);
        //            }

        //            #endregion

        //            break;
        //        case Enums.SearchTypes.LicenseDetails:

        //            #region LicenseDetails

        //            var queryByLicenseDetails = SessionOriginal.QueryOver<License>().Where(x => x.ID > 0);

        //            if (!searchDto.LicenseIntrefNo.IsNullOrEmpty())
        //                queryByLicenseDetails.And(Restrictions.Eq(License.Props.IntrefNo, searchDto.LicenseIntrefNo));

        //            if (searchDto.LicenseIssueDate.HasValue)
        //            {
        //                DateTime startDate = searchDto.LicenseIssueDate.Value.Date;
        //                DateTime endDate = searchDto.LicenseIssueDate.Value.Date.AddDays(1).AddSeconds(-1);

        //                queryByLicenseDetails.And(Restrictions.Ge(License.Props.IssueDate, startDate));
        //                queryByLicenseDetails.And(Restrictions.Le(License.Props.IssueDate, endDate));
        //            }

        //            //TODO
        //            ////if (searchDto.LicenseTypeID.HasValue)
        //            ////    queryByLicenseDetails.And(Restrictions.Where<License>(x => x.LicenseType == searchDto.LicenseTypeID));

        //            if (!searchDto.LicenseNo.IsNullOrEmpty())
        //                queryByLicenseDetails.And(Restrictions.Eq(License.Props.LicenseNo, searchDto.LicenseNo));

        //            if (searchDto.LicenseSerialNo.HasValue)
        //                queryByLicenseDetails.JoinQueryOver<Certificate>(x => x.Certificate).Where(Restrictions.Eq(Certificate.Props.SerialNo, searchDto.LicenseSerialNo));


        //            IList<string> licensesInteref = queryByLicenseDetails.Select(x => x.IntrefNo).List<string>();

        //            IList<Applicant> applicants = SessionOriginal.QueryOver<Applicant>().Where(x => x.IntrefNo.IsIn(licensesInteref.ToArray())).Take(100).List<Applicant>();

        //            #endregion

        //            #region prepare data to return

        //            foreach (var itemApplicant in applicants)
        //            {
        //                dto = new PersonDTO()
        //                {
        //                    Interef = int.Parse(itemApplicant.IntrefNo),
        //                    Surname = itemApplicant.Surname,
        //                    OtherNames = itemApplicant.OtherNames,
        //                    Sex = itemApplicant.Sex,
        //                    BirthDate = itemApplicant.BirthDate,
        //                    IDNumber = itemApplicant.IDNumber,
        //                    LastUpdate = null
        //                };


        //                listToReturn.Add(dto);
        //            }

        //            #endregion

        //            break;
        //    }

        //    return listToReturn.OrderByDescending(x => x.Interef).ToList<PersonDTO>();
        //}

        //public List<Image> GetImageByImageTypes(long appNo, List<ImageTypes> imageTypes)
        //{
        //    ICriteria criteria = SessionOriginal.CreateCriteria<Image>();

        //    criteria.Add(Restrictions.Eq(Image.Props.AppNo, appNo));

        //    if (imageTypes != null && imageTypes.Count > 0)
        //    {
        //        string[] arr = imageTypes.Select(s => s.GetStringValue()).ToArray();

        //        string specificImageTypesParam = Image.Props.ImageType.ToString() + "." + ImageType.Props.ID.ToString();
        //        criteria.Add(Restrictions.In(specificImageTypesParam, arr));
        //    }

        //    var res = criteria.List<Image>().ToList();

        //    return res;
        //}

        //public License GetRegularLicneseByAppNo(long appNo)
        //{
        //    return SessionOriginal.QueryOver<License>().Where(x => x.AppNo == appNo && x.LicenseDocType.ID == (int)LicenseDocTypes.Regular).SingleOrDefault();
        //}

        //public List<License> GetTemporaryLicnesesByAppNo(long appNo)
        //{
        //    return SessionOriginal.QueryOver<License>().Where(x => x.AppNo == appNo && x.LicenseDocType.ID == (int)LicenseDocTypes.Temporary).List<License>().ToList();
        //}

        //public int GetCommentMaxID()
        //{
        //    int max = SessionOriginal.CreateCriteria<Comment>().SetProjection(Projections.Max("ID")).UniqueResult<int>();

        //    return max;
        //}

        //public CommentToMenu GetCommentToMenu(int id, int menuId, int parentMenuId)
        //{
        //    return SessionOriginal.QueryOver<CommentToMenu>().Where(x => x.Comment.ID == id && (x.Menu.MenuId == menuId || x.Menu.MenuId == parentMenuId)).SingleOrDefault();
        //}

        //public bool CheckIfHasUnreadComments(long appNo, int menuId, int? parentMenuId)
        //{
        //    string sql = string.Empty;

        //    if (parentMenuId.HasValue)
        //    {
        //        sql = string.Format("select count(*) from comments c inner join comment_to_menu m on m.comment_id=c.id where c.APP_ID={0} and (m.MENU_ID ={1} or m.MENU_ID ={2}) and m.read='N'", appNo, menuId, parentMenuId.Value);
        //    }
        //    else
        //    {
        //        sql = string.Format("select count(*) from comments c inner join comment_to_menu m on m.comment_id=c.id where c.APP_ID={0} and m.MENU_ID ={1} and m.read='N'", appNo, menuId);
        //    }

        //    var res = SessionOriginal.CreateSQLQuery(sql).UniqueResult();

        //    return Convert.ToInt32(res) > 0;
        //}

        //public License GetActiveLicneseByIntref(int intref)
        //{
        //    return SessionOriginal.QueryOver<License>().Where(x => x.LicenseStatus.ID == (int)LicenseStatuses.Active && x.IntrefNo == intref.ToString()).SingleOrDefault();
        //}

        //public List<PersonToPersonalRestriction> GetPersonalRestrictions(int intref)
        //{
        //    return SessionOriginal.QueryOver<PersonToPersonalRestriction>().Where(x => x.Intref == intref).List().ToList();
        //}

        //public List<TypeToLicense> GetTypeToLicenseList(int licenseId)
        //{
        //    return SessionOriginal.QueryOver<TypeToLicense>().Where(x => x.License.ID == licenseId).List().ToList();
        //}

        //public List<Comment> GetAllCommentsForCertainApp(long appNo)
        //{
        //    return SessionOriginal.QueryOver<Comment>().Where(x => x.AppNo == appNo).List().ToList();
        //}

        //public License GetLicenceByIntref(string intref, LicenseStatuses status)
        //{
        //    return SessionOriginal.QueryOver<License>().Where(x => x.IntrefNo == intref && x.LicenseStatus.ID == (int)status).List().FirstOrDefault();
        //}

        //public List<ApplicationDL> GetOpenApplicationsByIntref(string intref)
        //{
        //    List<ApplicationDL> openApps = SessionOriginal.QueryOver<ApplicationDL>().Where(x => x.ApplicationStatus.ID != (int)ApplicationStatuses.Collected).List().ToList();
        //    return openApps;
        //}

        //public List<ApplicationDTO> GetApplicationsByIntref(int intref)
        //{
        //    var res = SessionOriginal.QueryOver<ApplicationDL>().Where(x => x.IntrefNo == intref.ToString()).List().ToList();

        //    List<ApplicationDTO> dtoList = new List<ApplicationDTO>();
        //    ApplicationDTO dto;

        //    foreach (var item in res)
        //    {
        //        License activeLicnese = item.Licenses.SingleOrDefault(x => x.LicenseStatus.ID == (int)LicenseStatuses.Active && x.LicenseDocType != null && x.LicenseDocType.ID == (int)LicenseDocTypes.Regular);

        //        dto = new ApplicationDTO()
        //        {
        //            AppNo = item.AppNo,
        //            ApplicationType = item.ApplicationType,
        //            CurrentStatus = item.ApplicationStatus,
        //            RegistrationDate = item.RegistrationDate,
        //            IssueDate = activeLicnese != null ? activeLicnese.IssueDate : null,
        //            LastUpdate = item.DateUpdate,
        //            UserUpdate = item.UserUpdate
        //        };

        //        dtoList.Add(dto);
        //    }

        //    return dtoList;
        //}

        //public Location GetLocationByCode(int LocationCode)
        //{
        //    Location location = SessionOriginal.QueryOver<Location>().Where(x => x.ID == LocationCode).List().FirstOrDefault();

        //    return location;
        //}

        //#region private methods

        //private string GetNextAction(ApplicationStatus appStatus)
        //{
        //    List<string> screenNames = new List<string>();

        //    foreach (var dicItem in DicMenuApplicationStatus)
        //    {
        //        foreach (var item in dicItem.Value)
        //        {
        //            if ((int)item == appStatus.ID)
        //                screenNames.Add(dicItem.Key.Description);
        //        }
        //    }

        //    return string.Join(", ", screenNames);
        //}




        //#endregion

        #endregion
    }
}
