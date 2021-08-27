using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RBAC.Model;
using RBAC.IService;

namespace RBAC.Controllers
{
    public class RoleController : Controller
    {
        private IroleService service;

        public RoleController(IroleService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<treemodel> menu)
        {
            return Json(new { });
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
