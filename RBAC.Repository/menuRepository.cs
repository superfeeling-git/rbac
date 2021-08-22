using System;
using System.Collections.Generic;
using System.Text;
using RBAC.IRepository;
using RBAC.Repository.Base;
using RBAC.Model;
using Microsoft.Extensions.Configuration;

namespace RBAC.Repository
{
    public class menuRepository : BaseRepository<menuModel,int>, ImenuRepository
    {
    }
}
