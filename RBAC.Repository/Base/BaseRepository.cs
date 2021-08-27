using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RBAC.IRepository.Base;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using RBAC.Model;
using System.Data;

namespace RBAC.Repository.Base
{
    /// <summary>
    /// 基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="Tkey"></typeparam>
    public abstract class BaseRepository<TEntity, Tkey> : IBaseRepository<TEntity, Tkey>
        where TEntity : class, new()
        where Tkey : struct
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        public IConfiguration configuration { get; set; }

        private const string ConnStr = "Mysql";

        public virtual int Create(TEntity entity)
        {
            string _connstr = configuration.GetConnectionString(ConnStr);

            using (MySqlConnection conn = new MySqlConnection(_connstr))
            {
                Type type = typeof(TEntity);

                PropertyInfo[] properties = type.GetProperties().Where(m => !m.GetCustomAttributes(typeof(KeyAttribute), true).Any() && m.GetValue(entity) != null).ToArray();

                //表名
                string TableName = type.Name.Replace("model", "", true, null);
                //字段集合
                List<string> fields = properties.Select(m => m.Name).ToList();
                //值集合
                List<string> values = properties.Select(m => "@" + m.Name).ToList();
                //接拼SQL
                string sql = $"INSERT INTO {TableName} ({string.Join(",", fields)}) VALUES({string.Join(",", values)})";

                return conn.Execute(sql, entity);
            }
        }

        public virtual int Delete(Tkey id)
        {
            Type type = typeof(TEntity);
            var key = type.GetProperties().Where(m => m.GetCustomAttributes(typeof(KeyAttribute), true).Any()).First();

            //表名
            string TableName = type.Name.Replace("model", "", true, null);

            string sql = $"delete from {TableName} where {key.Name} = @{key.Name}";

            TEntity entity = new TEntity();

            key.SetValue(entity, id);

            //menuModel menu = new menuModel();
            //menu.MenuID = 9;
            //DynamicParameters parameter = new DynamicParameters();
            //parameter.Add($"@{key}", id, DbType.Int32, ParameterDirection.Input);

            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                return conn.Execute(sql, entity);
            }
        }

        public virtual int Delete(Tkey[] idList)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(string where = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID获取单条实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetEntity(Tkey id)
        {
            Type type = typeof(TEntity);
            var key = type.GetProperties().Where(m => m.GetCustomAttributes(typeof(KeyAttribute), true).Any()).First();

            string TableName = type.Name.Replace("model", "", true, null);

            string sql = $"select * from {TableName} where {key.Name} = @{key.Name}";

            TEntity entity = new TEntity();

            key.SetValue(entity, id);

            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                return conn.QueryFirst<TEntity>(sql, entity);
            }
        }

        public virtual TEntity GetEntity(string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<TEntity> GetList(string where = null, string orderby = null)
        {
            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                Type type = typeof(TEntity);

                string TableName = type.Name.Replace("model", "", true, null);

                string sql = $"select * from {TableName}";

                if (!string.IsNullOrEmpty(where))
                    sql += where;

                if (!string.IsNullOrEmpty(orderby))
                    sql += orderby;

                return conn.Query<TEntity>(sql).ToList();
            }
        }

        public virtual (int, List<TEntity>) GetPage(int PageSize = 10, int PageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(TEntity entity)
        {
            string _connstr = configuration.GetConnectionString(ConnStr);

            using (MySqlConnection conn = new MySqlConnection(_connstr))
            {
                Type type = typeof(TEntity);

                PropertyInfo[] properties = type.GetProperties()
                    .Where(m => 
                    !m.GetCustomAttributes(typeof(KeyAttribute), true).Any()
                    &&
                    m.GetValue(entity) != null
                    ).ToArray();

                PropertyInfo key = type.GetProperties().Where(m => m.GetCustomAttributes(typeof(KeyAttribute), true).Any()).First();


                //表名
                string TableName = type.Name.Replace("model", "", true, null);
                //字段集合
                List<string> fields = properties.Select(m => m.Name).ToList();

                string sql = $"update {TableName} set {string.Join(',', fields.Select(m => $"{m} = @{m}"))} where {key.Name} = @{key.Name}";

                return conn.Execute(sql, entity);
            }
        }
    }
}
