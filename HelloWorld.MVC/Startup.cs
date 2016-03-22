using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloWorld.MVC.Startup))]
namespace HelloWorld.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
