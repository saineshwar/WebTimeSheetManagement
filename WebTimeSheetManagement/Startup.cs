using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTimeSheetManagement.Startup))]
namespace WebTimeSheetManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
