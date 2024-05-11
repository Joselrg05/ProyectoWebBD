using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(med_webb_application.Startup))]
namespace med_webb_application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
