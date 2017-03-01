using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TamagotchiWeb.Startup))]
namespace TamagotchiWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
