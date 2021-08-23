using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.Model
{
    public class menuModel
    {
        #region 公共属性
        ///<Summary>
        /// 
        ///</Summary>
        public int MenuID { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string MenuName { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public string MenuLink { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public ushort IsShow { get; set; }
        ///<Summary>
        /// 
        ///</Summary>
        public int ParnetID { get; set; }
        #endregion
    }
}
