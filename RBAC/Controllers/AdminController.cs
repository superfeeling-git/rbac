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
        private IadminService adminService;
        public AdminController(IadminService _adminService)
        {
            this.adminService = _adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Admin adminModel)
        {
            return Json(adminService.Create(adminModel));
        }
    }
}
