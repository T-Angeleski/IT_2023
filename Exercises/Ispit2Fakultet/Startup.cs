using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ispit2Fakultet.Startup))]
namespace Ispit2Fakultet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
