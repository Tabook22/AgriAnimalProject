using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalVaccProject.Startup))]
namespace AnimalVaccProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
