using System;
using RBAC.Model;
using RBAC.IService.Base;
using System.Collections.Generic;

namespace RBAC.IService
{
    public interface ImenuService : IBaseService<menuModel, int>
    {
        List<treemodel> GetNodes();
    }
}