using NHibernate;
using Somnio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Somnio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory { get; private set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var configuration = new NHibernate.Cfg.Configuration();
            configuration.Configure();  
            configuration.AddAssembly(typeof(PurchaseHistory).Assembly);  
            SessionFactory = configuration.BuildSessionFactory();
        }

        protected void Application_End()
        {
            SessionFactory.Dispose();
        }
    }
}
