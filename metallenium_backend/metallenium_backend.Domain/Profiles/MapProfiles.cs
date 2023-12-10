using AutoMapper;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Profiles
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<BandDto, Band>();
            CreateMap<Band, BandDto>();

            CreateMap<AlbumDto, Album>();
            CreateMap<Album, AlbumDto>();
        }
    }
}
