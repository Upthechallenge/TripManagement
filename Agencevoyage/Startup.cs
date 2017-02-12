using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agencevoyage.Startup))]
namespace Agencevoyage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
