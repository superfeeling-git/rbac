using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBAC.IService;
using RBAC.Model;

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
    }
}
