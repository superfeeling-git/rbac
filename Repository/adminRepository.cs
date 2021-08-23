using System;
using RBAC.Model;
using RBAC.Repository.Base;
using RBAC.IRepository;

namespace Repository
{
    public class adminRepository : BaseRepository<adminModel, int>, IadminRepository
    {
    }
}
