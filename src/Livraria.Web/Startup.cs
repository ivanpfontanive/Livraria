using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Livraria.Web.Startup))]
namespace Livraria.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
