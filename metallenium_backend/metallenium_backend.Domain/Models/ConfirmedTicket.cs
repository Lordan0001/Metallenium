using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Models
{
    public class ConfirmedTicket
    {
        public int ConfirmedTicketId { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
