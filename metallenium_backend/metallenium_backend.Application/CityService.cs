using AutoMapper;
using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<List<CityDto>> GetAllCities()
        {
           var cities = await _cityRepository.GetAllCities();
            return _mapper.Map<List<CityDto>>(cities); 
        }

        public async Task<CityDto> GetCityById(int id)
        {
            var city = await _cityRepository.GetCityById(id);
            if(city == null)
            {
                throw new KeyNotFoundException($"City with ID {id} not found.");
            }
            return _mapper.Map<CityDto>(city);
        }
        public async Task<CityDto> CreateCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            var createdCity = await _cityRepository.CreateCity(city);
            return _mapper.Map<CityDto>(createdCity);
        }


        public async Task<CityDto> UpdateCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            var updatedCity = await _cityRepository.UpdateCity(city);
            return _mapper.Map<CityDto>(updatedCity);
        }

        public async Task<CityDto> DeleteCity(int id)
        {
           var deletedCity = await _cityRepository.DeleteCity(id);
            if(deletedCity == null)
            {
                throw new KeyNotFoundException($"City with ID {id} not found.");
            }
            return _mapper.Map<CityDto>(deletedCity);
        }
    }
}
