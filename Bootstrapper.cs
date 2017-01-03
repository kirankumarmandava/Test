using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using MyFirstApp.Data.Infra;
using MyFirstApp.Data.Repository;
using MyFirstApp.BLL;

namespace MyFirstApp
{
    public class Bootstrapper
    {
        public static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterType<MenuService>().As<IMenuService>().InstancePerHttpRequest();
            builder.RegisterAssemblyTypes(typeof(MenuService).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}