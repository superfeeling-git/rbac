using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using RBAC.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace RBAC.Model
{
    public class Menu : BaseDto
    {
        #region 公共属性
        ///<Summary>
        /// 
        ///</Summary>
        [Key]
        public int MenuID { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string MenuName { get; set; } = "空节点";
        ///<Summary>
        /// 
        ///</Summary>
        public string MenuLink { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public bool IsShow { get; set; } = false;
        ///<Summary>
        /// 
        ///</Summary>
        public int? ParnetID { get; set; }
        #endregion
    }
}
