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
using System.ComponentModel.DataAnnotations.Schema;

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
        /// 反射程序集类型
        /// </summary>
        private Type type = typeof(TEntity);

        /// <summary>
        /// 主键信息
        /// </summary>
        private PropertyInfo key = typeof(TEntity).GetProperties().Where(m => m.GetCustomAttributes(typeof(KeyAttribute), true).Any()).First();

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string ConnStr = "MySql";

        /// <summary>
        /// 属性注入
        /// </summary>
        public IConfiguration configuration { get; set; }

        
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="TEntityDto"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Create<TEntityDto>(TEntityDto entity)
        {
            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                PropertyInfo[] properties = entity.GetType().GetProperties().Where(m => 
                !m.GetCustomAttributes(typeof(KeyAttribute), true).Any()
                && !m.GetCustomAttributes(typeof(NotMappedAttribute), true).Any()
                && m.GetValue(entity) != null).ToArray();

                //字段集合
                List<string> fields = properties.Select(m => m.Name).ToList();
                //值集合
                List<string> values = properties.Select(m => "@" + m.Name).ToList();
                //接拼SQL
                string sql = $"INSERT INTO {type.Name} ({string.Join(",", fields)}) VALUES({string.Join(",", values)})";

                return conn.Execute(sql, entity);
            }
        }

        /// <summary>
        /// 单条删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual int Delete(Tkey id)
        {
            string sql = $"delete from {type.Name} where {key.Name} = @{key.Name}";

            TEntity entity = new TEntity();

            key.SetValue(entity, id);

            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                return conn.Execute(sql, entity);
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public virtual int Delete(Tkey[] idList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
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
            string sql = $"select * from {type.Name} where {key.Name} = @{key.Name}";

            TEntity entity = new TEntity();

            key.SetValue(entity, id);

            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                return conn.QueryFirst<TEntity>(sql, entity);
            }
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual TEntity GetEntity(string where = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public virtual List<TEntity> GetList(string where = null, string orderby = null)
        {
            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                string sql = $"select * from {type.Name}";

                if (!string.IsNullOrEmpty(where))
                    sql += where;

                if (!string.IsNullOrEmpty(orderby))
                    sql += orderby;

                return conn.Query<TEntity>(sql).ToList();
            }
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public virtual (int, List<TEntity>) GetPage(int PageSize = 10, int PageIndex = 1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <typeparam name="TEntityDto"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>

        public virtual int Update<TEntityDto>(TEntityDto entity)
        {
            using (MySqlConnection conn = new MySqlConnection(configuration.GetConnectionString(ConnStr)))
            {
                PropertyInfo[] properties = entity.GetType().GetProperties()
                    .Where(m => 
                    !m.GetCustomAttributes(typeof(KeyAttribute), true).Any()
                    && !m.GetCustomAttributes(typeof(NotMappedAttribute), true).Any()
                    && m.GetValue(entity) != null
                    ).ToArray();

                //字段集合
                List<string> fields = properties.Select(m => m.Name).ToList();

                string sql = $"update {type.Name} set {string.Join(',', fields.Select(m => $"{m} = @{m}"))} where {key.Name} = @{key.Name}";

                return conn.Execute(sql, entity);
            }
        }
    }
}
