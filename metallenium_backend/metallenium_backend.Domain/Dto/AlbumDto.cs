using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto
{
    public class AlbumDto
    {
        public int AlbumId { get; set; }    
        public string AlbumName { get; set; } = String.Empty;

        public string AlbumDescription { get; set; } = String.Empty;

        public string AlbumImageUrl { get; set; } = String.Empty;
   
        public int BandId { get; set; }

    }
}
