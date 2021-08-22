using System;
using Microsoft.Extensions.Configuration;
using RBAC.Model;
using RBAC.Repository.Base;
using RBAC.IRepository;

namespace RBAC.Repository
{
    public class adminRepository : BaseRepository<adminModel,int>, IadminRepository
    {
        public adminRepository(IConfiguration _configuration)
        {
            this.Connstr = _configuration.GetConnectionString("MySql");
        }
    }
}
