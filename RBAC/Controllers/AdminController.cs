using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBAC.IService;
using RBAC.Model;
using RBAC.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RBAC.Controllers
{
    public class AdminController : Controller
    {
        private IAdminService adminService;

        public AdminController(IAdminService _adminService)
        {
            this.adminService = _adminService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(adminModel model)
        {
            return new JsonResult(adminService.Create(model));
        }

        [HttpGet]
        public IActionResult Login()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Admin"));
            claims.Add(new Claim(ClaimTypes.Role, "Super"));

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return Ok();
        }
    }
}
