using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blackjack.MVC.Startup))]
namespace Blackjack.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
