using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PAHStack.Startup))]
namespace PAHStack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
