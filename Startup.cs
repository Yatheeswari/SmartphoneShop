using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartphoneShop.Startup))]
namespace SmartphoneShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
