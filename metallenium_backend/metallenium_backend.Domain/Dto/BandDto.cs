using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto
{
    public class BandDto
    {
        public int BandId { get; set; }

        public string BandName { get; set; } = String.Empty;

        public string BandDescription { get; set; } = String.Empty;

        public string BandType { get; set; } = String.Empty;

        public string BandImageUrl { get; set; } = String.Empty;
    }
}
