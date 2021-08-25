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
                //家电--电视机、冰箱、洗衣机
                treemodel treemodel = new treemodel { title = item.MenuName, id = item.MenuID };
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
                treemodel treemodel = new treemodel { title = item.MenuName, id = item.MenuID };

                tree.children.Add(treemodel);


                List<treemodel> treelist = null;
                treelist.Add(new treemodel { });
            }
        }
    }
}