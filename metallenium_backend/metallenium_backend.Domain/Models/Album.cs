using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string AlbumName { get; set; } = String.Empty;
        [Required]
        public string AlbumDescription { get; set; } = String.Empty;

        public string AlbumImageUrl { get; set; } = String.Empty;
        [Required]
        public int BandId { get; set; }
        public Band Band { get; set; }



    }
}
