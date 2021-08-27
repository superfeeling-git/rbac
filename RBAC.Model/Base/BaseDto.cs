using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RBAC.Model.Base
{
    public class BaseDto
    {
        public virtual DateTime? CreateTime { get; set; }
    }
}
