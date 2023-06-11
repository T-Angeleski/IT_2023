using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ispit1.Startup))]
namespace Ispit1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
