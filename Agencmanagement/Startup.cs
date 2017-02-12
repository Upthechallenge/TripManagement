using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieManagment.Startup))]
namespace MovieManagment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
