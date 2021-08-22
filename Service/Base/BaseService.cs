using RBAC.IService.Base;
using System;
using System.Collections.Generic;
using System.Text;
using RBAC.IRepository;
using RBAC.IRepository.Base;

namespace RBAC.Service.Base
{
    public abstract class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey>
        where TEntity : class, new()
        where TKey : struct
    {
        protected IBaseRepository<TEntity, TKey> baseRepository;

        public virtual int Create(TEntity entity)
        {
            return baseRepository.Create(entity);
        }

        public virtual int Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(TKey[] key)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntity(TKey key)
        {
            throw new NotImplementedException();
        }

        public virtual List<TEntity> GetList(string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual (int, List<TEntity>) getPage(int PageIndex = 1, int PageSize = 10, string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
