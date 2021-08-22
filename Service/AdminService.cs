using System;
using RBAC.Model;
using RBAC.IRepository;
using RBAC.Service.Base;
using RBAC.IService;

namespace Service
{
    public class AdminService : BaseService<adminModel,int>, IAdminService
    {
        private IadminRepository repository;

        public AdminService(IadminRepository _repository)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
        }

        public override int Create(adminModel entity)
        {
            entity.CreateTime = DateTime.Now;
            return base.Create(entity);
        }
    }
}
