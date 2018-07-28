using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PS_WebApp.Startup))]
namespace PS_WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
