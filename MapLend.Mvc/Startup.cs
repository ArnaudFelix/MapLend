using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MapLend.Mvc.Startup))]
namespace MapLend.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
