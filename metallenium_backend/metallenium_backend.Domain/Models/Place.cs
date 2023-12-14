using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string Address { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
