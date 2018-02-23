using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientDataProject.Startup))]
namespace ClientDataProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
