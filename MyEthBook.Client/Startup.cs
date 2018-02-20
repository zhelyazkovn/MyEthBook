using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyEthBook.Client.Startup))]
namespace MyEthBook.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
