using RBAC.IService;
using RBAC.Model;
using RBAC.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.Service
{
    public class roleService : BaseService<roleModel, int>, IroleService
    {
        public override int Create(roleModel entity)
        {
            //中间表

            return base.Create(entity);
        }
    }
}
