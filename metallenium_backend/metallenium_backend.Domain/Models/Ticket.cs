using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }

        public ICollection<ConfirmedTicket> ConfirmedTickets { get; set;}
    }
}
