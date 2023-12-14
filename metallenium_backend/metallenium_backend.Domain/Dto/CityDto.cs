using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto
{
    public class CityDto
    {
        public string CityName { get; set; } = string.Empty;
        public int CountryId { get; set; }
    }
}
