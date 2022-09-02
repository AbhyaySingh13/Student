using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Student.WebUI.Startup))]
namespace Student.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
