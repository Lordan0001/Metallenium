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

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<ConfirmedTicketDto, ConfirmedTicket>();
            CreateMap<ConfirmedTicket, ConfirmedTicketDto>();

            CreateMap<CountryDto, Country>();
            CreateMap<Country, CountryDto>();

            CreateMap<PlaceDto, Place>();
            CreateMap<Place, PlaceDto>();

            CreateMap<TicketDto, Ticket>();
            CreateMap<Ticket, TicketDto>();

        }
    }
}
