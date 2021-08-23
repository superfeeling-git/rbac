using System;
using System.ComponentModel.DataAnnotations;

namespace RBAC.Model
{
    public class adminModel
    {
        #region 公共属性
        ///<Summary>
        /// 特性
        ///</Summary>
        [Key]
        public int AdminID { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string UserName { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string Password { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public DateTime LastLoginTime { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string LastLoginIP { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public DateTime CreateTime { get; set; }
        #endregion
    }
}
