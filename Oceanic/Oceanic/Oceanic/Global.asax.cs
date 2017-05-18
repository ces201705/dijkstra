using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Oceanic.DAL;

namespace Oceanic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void BootstrapContainer()
        {

            var context = new Entities();
            _container = new WindsorContainer().Install(FromAssembly.This());

            _container.Register(
                Component.For<ISegmentRepository>()
                .ImplementedBy<SegmentRepository>()
                .DependsOn(Dependency.OnValue("context", context))
            );
            _container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());


            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
