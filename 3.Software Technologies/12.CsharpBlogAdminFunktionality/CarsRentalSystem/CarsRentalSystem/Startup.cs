using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarsRentalSystem.Startup))]
namespace CarsRentalSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
