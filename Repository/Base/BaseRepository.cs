﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RBAC.IRepository.Base;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

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

                PropertyInfo[] properties = type.GetProperties().Where(m => !m.GetCustomAttributes(typeof(KeyAttribute), true).Any()).ToArray();

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
            PropertyInfo[] properties = type.GetProperties().Where(m => m.GetCustomAttributes(typeof(KeyAttribute), true).Any()).ToArray();

            //表名
            string TableName = type.Name.Replace("model", "", true, null);
            string sql = $"delete from {type.Name} where {properties.First().Name} = @{properties.First().Name}";
            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                return conn.Execute(sql, id);
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

        public virtual TEntity GetEntity(Tkey id)
        {
            throw new NotImplementedException();
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

                string sql = $"select * from {type.Name}";

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
            throw new NotImplementedException();
        }
    }
}