using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RBAC.Model
{
    public class menuModel
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
