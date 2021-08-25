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

        /// <summary>
        /// 树页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取递归之后的树节点集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNode()
        {
            return Json(service.GetNodes());
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateNode(treemodel model)
        {
            return Json(service.CreateMenu(model));
        }

        /// <summary>
        /// 更新节点
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult UpdateNode(treemodel model)
        {
            return Json(service.UpdateMenu(model));
        }
    }
}
