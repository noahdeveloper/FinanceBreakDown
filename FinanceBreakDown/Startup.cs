using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinanceBreakDown.Startup))]
namespace FinanceBreakDown
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
