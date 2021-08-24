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
        public List<treemodel> children { get; set; }
        /// <summary>
        /// 是否展开节点，默认：展开
        /// </summary>
        public bool spread { get; set; } = true;
    }
}
