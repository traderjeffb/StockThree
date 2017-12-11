using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockThree.Web.Startup))]
namespace StockThree.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
