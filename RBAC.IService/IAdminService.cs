using System;
using System.Collections.Generic;
using System.Text;
using RBAC.Model;
using RBAC.IService.Base;

namespace RBAC.IService
{
    public interface IAdminService : IBaseService<adminModel, int>
    {
    }
}
