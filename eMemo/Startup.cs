using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eMemo.Startup))]
namespace eMemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
