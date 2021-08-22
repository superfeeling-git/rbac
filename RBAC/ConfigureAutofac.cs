using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RBAC
{
    public class ConfigureAutofac : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            #region 方法1   Load 适用于无接口注入
            var assemblysIRepository = Assembly.Load("RBAC.IRepository");

            containerBuilder.RegisterAssemblyTypes(assemblysIRepository)
                      .AsImplementedInterfaces()
                      .PropertiesAutowired()
                      .InstancePerLifetimeScope();

            var assemblysRepository = Assembly.Load("RBAC.Repository");

            containerBuilder.RegisterAssemblyTypes(assemblysRepository)
                      .AsImplementedInterfaces()
                      .PropertiesAutowired()
                      .InstancePerLifetimeScope();

            var assemblysIService = Assembly.Load("RBAC.IService");

            containerBuilder.RegisterAssemblyTypes(assemblysIService)
                      .AsImplementedInterfaces()
                      .PropertiesAutowired()
                      .InstancePerLifetimeScope();

            var assemblysService = Assembly.Load("RBAC.Service");

            containerBuilder.RegisterAssemblyTypes(assemblysService)
                      .AsImplementedInterfaces()
                      .PropertiesAutowired()
                      .InstancePerLifetimeScope();

            var assemblysAPI = Assembly.Load("RBAC");

            containerBuilder.RegisterAssemblyTypes(assemblysAPI)
                      .AsImplementedInterfaces()
                      .PropertiesAutowired()
                      .InstancePerLifetimeScope();
            #endregion


            #region 在控制器中使用属性依赖注入，其中注入属性必须标注为public
            //在控制器中使用属性依赖注入，其中注入属性必须标注为public
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
                .Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type)).ToArray();
            containerBuilder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();
            #endregion
        }
    }
}
