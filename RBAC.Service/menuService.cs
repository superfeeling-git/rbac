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

            foreach (var item in List.Where(m=>m.ParnetID == 0))
            {
                treemodel treemodel = new treemodel { title = item.MenuName, id = item.MenuID };

                Nodes.Add(treemodel);
            }

            return Nodes;
        }
    }
}