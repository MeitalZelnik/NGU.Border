using NGU.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGU.Core;
using NGU.Interfaces.Services;

namespace NGU.DAL
{
    public class PersonDAL : BaseDAL
    {
        public PersonDoc GetPersonDoc(int docType, string docNumber, int country)
        {
            return FindAll<PersonDoc>().FirstOrDefault(p => p.IdentityTypeID == docType &&
                                                            p.IdentityNum == docNumber &&
                                                            p.IdentityCountryID == country);
        }


    }
}
