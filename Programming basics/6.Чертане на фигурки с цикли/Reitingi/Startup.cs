using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reitingi.Startup))]
namespace Reitingi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
