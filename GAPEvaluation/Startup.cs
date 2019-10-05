using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAPEvaluation.Startup))]
namespace GAPEvaluation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
