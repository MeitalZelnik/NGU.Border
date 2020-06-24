using Pangea.BaseStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        TEntity Get<TEntity>(object id) where TEntity : ObjectValidationBase;

        TEntity Load<TEntity>(object id) where TEntity : ObjectValidationBase;

        IList<TEntity> FindAll<TEntity>() where TEntity : ObjectValidationBase;

        void Save<TEntity>(IList<TEntity> entities) where TEntity : ObjectValidationBase;

        void Save<TEntity>(TEntity entity, Func<bool> actionBeforeCommit = null) where TEntity : ObjectValidationBase;

        void SaveOrUpdate<TEntity>(TEntity entity, Func<bool> actionBeforeCommit = null) where TEntity : ObjectValidationBase;

        void SaveOrUpdate<TEntity>(IList<TEntity> entities) where TEntity : ObjectValidationBase;

        void Update<TEntity>(TEntity entity, Func<bool> actionBeforeCommit = null) where TEntity : ObjectValidationBase;

        void Delete<TEntity>(TEntity entity, Func<bool> actionBeforeCommit = null) where TEntity : ObjectValidationBase;

        void Evict(object entity);
    }
}
