using System;
using System.Collections.Generic;
using System.Text;
using RBAC.IRepository.Base;
using RBAC.Model;

namespace RBAC.IRepository
{
    public interface ImenuRepository:IBaseRepository<menuModel, int>
    {
    }
}
