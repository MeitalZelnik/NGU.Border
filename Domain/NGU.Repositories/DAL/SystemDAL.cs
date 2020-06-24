using NGU.Core;
using System.Collections.Generic;
using System.Linq;
using System;
using Pangea.Extensions;
using NHibernate;
using NHibernate.Criterion;

namespace NGU.DAL
{
    public class SystemDAL : BaseDAL
    {
        private void NamesParameters(ICriteria criteria, string firstName, string lastName, bool isPartial)
        {
            //if (isPartial)
            //{
            //    if (!lastName.IsNullOrEmpty())
            //        criteria.Add(Restrictions.Disjunction().Add(Restrictions.InsensitiveLike(Request.Props.PrimarySurname, lastName, MatchMode.Anywhere))
            //                                     .Add(Restrictions.InsensitiveLike(Request.Props.SecondSurname, lastName, MatchMode.Anywhere))
            //                                     .Add(Restrictions.InsensitiveLike(Request.Props.Surname, lastName, MatchMode.Anywhere)));


            //    if (!firstName.IsNullOrEmpty())
            //        criteria.Add(Restrictions.Disjunction().Add(Restrictions.InsensitiveLike(Request.Props.PrimaryName, firstName, MatchMode.Anywhere))
            //                                     .Add(Restrictions.InsensitiveLike(Request.Props.SecondName, firstName, MatchMode.Anywhere))
            //                                     .Add(Restrictions.InsensitiveLike(Request.Props.GivenNames, firstName, MatchMode.Anywhere)));
            //}
            //else
            //{
            //    if (!lastName.IsNullOrEmpty())
            //        criteria.Add(Restrictions.Disjunction().Add(Restrictions.Eq(Request.Props.Surname, lastName)));

            //    if (!firstName.IsNullOrEmpty())
            //        criteria.Add(Restrictions.Disjunction().Add(Restrictions.Eq(Request.Props.GivenNames, firstName)));

            //    //if (!lastName.IsNullOrEmpty())
            //    //    criteria.Add(Restrictions.Disjunction().Add(Restrictions.Eq(Request.Props.PrimarySurname, lastName))
            //    //                                            .Add(Restrictions.Eq(Request.Props.SecondSurname, lastName))
            //    //                                            .Add(Restrictions.Eq(Request.Props.Surname, lastName)));

            //    //if (!firstName.IsNullOrEmpty())
            //    //    criteria.Add(Restrictions.Disjunction().Add(Restrictions.Eq(Request.Props.PrimaryName, firstName))
            //    //                                           .Add(Restrictions.Eq(Request.Props.SecondName, firstName))
            //    //                                           .Add(Restrictions.Eq(Request.Props.GivenNames, firstName)));
            //}
        }

        private void DateParameters(ICriteria criteria, DateTime? createdFrom, DateTime? createdTo)
        {
            if (createdFrom.HasValue)
            {
                DateTime from = createdFrom.Value.Date;
                criteria.Add(Restrictions.Ge(Request.Props.CreateDate.ToString(), from));
            }

            if (createdTo.HasValue)
            {
                DateTime to = createdTo.Value.Date.AddDays(1).AddSeconds(-1);
                criteria.Add(Restrictions.Le(Request.Props.CreateDate.ToString(), to));
            }
        }

        private void IdentifierParameters(ICriteria criteria, int? selectedIDTypeID, string iDNumber, int? selectedCountryID)
        {
            if (selectedIDTypeID.HasValue)
                criteria.Add(Restrictions.Eq(Request.Props.IdenTypeID.ToString(), selectedIDTypeID.Value));

            if (!iDNumber.IsNullOrEmpty())
                criteria.Add(Restrictions.Eq(Request.Props.IdenNum.ToString(), iDNumber));

            if (selectedCountryID.HasValue)
                criteria.Add(Restrictions.Eq(Request.Props.IdenCountryID.ToString(), selectedCountryID.Value));

        }

        private void IDParameters(ICriteria criteria, string internalFileNo, string requestNo, int? requestTypeID, int? requestStatusID)
        {
            //if (!internalFileNo.IsNullOrEmpty())
            //    criteria.Add(Restrictions.Eq(Request.Props.FileNumber.ToString(), internalFileNo));

            //if (!requestNo.IsNullOrEmpty())
            //    criteria.Add(Restrictions.Eq(Request.Props.Num.ToString(), requestNo));

            //if (requestTypeID.HasValue)
            //    criteria.Add(Restrictions.Eq(Request.Props.RequestType.ID.ToString(), requestTypeID.Value));

            //if (requestStatusID.HasValue)
            //    criteria.Add(Restrictions.Eq(Request.Props.RequestStatus.ID.ToString(), requestStatusID.Value));
        }

        public ICriteria SearchRequests(string firstName, string lastName, bool isPartial, DateTime? createdFrom, DateTime? createdTo, int? selectedIDTypeID, string iDNumber, int? selectedCountryID, string internalFileNo, string requestNo, int? requestTypeID, int? requestStatusID)
        {
            ICriteria criteria = Session.CreateCriteria<Request>().Add(Restrictions.IsNotNull(Request.Props.Num));

            //todo: difference between request and blacklist

            NamesParameters(criteria, firstName, lastName, isPartial);
            DateParameters(criteria, createdFrom, createdTo);
            IdentifierParameters(criteria, selectedIDTypeID, iDNumber, selectedCountryID);
            IDParameters(criteria, internalFileNo, requestNo, requestTypeID, requestStatusID);

            return criteria;
        }

        public string GenerateSequence(string seqName)
        {
            string sql = string.Format("SELECT {0}.NEXTVAL FROM DUAL", seqName);

            var query = base.CreateSQLQuery(sql);

            string res = query.UniqueResult().ToString();

            return res;
        }
    }
}
