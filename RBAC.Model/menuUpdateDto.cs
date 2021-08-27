using System;
using System.Collections.Generic;
using System.Text;
using RBAC.Model.Base;

namespace RBAC.Model
{
    public class menuUpdateDto: BaseDto
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
    }
}
