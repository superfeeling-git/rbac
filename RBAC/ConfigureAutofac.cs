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
            //直接注册某一个类和接口
            //左边的是实现类，右边的As是接口
            //containerBuilder.RegisterType<TestServiceE>().As<ITestServiceE>().SingleInstance();


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

            var assemblys = Assembly.Load("RBAC");

            containerBuilder.RegisterAssemblyTypes(assemblys)
                      .AsImplementedInterfaces()
                      .PropertiesAutowired()
                      .InstancePerLifetimeScope();

            #endregion

            #region 方法2  选择性注入 与方法1 一样
            //            Assembly Repository = Assembly.Load("Exercise.Repository");
            //            Assembly IRepository = Assembly.Load("Exercise.IRepository");
            //            containerBuilder.RegisterAssemblyTypes(Repository, IRepository)
            //.Where(t => t.Name.EndsWith("Repository"))
            //.AsImplementedInterfaces().PropertiesAutowired();

            //            Assembly service = Assembly.Load("Exercise.Services");
            //            Assembly Iservice = Assembly.Load("Exercise.IServices");
            //            containerBuilder.RegisterAssemblyTypes(service, Iservice)
            //.Where(t => t.Name.EndsWith("Service"))
            //.AsImplementedInterfaces().PropertiesAutowired();
            #endregion

            #region 方法3  使用 LoadFile 加载服务层的程序集  将程序集生成到bin目录 实现解耦 不需要引用
            /*//获取项目路径
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

            var RepositoryDllFile = Path.Combine(basePath, "RBAC.dll");
            var RepositoryServices = Assembly.LoadFile(RepositoryDllFile);//直接采用加载文件的方法
            containerBuilder.RegisterAssemblyTypes(RepositoryServices).AsImplementedInterfaces().InstancePerLifetimeScope();*/
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
