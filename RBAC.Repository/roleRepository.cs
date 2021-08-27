using RBAC.IRepository;
using RBAC.Model;
using RBAC.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.Repository
{
    public class roleRepository : BaseRepository<roleModel, int>, IroleRepository
    {
    }
}
