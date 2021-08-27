using System;
using RBAC.Model;
using RBAC.Service.Base;
using RBAC.IService;
using RBAC.IRepository;

namespace RBAC.Service
{
    public class adminService : BaseService<Admin,int>, IadminService
    {
        private IadminRepository repository;

        public adminService(IadminRepository _repository)
        {
            this.BaseRepository = _repository;
            this.repository = _repository;
        }
    }
}