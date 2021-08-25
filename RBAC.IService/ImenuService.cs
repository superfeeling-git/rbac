using System;
using RBAC.Model;
using RBAC.IService.Base;
using System.Collections.Generic;

namespace RBAC.IService
{
    public interface ImenuService : IBaseService<menuModel, int>
    {
        /// <summary>
        /// 递归获取所有的菜单
        /// </summary>
        /// <returns></returns>
        List<treemodel> GetNodes();
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        int CreateMenu(treemodel treemodel);
        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <returns></returns>
        int UpdateMenu(treemodel treemodel);
    }
}