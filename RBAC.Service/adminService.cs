using System;
using RBAC.Model;
using RBAC.Service.Base;
using RBAC.IService;

namespace RBAC.Service
{
    public class adminService : BaseService<adminModel,int>, IadminService
    {

    }
}
