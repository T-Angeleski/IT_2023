using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IspitAvtoServisi.Startup))]
namespace IspitAvtoServisi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
