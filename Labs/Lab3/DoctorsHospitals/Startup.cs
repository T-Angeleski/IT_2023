using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorsHospitals.Startup))]
namespace DoctorsHospitals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
