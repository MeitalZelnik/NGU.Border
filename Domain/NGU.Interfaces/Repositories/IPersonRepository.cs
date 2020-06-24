using NGU.Core;
using NGU.Interfaces.ApiAdmin;
using NGU.Interfaces.Services;
using Pangea.Fingerprints.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Interfaces.Repositories
{
    public interface IPersonRepository : IBaseRepository
    {
        Person GetPersonByDoc(int docType, string docNumber, int country);
        void SavePersonBio(Person person, PersonDoc doc, Request req, List<ImageBiometric> images = null);
        List<ImageBiometric> GetPersonImages(Person person);
    }
}
