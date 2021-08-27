using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using RBAC.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace RBAC.Model
{
    public class Role : BaseDto
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
        public List<Menu> menuModel { get; set; }
        #endregion
    }
}
