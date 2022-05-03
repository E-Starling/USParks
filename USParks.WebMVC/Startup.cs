using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(USParks.WebMVC.Startup))]
namespace USParks.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
