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
            adminService.Create(new adminModel { AdminID = 0, CreateTime = DateTime.Now, LastLoginTime = DateTime.Now, Password = "123456", UserName = "admin" });
            return View();
        }/*

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(adminModel adminModel)
        {
            return Json(adminService.Create(adminModel));
        }*/
    }
}
