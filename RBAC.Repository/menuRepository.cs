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
        /// <summary>
        /// 属性注入
        /// </summary>
        public IConfiguration _configuration { get; set; }

        private const string ConnStr = "Mysql";

        public int UpdateNode(menuModel menuModel)
        {
            string _connstr = _configuration.GetConnectionString(ConnStr);

            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                return conn.Execute("UPDATE menu SET MenuName = @MenuName,MenuLink = @MenuLink, IsShow = @IsShow WHERE MenuID = @MenuID", menuModel);
            }
        }
    }
}
