using System.Web.Http;
using LightInject;
using SignalR.Web.Models;



namespace Ticker
{
    public class DependencyConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            var container = new ServiceContainer();
            container.RegisterApiControllers();
            container.Register<ITicketRepository, TicketRepository>(new PerContainerLifetime());
            container.EnableWebApi(configuration);
        } 
    }
}