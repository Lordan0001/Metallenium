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
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;

        public PlaceService(IPlaceRepository placeRepository, IMapper mapper)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
        }

        public async Task<List<PlaceDto>> GetAllPlaces()
        {
            var places = await _placeRepository.GetAllPlaces();
            return _mapper.Map<List<PlaceDto>>(places);
        }

        public async Task<PlaceDto> GetPlaceById(int id)
        {
            var place = await _placeRepository.GetPlaceById(id);
            if (place == null)
            {
                throw new KeyNotFoundException($"Place with ID {id} not found.");
            }
            return _mapper.Map<PlaceDto>(place);
        }
        public async Task<List<PlaceDto>> GetPlacesByCityId(int id)
        {
            var places = await _placeRepository.GetPlacesByCityId(id);
            return _mapper.Map<List<PlaceDto>>(places);
        }

        public async Task<PlaceDto> CreatePlace(PlaceDto placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);
            var createdPlace = await _placeRepository.CreatePlace(place);
            return _mapper.Map<PlaceDto>(createdPlace);
        }

        public async Task<PlaceDto> UpdatePlace(PlaceDto placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);
            var updatedPlace = await _placeRepository.UpdatePlace(place);
            return _mapper.Map<PlaceDto>(updatedPlace);
        }

        public async Task<PlaceDto> DeletePlace(int id)
        {
            var deletedPlace = await _placeRepository.DeletePlace(id);
            if (deletedPlace == null)
            {
                throw new KeyNotFoundException($"Place with ID {id} not found.");
            }
            return _mapper.Map<PlaceDto>(deletedPlace);
        }
    }

}
