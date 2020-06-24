using NGU.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGU.Core;
using Pangea;
using NGU.Interfaces.Repositories;
using Pangea.Logger;
using System.Data.OracleClient;
using System.Data;
using System.Reflection;
using Pangea.Neurotech;
using Pangea.Fingerprints.Interfaces;
using Pangea.Network;
using NGU.Services.AbisService;
using Neurotec.Biometrics;
using Neurotec.IO;
using NGU.Interfaces.Exceptions;
using NGU.Enums;
using System.ServiceModel;
using Pangea.Extensions;

namespace NGU.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PersonService : BaseService, IPersonService
    {
        #region Data Members
        private readonly IPersonRepository _personRepository = IoC.Instance.Resolve<IPersonRepository>();
        private readonly AbisServiceClient _abisSerivce = WcfHelper.CreateWCFClientByConfig<AbisServiceClient>("NGU.Abis.Server");
        private object _generateIdLock = new object();
        #endregion

        #region Public methods

        public Person GetPerson(int ID)
        {
            return _personRepository.Get<Person>(ID);
        }

        public PersonDoc GetPersonDoc(int ID)
        {
            return _personRepository.Get<PersonDoc>(ID);
        }

        public Person SearchPersonByDoc(int docType, string docNumber, int country)
        {
            Log.Debug($"Params: type={docType}, number={docNumber}, country={country}");
            Person person = _personRepository.GetPersonByDoc(docType, docNumber, country);

            if (person != null)
                AddImages(person);

            Log.Info($"Person is found: {person != null}");
            return person;
        }

        public void SaveImage(long requestId, int userId, ImageTypes imageType, byte[] image)
        {
            Log.Debug($"Request ID : {requestId}, image type: {imageType}");

            ImageBiometric imageBiometric = new ImageBiometric
            {
                IsWaived = image == null,
                CreateUserID = userId,
                Request = new Request { ID = requestId }, /*reduce database roundtrip*/
                UpdateUserID = userId,
                Image = image,
                ImageType = new ImageType { ID = (int)imageType },/*reduce database roundtrip*/
            };

            _personRepository.SaveOrUpdate<ImageBiometric>(imageBiometric);

            Log.Info($"Image {imageType} saved");
        }

        public void SaveFingerprints(long requestId, int userId, Dictionary<FPIndexes, byte[]> fingersData)
        {
            Log.Debug($"Request ID : {requestId}");

            List<ImageBiometric> images = new List<ImageBiometric>();
            Request request = new Request { ID = requestId };
            DateTime now = DateTime.Now;

            LicenseHelper.ObtainFingerLicenses();
            if (LicenseHelper.LicenseObtained)
            {
                var fingersTemplates = NFingerHelper.GetFingersTemplate(fingersData);
                //images = _personRepository.FindAll<ImageBiometric>().Where(i => i.Request.ID == request.ID && i.ImageType.ID <= 10).ToList();
                
                foreach (var fd in fingersData)
                {
                    ImageBiometric imageBiometric = _personRepository.FindAll<ImageBiometric>().FirstOrDefault(i => i.Request.ID == request.ID &&
                                                                                                                    i.ImageType.ID == (int)fd.Key);

                    if (imageBiometric == null)
                        imageBiometric = new ImageBiometric
                        {
                            CreateDate = now,
                            Request = request, /*reduce database roundtrip*/
                            ImageType = new ImageType { ID = (int)fd.Key }/*reduce database roundtrip*/
                        };



                    imageBiometric.UpdateDate = now;
                    imageBiometric.CreateUserID = userId;
                    imageBiometric.UpdateUserID = userId;
                    imageBiometric.IsWaived = fd.Value == null;
                    imageBiometric.Image = fd.Value;
                    imageBiometric.Template = fingersTemplates.ContainsKey(fd.Key) ? fingersTemplates[fd.Key] : null;
                        
                    images.Add(imageBiometric);
                }
                
            }

            _personRepository.SaveOrUpdate<ImageBiometric>(images);

            Log.Info($"Fingerprints are saved");
        }



        public PangeaBiometricStatus Enroll(long requestId, int userId)
        {
            var req = _personRepository.Get<Request>(requestId);
            var images = _personRepository.FindAll<ImageBiometric>().Where(x => x.Request.ID == requestId).ToList();

            if (req == null)
                throw new ServiceException($"Request {requestId} not found");
            if (req.Person != null) // TODO: if has person do not create him
                throw new ServiceException($"Request {requestId} already has a person");
            else
            {
                Person person = CreatePerson(req, userId);

                if (images.All(image => image.IsWaived.HasValue && image.IsWaived.Value))
                {
                    SaveNewPerson(userId, req, person);
                    return PangeaBiometricStatus.Ok;
                }
                else
                {
                    MatchingResult result = SendToAfis(person.ID.ToString(), images);

                    if (result.Status == PangeaBiometricStatus.DuplicateFound)
                        HandleDuplicate(result, person, req, userId);
                    else
                        SaveNewPerson(userId, req, person, images);

                    return result.Status;
                }
            }
        }

        #endregion

        #region Private methods

        private void AddImages(Person person)
        {
            var images = _personRepository.GetPersonImages(person);

            var fingers = images.Where(i => i.ImageType.ID > 0 && i.ImageType.ID <= 10);
            person.Fingers = fingers.ToDictionary(k => k.ImageType.ID.ParseEnum<FPIndexes>(), v => v.Image);

            person.Signature = images.FirstOrDefault(i => i.ImageType.ID == (int)ImageTypes.Signature)?.Image;
            person.Photo = images.FirstOrDefault(i => i.ImageType.ID == (int)ImageTypes.Photo)?.Image;
        }

        private void SaveNewPerson(int userId, Request req, Person person, List<ImageBiometric> images = null)
        {
            PersonDoc doc = CreatePersonDoc(req, person, userId);
            images?.ForEach(image => image.Person = person);
            UpdateRequset(req, person, userId, RequestStatuses.Completed);
            _personRepository.SavePersonBio(person, doc, req, images);
        }

        private MatchingResult SendToAfis(string id, List<ImageBiometric> images)
        {
            List<byte[]> templates = images.Where(i => i.ImageType.ID > 0 && 
                                                       i.ImageType.ID <= 10 && 
                                                       (!i.IsWaived.HasValue || !i.IsWaived.Value)).Select(x => x.Template).ToList();
            var subject = NFingerHelper.GetSubject(templates);
            MatchingResult result = null;

            try
            {
                // Send to Abis
                result = _abisSerivce.Enroll(subject, id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Delete Biometric from Abis");
                _abisSerivce.Delete(id);
                result = new MatchingResult() { Status = PangeaBiometricStatus.InternalError };
            }

            return result;
        }

        private void HandleDuplicate(MatchingResult result, Person person, Request req, int userId)
        {
            var matchPerson = _personRepository.Get<Person>(long.Parse(result.MatchingList.FirstOrDefault().id));
            if (ComparePersons(person, matchPerson))
            {
                UpdateRequset(req, matchPerson, userId, RequestStatuses.Completed);
                PersonDoc newDoc = CreatePersonDoc(req, matchPerson, userId);
                _personRepository.SavePersonBio(matchPerson, newDoc, req);
                result.Status = PangeaBiometricStatus.Ok;
            }
            else 
            {
                UpdateRequset(req, null, userId, RequestStatuses.Investigation);
                _personRepository.SaveOrUpdate(req);
            }
        }

        private bool ComparePersons(Person person, Person matchPerson)
        {
            return person.BirthDate == matchPerson.BirthDate &&
                   person.FirstName == matchPerson.FirstName &&
                   person.LastName == matchPerson.LastName &&
                   person.MiddleName == matchPerson.MiddleName &&
                   person.NationalityID == matchPerson.NationalityID &&
                   person.StatusID == matchPerson.StatusID;
        }

        private void UpdateRequset(Request req, Person person, int userId, RequestStatuses status)
        {
            req.Person = person;
            req.StatusDate = DateTime.Now;
            req.RequestStatus = new RequestStatus() { ID = (int)status };
            req.UpdateUserID = userId;
        }

        private PersonDoc CreatePersonDoc(Request req, Person person, int userId)
        {
            var doc = new PersonDoc()
            {
                Person = person,
                Request = req,
                IdentityNum = req.IdenNum,
                IdentityTypeID = req.IdenTypeID,
                IdentityCountryID = req.IdenCountryID.HasValue ? req.IdenCountryID.Value : 0,
                IsActiveRecord = true,
                UpdateUserID = userId,
                CreateUserID = userId
            };

            return doc;
        }

        private long GenerateuniqueID() 
        {
            lock (_generateIdLock)
            {
                return DateTimeOffset.Now.ToUnixTimeMilliseconds(); 
            }
        }

        private Person CreatePerson(Request req, long userId)
        {
            Person person = new Person()
            {
                ID = GenerateuniqueID(),
                BirthDate = req.BirthDate,
                FirstName = req.FirstName,
                MiddleName = req.MiddleName,
                LastName = req.LastName,
                //CreateDate = createDate,
                GenderID = req.GenderID,
                NationalityID = req.DocNationalityID,
                CreateUserID = userId,
                UpdateUserID = userId
            };

            return person;
        }

        #endregion
    }
}
