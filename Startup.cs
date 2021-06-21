using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab02.Startup))]
namespace lab02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
