using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeriodicoDigitalWS.Startup))]
namespace PeriodicoDigitalWS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
