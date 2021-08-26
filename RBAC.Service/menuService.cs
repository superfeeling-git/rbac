using System;
using RBAC.Model;
using RBAC.Service.Base;
using RBAC.IService;
using RBAC.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace RBAC.Service
{
    public class menuService : BaseService<menuModel, int>, ImenuService
    {
        private ImenuRepository repository;

        public menuService(ImenuRepository _repository)
        {
            this.BaseRepository = _repository;
            this.repository = _repository;
        }

        List<treemodel> Nodes = new List<treemodel>();

        public List<treemodel> GetNodes()
        {
            var List = repository.GetList();

            foreach (var item in List.Where(m => m.ParnetID == 0))
            {
                //家电--电视机(液晶、。。。)、冰箱、洗衣机
                treemodel treemodel = new treemodel { title = item.MenuName, id = item.MenuID, href = item.MenuLink, @checked = item.IsShow };
                GetSubNodes(treemodel, List);
                Nodes.Add(treemodel);
            }

            return Nodes;
        }

        /// <summary>
        /// 获取第二级节点
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="list"></param>
        private void GetSubNodes(treemodel tree, List<menuModel> list)
        {
            foreach (var item in list.Where(m => m.ParnetID == tree.id))
            {
                treemodel treemodel = new treemodel { title = item.MenuName, id = item.MenuID, href = item.MenuLink, @checked = item.IsShow };
                tree.children.Add(treemodel);
                GetSubNodes(treemodel, list);
            }
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="treemodel"></param>
        /// <returns></returns>
        public int CreateMenu(treemodel treemodel)
        {
            return repository.Create(new menuModel { ParnetID = treemodel.id });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override int Delete(int id)
        {
            //看子节点数量
            var List = repository.GetList();

            if (List.Count(m => m.ParnetID == id) > 0)
            {
                return 0;
            }
            return base.Delete(id);
        }

        /// <summary>
        /// 获取根节点
        /// </summary>
        /// <returns></returns>
        public List<menuModel> GetRootNodes()
        {
            var List = repository.GetList();

            return List.Where(m => m.ParnetID == 0).ToList();
        }
    }
}