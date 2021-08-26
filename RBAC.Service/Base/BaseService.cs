using RBAC.IService.Base;
using System;
using System.Collections.Generic;
using System.Text;
using RBAC.IRepository.Base;
using RBAC.Model;

namespace RBAC.Service.Base
{
    public abstract class BaseService<TEntity, Tkey> : IBaseService<TEntity, Tkey>
        where TEntity : class, new()
        where Tkey : struct
    {
        protected IBaseRepository<TEntity, Tkey> BaseRepository;

        public virtual int Create(TEntity entity)
        {
            return BaseRepository.Create(entity);
        }

        public virtual int Delete(Tkey id)
        {
            return BaseRepository.Delete(id);
        }

        public virtual int Delete(Tkey[] idList)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntity(Tkey id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntity(string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<TEntity> GetList(string where = null, string orderby = null)
        {
            return BaseRepository.GetList(where, orderby);
        }

        public virtual (int, List<TEntity>) GetPage(int PageSize = 10, int PageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(TEntity entity)
        {
            return BaseRepository.Update(entity);
        }
    }
}
