using NGU.Core;
using NGU.Enums;
using Pangea.Hibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using NGU.Interfaces.Repositories;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Pangea.Logger;

namespace NGU.Repositories
{
    public class SystemRepository : BaseRepository, ISystemRepository
    {
        public Tuple<List<Request>, int> SearchRequests(int maxResults, string firstName, string lastName, bool isPartial, DateTime? createdFrom, DateTime? createdTo, int? selectedIDTypeID, string iDNumber, int? selectedCountryID, string internalFileNo, string requestNo, int? requestTypeID, int? requestStatusID)
        {
            Tuple<List<Request>, int> res = null;
            List<Request> list = new List<Request>();
            int rowCount = 0;

            //ICriteria criteria = SystemDAL.SearchRequests(firstName, lastName, isPartial, createdFrom, createdTo, selectedIDTypeID, iDNumber, selectedCountryID, internalFileNo, requestNo, requestTypeID, requestStatusID);

            //rowCount = CriteriaTransformer.TransformToRowCount(criteria).FutureValue<int>().Value;

            //if (rowCount <= maxResults)
            //{
            //    list = criteria.List<Request>().ToList();


            //    var results = criteria.SetProjection(Projections.ProjectionList()
            //                                     .Add(Projections.Property(Request.Props.ID.ToString()), Request.Props.ID.ToString())
            //                                     .Add(Projections.Property(Request.Props.Num.ToString()), Request.Props.Num.ToString())
            //                                     .Add(Projections.Property(Request.Props.RequestType.ToString()), Request.Props.RequestType.ToString())
            //                                     .Add(Projections.Property(Request.Props.RequestStatus.ToString()), Request.Props.RequestStatus.ToString())
            //                                     .Add(Projections.Property(Request.Props.CreateDate.ToString()), Request.Props.CreateDate.ToString())
            //                                     .Add(Projections.Property(Request.Props.IdenTypeID.ToString()), Request.Props.IdenTypeID.ToString())
            //                                     .Add(Projections.Property(Request.Props.IdenNum.ToString()), Request.Props.IdenNum.ToString())
            //                                     .Add(Projections.Property(Request.Props.IdenCountryID.ToString()), Request.Props.IdenCountryID.ToString())
            //                                     .Add(Projections.Property(Request.Props.GivenNames.ToString()), Request.Props.GivenNames.ToString())
            //                                     .Add(Projections.Property(Request.Props.Surname.ToString()), Request.Props.Surname.ToString())
            //                                     .Add(Projections.Property(Request.Props.GenderID.ToString()), Request.Props.GenderID.ToString())
            //                                     .Add(Projections.Property(Request.Props.Institution.ToString()), Request.Props.Institution.ToString())
            //        ).SetResultTransformer(Transformers.AliasToBean<Request>()).List();
            //}

            //foreach (var req in list)
            //{
            //    Unproxy<Request>.UnproxyObject(req).IncludeAll().Execute();
            //}

            res = new Tuple<List<Request>, int>(list, rowCount);

            return res;
        }

        public Request GetRequest(int id)
        {
            Request req = SystemDAL.Get<Request>(id);
            Unproxy<Request>.UnproxyObject(req).IncludeAll().Execute();

            return req;
        }

        public string GenerateSequence(string seqName)
        {
            return SystemDAL.GenerateSequence(seqName);
        }

        public List<BiometricParameter> GetBiometricsParams()
        {
            var t = FindAll<ImageBiometric>().ToList();

            var bioParams = FindAll<BiometricParameter>();

            return bioParams.ToList();
        }
    }
}
