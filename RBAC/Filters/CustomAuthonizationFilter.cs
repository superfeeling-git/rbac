using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBAC.Filters
{
    public class CustomAuthonizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();
            string DisplayName = context.ActionDescriptor.DisplayName;
            

            //这里可以做复杂的权限控制操作
            /*if (context.HttpContext.User.Identity.Name != "1") //简单的做一个示范
            {
                //未通过验证则跳转到无权限提示页
                RedirectToActionResult content = new RedirectToActionResult("NoAuth", "Exception", null);
                context.Result = content;
            }*/
        }
    }
}
