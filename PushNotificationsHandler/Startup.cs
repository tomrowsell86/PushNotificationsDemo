using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PushNotificationsHandler.Startup))]
namespace PushNotificationsHandler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
