using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ticker.Models
{
    public class TicketRepository : ITicketRepository
    {
        private readonly List<Ticket> _localTickets;


        public TicketRepository()
        {
            _localTickets = new List<Ticket>() {
                new Ticket("sample", "sample desc"),
                new Ticket("sample 2", "sample desc 2"),
                new Ticket("sample 3", "sample desc 3")
            };
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _localTickets.AsEnumerable();
        }

        public void AddTicket(Ticket ticket)
        {
            _localTickets.Add(ticket);
        }

        public async Task<Ticket> Ping()
        {
            Ticket localTicket = null;
            var next = _localTickets.Count > 0 ? _localTickets.Count + 1 : 1;


            var page = "https://jsonplaceholder.typicode.com/comments/" + next;

            // ... Use HttpClient.
            using (var localclient = new HttpClient())
            {
                using (var response = await localclient.GetAsync(page))
                {
                    using (var content = response.Content)
                    {
                        // ... Read New Data.
                        var result = await content.ReadAsAsync<Comments>();

                        // ... Display the result.
                        if (result == null) return (Ticket)null;
                        //Format it to local Data
                        localTicket = new Ticket(result.name, result.body);
                        _localTickets.Add(localTicket);
                    }
                }

            }
            return localTicket;
        }

    }
}