using Microsoft.Owin;
using Owin;

[assembly: log4net.Config.XmlConfigurator(ConfigFile="Log4Net.config", Watch = true)]
[assembly: OwinStartupAttribute(typeof(OnlineSales.Portal.Startup))]

namespace OnlineSales.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
