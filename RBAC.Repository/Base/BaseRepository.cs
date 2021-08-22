using RBAC.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace RBAC.Repository.Base
{
    /// <summary>
    /// 抽象基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, new()
        where TKey : struct
    {
        protected string Connstr;

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Create(TEntity entity)
        {
            using (MySqlConnection conn = new MySqlConnection(Connstr))
            {
                Type type = entity.GetType();
                List<PropertyInfo> key = type.GetProperties().Where(m => !m.GetCustomAttributes(typeof(KeyAttribute),true).Any()).ToList();
                string sql = $"INSERT INTO {type.Name.Replace("model", "", true, null)} ({string.Join(',', key.Select(m => m.Name))}) VALUES({string.Join(',', key.Select(m => "@" + m.Name))})";
                return conn.Execute(sql, entity);
            }
        }

        public virtual int Delete(TKey key)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(TKey[] key)
        {
            throw new NotImplementedException();
        }

        public int Delete(string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntity(TKey key)
        {
            throw new NotImplementedException();
        }

        public virtual List<TEntity> GetList(string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual (int, List<TEntity>) getPage(int PageIndex = 1, int PageSize = 10, string where = null)
        {
            throw new NotImplementedException();
        }

        public virtual int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
