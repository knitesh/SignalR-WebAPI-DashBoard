using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ticker.Models
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets();
        void AddTicket(Ticket ticket);
        Task<Ticket> Ping();

    }
}
