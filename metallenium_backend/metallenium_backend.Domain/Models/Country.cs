using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = String.Empty;

        public ICollection<City> Cities { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
