using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Models
{
    public class Band
    {
        [Key]
        public int BandId { get; set; }

        [Required]
        public string BandName { get; set; } = String.Empty;

        [Required]
        public string BandDescription { get; set; } = String.Empty;

        [Required]
        public string BandType { get; set; } = String.Empty;

        public string BandImageUrl { get; set; } = String.Empty;

        public ICollection<Album> Albums { get; set; }


    }
}
