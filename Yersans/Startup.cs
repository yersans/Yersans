using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yersans.Startup))]
namespace Yersans
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
