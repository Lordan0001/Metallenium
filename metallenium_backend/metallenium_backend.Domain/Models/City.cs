using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = String.Empty;
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Place> Places { get; set;}
        public ICollection<Ticket> Tickets { get; set;}
    }
}
