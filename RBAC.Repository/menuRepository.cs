using System;
using RBAC.Model;
using RBAC.Repository.Base;
using RBAC.IRepository;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class menuRepository : BaseRepository<menuModel, int>, ImenuRepository
    {
    }
}
