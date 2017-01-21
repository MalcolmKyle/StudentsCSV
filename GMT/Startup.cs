using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GMT.Startup))]
namespace GMT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
