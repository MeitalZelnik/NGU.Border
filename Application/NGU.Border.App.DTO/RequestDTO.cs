using NGU.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.App.DTO
{
    public class RequestDTO : DTOBase
    {
        public int ID { get; set; }
        public string Num { get; set; }
        public string RequestTypeName { get; set; }
        public string RequestStatusName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string IdenTypeName { get; set; }
        public string IdenNum { get; set; }
        public string IdenCountryName { get; set; }
        public string GivenNames { get; set; }
        public string Surname { get; set; }
        public string GenderName { get; set; }
        public string InstitutionName { get; set; }
    }
}

