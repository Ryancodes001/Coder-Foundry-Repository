using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Coder_Foundry_Portfolio.Startup))]
namespace Coder_Foundry_Portfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
