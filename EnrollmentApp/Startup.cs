using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnrollmentApp.Startup))]
namespace EnrollmentApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
