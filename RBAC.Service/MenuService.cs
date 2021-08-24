using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RBAC.Model;
using RBAC.IService;
using RBAC.Service.Base;
using RBAC.IRepository;

namespace RBAC.Service
{
    public class MenuService : BaseService<menuModel,int>, IMenuService
    {
        private ImenuRepository repository;
        public MenuService(ImenuRepository _repository)
        {
            this.baseRepository = _repository;
            this.repository = _repository;
        }

        /// <summary>
        /// 存储递归数据
        /// </summary>
        List<treeModel> treeModels = new List<treeModel>();

        public new List<treeModel> GetList(string where = null)
        {
            List<menuModel> menus = repository.GetList();
            foreach (var item in menus.Where(m => m.ParnetID == 0))
            {
                treeModel tree = new treeModel { id = item.MenuID, title = item.MenuName };
                GetSubChild(tree, menus);
                treeModels.Add(tree);
            }

            return treeModels;
        }

        public void GetSubChild(treeModel tree, List<menuModel> menus)
        {
            foreach (var item in menus.Where(m=>m.ParnetID == tree.id))
            {
                treeModel subtree = new treeModel { id = item.MenuID, title = item.MenuName };
                tree.children.Add(subtree);
                GetSubChild(subtree, menus);
            }
        }
    }
}
