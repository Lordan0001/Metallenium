using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Service
{
    public interface IPlaceService
    {
        Task<List<PlaceDto>> GetAllPlaces();
        Task<List<PlaceDto>> GetPlacesByCityId(int id);
        Task<PlaceDto> GetPlaceById(int id);
        Task<PlaceDto> CreatePlace(PlaceDto placeDto);
        Task<PlaceDto> UpdatePlace(PlaceDto placeDto);
        Task<PlaceDto> DeletePlace(int id);
    }
}
