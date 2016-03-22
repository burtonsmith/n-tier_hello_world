using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HelloWorld.MVC.Infrastructure;
using StructureMap;

namespace HelloWorld.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IContainer Container
        {
            get
            {
                return (IContainer)HttpContext.Current.Items["_Container"];
            }
            set
            {
                HttpContext.Current.Items["_Container"] = value;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.Execute();
        }
    }
}
