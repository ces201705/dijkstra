using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oceanic.Startup))]
namespace Oceanic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
