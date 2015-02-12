using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KrekelSchool.Startup))]
namespace KrekelSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
