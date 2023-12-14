using metallenium_backend.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Service
{
    public interface ICityService
    {
        Task<List<CityDto>> GetAllCities();
        Task<CityDto> GetCityById(int id);
        Task<CityDto> CreateCity(CityDto cityDto);
        Task<CityDto> UpdateCity(CityDto cityDto);
        Task<CityDto> DeleteCity(int id);
    }
}
