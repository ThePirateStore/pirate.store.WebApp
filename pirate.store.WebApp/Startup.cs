using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pirate.store.WebApp.Startup))]
namespace pirate.store.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
