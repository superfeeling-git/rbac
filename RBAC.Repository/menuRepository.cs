using System;
using RBAC.Model;
using RBAC.Repository.Base;
using RBAC.IRepository;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;

namespace Repository
{
    public class menuRepository : BaseRepository<menuModel, int>, ImenuRepository
    {
        private IConfiguration _configuration;

        public menuRepository(IConfiguration __configuration)
        {
            this.configuration = __configuration;
            this._configuration = __configuration;
        }

        private const string ConnStr = "Mysql";
    }
}
