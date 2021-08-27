using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.Model
{
    public class roleModel
    {
        #region 公共属性
        ///<Summary>
        /// 角色ID
        ///</Summary>
        public int RoleID { get; set; }
        ///<Summary>
        /// 角色名称
        ///</Summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 多个权限
        /// </summary>
        public List<menuModel> menuModel { get; set; }
        #endregion
    }
}
