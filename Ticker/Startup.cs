using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Ticker.Startup))]
namespace Ticker{
   
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}