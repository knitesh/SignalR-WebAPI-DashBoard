using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using SignalR.Web.Models;
using Ticker.hubs;

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
        //public TicketsController()
        //{
        //   ITicketRepository repository = new TicketRepository();
        //    if (repository == null) throw new ArgumentNullException("repository");
        //    _repository = repository;
        //}

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
            context.Clients.All.addNewTicket(data);

        }
    }
}