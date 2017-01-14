using AutoMapper;
using Livraria.Ioc;
using Livraria.Web.Helpers.AutoMapperConf;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Livraria.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleConfig.RegisterBundles(BundleTable.Bundles); Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
                cfg.AddProfile<AutoMapperProfileVmToEntity>();
            });

#if DEBUG
            Mapper.AssertConfigurationIsValid();
#endif
            WindsorIoc.Iniciar();
        }

        protected void Application_End()
        {
            WindsorIoc.Finalizar();
        }
    }
}