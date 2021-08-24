using System;
using System.Collections.Generic;
using System.Text;
using RBAC.IService.Base;
using RBAC.Model;

namespace RBAC.IService
{
    public interface IMenuService:IBaseService<menuModel, int>
    {
        new List<treeModel> GetList(string where = null);
    }
}
