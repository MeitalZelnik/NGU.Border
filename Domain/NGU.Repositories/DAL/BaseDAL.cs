using NHibernate;
using Pangea.BaseStructures;
using Pangea.Hibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.DAL
{
    public class BaseDAL
    {
        protected ISession Session
        {
            get
            {
                return UnitOfWork.Session;
            }
        }

        public TEntity Get<TEntity>(object id) where TEntity : ObjectValidationBase
        {
            return Session.Get<TEntity>(id);
        }

        public TEntity Load<TEntity>(object id) where TEntity : ObjectValidationBase
        {
            return Session.Load<TEntity>(id);
        }

        public void Save<TEntity>(TEntity entity) where TEntity : ObjectValidationBase
        {
            Session.Save(entity);
        }

        public void SaveOrUpdate<TEntity>(TEntity entity) where TEntity : ObjectValidationBase
        {
            Session.SaveOrUpdate(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : ObjectValidationBase
        {
            Session.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : ObjectValidationBase
        {
            Session.Delete(entity);
        }

        public void Evict(object entity)
        {
            Session.Evict(entity);
        }

        public IList<TEntity> FindAll<TEntity>() where TEntity : ObjectValidationBase
        {
            return Session.CreateCriteria<TEntity>().List<TEntity>();
        }

        protected ISQLQuery CreateSQLQuery(string sql)
        {
           return Session.CreateSQLQuery(sql);
        }
    }
}
