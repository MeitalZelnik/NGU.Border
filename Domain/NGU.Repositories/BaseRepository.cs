using NGU.DAL;
using Pangea.Hibernate;
using Pangea.Utils;
using System.Collections.Generic;
using NGU.Interfaces.Repositories;
using System;
using Pangea.BaseStructures;
using Pangea.Extensions;
using System.Linq;

namespace NGU.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        #region members

        private BaseDAL _baseDAL;
        private UserDAL _userDAL;
        private PrinterDAL _printerDAL;
        private SystemDAL _systemDAL;
        private ValueObjectDAL _valueObjectDAL;
        private PersonDAL _personDAL;

        #endregion

        #region DAL props

        public BaseDAL BaseDAL
        {
            get
            {
                if (_baseDAL == null)
                    _baseDAL = new BaseDAL();

                return _baseDAL;
            }
        }

        public UserDAL UserDAL
        {
            get
            {
                if (_userDAL == null)
                    _userDAL = new UserDAL();

                return _userDAL;
            }
        }

        public PrinterDAL PrinterDAL
        {
            get
            {
                if (_printerDAL == null)
                    _printerDAL = new PrinterDAL();

                return _printerDAL;
            }
        }

        public SystemDAL SystemDAL
        {
            get
            {
                if (_systemDAL == null)
                    _systemDAL = new SystemDAL();

                return _systemDAL;
            }
        }

        public ValueObjectDAL ValueObjectDAL
        {
            get
            {
                if (_valueObjectDAL == null)
                    _valueObjectDAL = new ValueObjectDAL();

                return _valueObjectDAL;
            }
        }

        public PersonDAL PersonDAL
        {
            get
            {
                if (_personDAL == null)
                    _personDAL = new PersonDAL();

                return _personDAL;
            }
        }

        #endregion

        public TEntity Get<TEntity>(object id) where TEntity : ObjectValidationBase
        {
            Check.Require(id != null, "id is null");

            TEntity entity = BaseDAL.Get<TEntity>(id);

            Unproxy<TEntity>.UnproxyObject(entity).IncludeAll().Execute();

            return entity;
        }

        public TEntity Load<TEntity>(object id) where TEntity : ObjectValidationBase
        {
            Check.Require(id != null, "id is null");

            TEntity entity = BaseDAL.Load<TEntity>(id);

            return entity;
        }

        public IList<TEntity> FindAll<TEntity>() where TEntity : ObjectValidationBase
        {
            IList<TEntity> list = null;
            list = BaseDAL.FindAll<TEntity>();
            Unproxy<TEntity>.UnproxyCollection(list).IncludeAll().Execute();

            return list;
        }

        public void Save<TEntity>(IList<TEntity> entities) where TEntity : ObjectValidationBase
        {
            Check.Require(entities != null, "list is null");

            UnitOfWork.Transaction((delegate ()
            {
                entities.AsParallel().ForEach((entity) =>
                {
                    BaseDAL.Save(entity);
                });
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="action">Action to do after create the raw on the DB before the commit.</param>
        public void Save<TEntity>(TEntity entity, Func<bool> actionBeforeCommit = null) where TEntity : ObjectValidationBase
        {
            Check.Require(entity != null, "entity is null");

            UnitOfWork.Transaction(delegate ()
            {
                BaseDAL.Save(entity);
            }, actionBeforeCommit);
        }

        public void SaveOrUpdate<TEntity>(TEntity entity, Func<bool> actionBeforeCommit = null) where TEntity : ObjectValidationBase
        {
            Check.Require(entity != null, "entity is null");

            UnitOfWork.Transaction((delegate ()
            {
                BaseDAL.SaveOrUpdate(entity);
            }));
        }

        public void SaveOrUpdate<TEntity>(IList<TEntity> entities) where TEntity : ObjectValidationBase
        {
            Check.Require(entities != null, "list is null");

            UnitOfWork.Transaction((delegate ()
            {
                entities.AsParallel().ForEach((entity) =>
                {
                    BaseDAL.SaveOrUpdate(entity);
                });
            }));
        }

        public void Update<TEntity>(TEntity entity, Func<bool> actionBeforeCommit = null) where TEntity : ObjectValidationBase
        {
            Check.Require(entity != null, "entity is null");

            UnitOfWork.Transaction((delegate ()
            {
                BaseDAL.Update(entity);
            }));
        }

        public void Delete<TEntity>(TEntity entity, Func<bool> actionBeforeCommit = null) where TEntity : ObjectValidationBase
        {
            Check.Require(entity != null, "entity is null");

            UnitOfWork.Transaction((delegate ()
            {
                BaseDAL.Delete(entity);
            }));
        }

        public void Evict(object entity)
        {
            BaseDAL.Evict(entity);
        }
    }
}