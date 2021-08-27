using RBAC.IService;
using RBAC.Model;
using RBAC.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.Service
{
    public class roleService : BaseService<Role, int>, IroleService
    {
    }
}
