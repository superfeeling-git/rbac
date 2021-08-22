using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RBAC.IService;
using RBAC.Model;

namespace RBAC.Controllers
{
    public class MenuController : Controller
    {
        private IMenuService menuService;

        public MenuController(IMenuService _menuService)
        {
            this.menuService = _menuService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetNodes()
        {
            return new JsonResult(menuService.GetList());
        }
    }
}
