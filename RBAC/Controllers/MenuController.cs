using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RBAC.IService;
using RBAC.Model;

namespace RBAC.Controllers
{
    public class MenuController : Controller
    {
        private ImenuService service;

        public MenuController(ImenuService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        public IActionResult CreateRoot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoot(menuModel menuModel)
        {
            return Json(service.Create(menuModel));
        }

        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetRootNodes()
        {
            return Json(new
            {
                code = 0,
                data = service.GetRootNodes()
            });
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
        [HttpPost]
        public IActionResult UpdateNode(menuModel model)
        {
            return Json(service.Update(model));
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteNode(int id)
        {
            return Json(service.Delete(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(service.GetEntity(id));
        }
        
        [HttpPost]
        public IActionResult Edit(menuModel menu)
        {
            return Json(service.Update(menu));
        }

        [HttpPost]
        public IActionResult UpdateName(menuModel menu)
        {
            return Json(service.Update(menu));
        }
    }
}
