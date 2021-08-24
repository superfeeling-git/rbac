using System;
using RBAC.Model;
using RBAC.Service.Base;
using RBAC.IService;
using RBAC.IRepository;

namespace RBAC.Service
{
    public class adminService : BaseService<adminModel,int>, IadminService
    {
        private IadminRepository repository;

        public adminService(IadminRepository _repository)
        {
            //继承——IadminRepository 赋值 IBaseRepository
            //protected，允许派生类访问
            this.BaseRepository = _repository;
            this.repository = _repository;
        }
    }
}
