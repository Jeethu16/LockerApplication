using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TZLockerBank.Startup))]
namespace TZLockerBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
