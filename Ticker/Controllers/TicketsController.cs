using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SignalR.Web.Models;

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
        public void Post([FromBody]Ticket ticket)
        {
            _repository.AddTicket(ticket);

            //   var _context =   GlobalHost.ConnectionManager.GetHubContext<TicketHub>();            
            //   _context.Clients.All.addNewTicket(ticket);

        }
    }
}