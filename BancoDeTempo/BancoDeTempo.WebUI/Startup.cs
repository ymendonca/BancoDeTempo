using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BancoDeTempo.WebUI.Startup))]
namespace BancoDeTempo.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
