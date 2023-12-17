using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int PlaceId { get; set; }
    }
}
