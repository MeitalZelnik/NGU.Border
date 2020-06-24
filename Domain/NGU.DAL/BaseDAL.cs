using NHibernate;
using Pangea.Hibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.BlackList.DAL
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

        public TEntity Get<TEntity>(object id) where TEntity : class
        {
            return Session.Get<TEntity>(id);
        }

        public TEntity Load<TEntity>(object id) where TEntity : class
        {
            return Session.Load<TEntity>(id);
        }

        public void Save<TEntity>(TEntity entity) where TEntity : class
        {
            Session.Save(entity);
        }

        public void SaveOrUpdate<TEntity>(TEntity entity) where TEntity : class
        {
            Session.SaveOrUpdate(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            Session.Update(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            Session.Delete(entity);
        }

        public void Evict(object entity)
        {
            Session.Evict(entity);
        }

        public IList<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return Session.CreateCriteria<TEntity>().List<TEntity>();
        }

        public ISQLQuery CreateSQLQuery(string sql)
        {
           return Session.CreateSQLQuery(sql);
        }
    }
}
