using NGU.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGU.Core;
using NGU.Interfaces.ApiAdmin;
using Pangea.Hibernate;
using NGU.Interfaces.Services;
using NGU.Enums;
using Pangea.Logger;
using System.Transactions;
using NGU.Interfaces.Exceptions;
using Pangea.Extensions;

namespace NGU.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public Person GetPersonByDoc(int docType, string docNumber, int country)
        {
            PersonDoc personDoc = PersonDAL.GetPersonDoc(docType, docNumber, country);

            if (personDoc != null && personDoc.Person != null)
            {
                Unproxy<PersonDoc>.UnproxyObject(personDoc).Include(p => p.Person).Execute();
                return personDoc.Person;
            }
            
            return null;
        }

        public List<ImageBiometric> GetPersonImages(Person person)
        {
            var res = BaseDAL.FindAll<ImageBiometric>().Where(i => i.Person?.ID == person.ID).ToList();
            Unproxy<ImageBiometric>.UnproxyCollection(res).Include(x => x.ImageType).Execute();
            return res;
        }

        public void SavePersonBio(Person person, PersonDoc doc, Request req, List<ImageBiometric> images = null)
        {
            UnitOfWork.Transaction(delegate ()
            {
                BaseDAL.SaveOrUpdate(person);
                BaseDAL.Save(doc);
                
                images?.AsParallel().ForEach((imgae) =>
                {
                    BaseDAL.Update(imgae);
                });

                BaseDAL.Update(req);
            });
        }
    }
}
