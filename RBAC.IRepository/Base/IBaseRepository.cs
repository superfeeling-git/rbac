using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.IRepository.Base
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity:class,new()
        where TKey:struct
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Create(TEntity entity);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(TEntity entity);
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetList(string where = null, string orderby = null);
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity GetEntity(TKey key);
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int Delete(TKey key);
        /// <summary>
        /// 根据主键批量删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        int Delete(TKey[] key);
        /// <summary>
        /// 根据指定条件删除数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Delete(string where = null);
        /// <summary>
        /// 获取分页记录
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        (int,List<TEntity>) getPage(int PageIndex = 1,int PageSize = 10,string where = null);
    }
}
