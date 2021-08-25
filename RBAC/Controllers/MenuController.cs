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
            /*
            List<treemodel> list = new List<treemodel>();

            List<treemodel> sublist = new List<treemodel>();

            treemodel sub1 = new treemodel
            {
                id = 2,
                title = "bei jing",
                children = new List<treemodel> {
                    new treemodel{ 
                        id = 4,
                        title = "物联网"
                    }
                }
            };

            treemodel sub2 = new treemodel
            {
                id = 3,
                title = "shang hai"
            };

            sublist.Add(sub1);
            sublist.Add(sub2);

            treemodel root1 = new treemodel {
                id = 1, title = "ba wei", children = sublist
            };

            list.Add(root1);
            */
            return Json(service.GetNodes());
        }
    }
}
