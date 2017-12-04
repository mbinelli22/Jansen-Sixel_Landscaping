using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JansenAndSixel.Startup))]
namespace JansenAndSixel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
