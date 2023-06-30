using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NoteVerse.Startup))]
namespace NoteVerse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
