using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerManagementPortal.Startup))]
namespace CustomerManagementPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
