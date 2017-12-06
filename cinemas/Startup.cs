using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cinemas.Startup))]
namespace cinemas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
