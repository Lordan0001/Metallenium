using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto
{
    public class PlaceDto
    {
        public string Address { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public int CityId { get; set; }
    }
}
