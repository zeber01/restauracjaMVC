using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JOTB_Restauracja.Startup))]
namespace JOTB_Restauracja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
