using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.IService.Base
{
    public interface IBaseService<TEntity, Tkey>
        where TEntity : class, new()
        where Tkey : struct
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Create<TEntityDto>(TEntityDto entity);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update<TEntityDto>(TEntityDto entity);
        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(Tkey id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        int Delete(Tkey[] idList);
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Delete(string where = null);
        /// <summary>
        /// 根据条件获取列表数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<TEntity> GetList(string where = null, string orderby = null);
        /// <summary>
        /// 根据主键获取单条实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetEntity(Tkey id);
        /// <summary>
        /// 根据条件获取单条实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        TEntity GetEntity(string where = null);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        (int, List<TEntity>) GetPage(int PageSize = 10, int PageIndex = 1);
    }
}
