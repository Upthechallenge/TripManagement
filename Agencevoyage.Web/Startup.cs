using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agencevoyage.Web.Startup))]
namespace Agencevoyage.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
