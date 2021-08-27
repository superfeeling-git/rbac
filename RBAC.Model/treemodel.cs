using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.Model
{
    public class treemodel
    {
        /// <summary>
        /// 节点标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 节点ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 节点字段
        /// </summary>
        public string field { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public List<treemodel> children { get; set; } = new List<treemodel>();
        /// <summary>
        /// 是否展开节点，默认：展开
        /// </summary>
        public bool spread { get; set; } = true;
        /// <summary>
        /// 菜单链接地址
        /// </summary>
        public string href { get; set; }
        /// <summary>
        /// 复选框是否勾选
        /// </summary>
        public bool @checked { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }
    }
}
