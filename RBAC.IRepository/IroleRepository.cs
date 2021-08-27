using RBAC.IRepository.Base;
using RBAC.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.IRepository
{
    public interface IroleRepository : IBaseRepository<Role, int>
    {
    }
}
