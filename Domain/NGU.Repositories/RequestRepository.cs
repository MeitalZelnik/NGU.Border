using NGU.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGU.Core;
using Pangea.Hibernate;

namespace NGU.Repositories
{
    public class RequestRepository : BaseRepository, IRequestRepository
    {
        public string GenerateRequestNum()
        {
            return SystemDAL.GenerateSequence("REQUESTS_NUM_SEQ");
        }

        public Request GetReqByDoc(int docType, string docNumber, int country)
        {
            PersonDoc personDoc = PersonDAL.GetPersonDoc(docType, docNumber, country);

            if (personDoc != null && personDoc.Request != null)
            {
                Unproxy<PersonDoc>.UnproxyObject(personDoc).Include(p => p.Request).Execute();
                return personDoc.Request;
            }
            
            return null;
        }
    }
}
