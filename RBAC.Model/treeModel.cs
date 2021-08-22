using System;
using System.Collections.Generic;
using System.Text;

namespace RBAC.Model
{
    public class treeModel
    {
        public string title { get; set; }
        public int id { get; set; }
        public string field { get; set; }
        public List<treeModel> children { get; set; } = new List<treeModel>();
        public bool spread { get; set; } = true;
    }
}
