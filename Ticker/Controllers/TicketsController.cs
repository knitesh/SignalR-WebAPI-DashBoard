using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Ticker.hubs;
using Ticker.Models;

namespace Ticker.Controllers
{
    public class TicketsController : ApiController
    {
        private ITicketRepository _repository;

        public TicketsController(ITicketRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }
        // GET: api/Tickets
        public IEnumerable<Ticket> Get()
        {
            return _repository.GetTickets();
        }

        // POST: api/Tickets
        public void Post([FromBody]Ticket data)
        {
            _repository.AddTicket(data);

            var context = GlobalHost.ConnectionManager.GetHubContext<DataHub>();
            context.Clients.All.addNewItem(data);

        }

        [Route("api/Ping")]
        public async Task<Ticket> Ping()
        {
            Ticket data = await _repository.Ping();

            var context = GlobalHost.ConnectionManager.GetHubContext<DataHub>();
            context.Clients.All.addNewItem(data);
            return data;

        }
    }
}