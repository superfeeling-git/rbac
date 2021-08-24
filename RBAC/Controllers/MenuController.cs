using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using RBAC.Model;
using RBAC.IService;

namespace RBAC.Controllers
{
    public class MenuController : Controller
    {
        private ImenuService service;

        public MenuController(ImenuService _service)
        {
            this.service = _service;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetNode()
        {
            return Json(service.GetNodes());
        }
    }
}
