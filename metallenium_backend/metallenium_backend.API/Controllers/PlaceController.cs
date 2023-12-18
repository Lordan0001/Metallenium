using AutoMapper;
using metallenium_backend.Application;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace metallenium_backend.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlaceController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Place>>> GetAllPlaces()
        {
            var placesFromService = await _placeService.GetAllPlaces();
            return Ok(placesFromService);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlaceById(int id)
        {
            var placeFromService = await _placeService.GetPlaceById(id);
            if (placeFromService == null)
            {
                return NotFound();
            }
            return Ok(placeFromService);
        }
        [HttpGet("GetPlacesByCityId/{id}")]
        public async Task<ActionResult<Place>> GetPlacesByCityId(int id)
        {
            var placeFromService = await _placeService.GetPlacesByCityId(id);
            return Ok(placeFromService);
        }
        [HttpPost]
        public async Task<ActionResult<Place>> CreatePlace(PlaceDto placeDto)
        {
            var createdPlace = await _placeService.CreatePlace(placeDto);
            return Ok(createdPlace);
        }

        [HttpPut]
        public async Task<ActionResult<Place>> UpdatePlace(PlaceDto placeDto)
        {
            var updatedPlace = await _placeService.UpdatePlace(placeDto);
            return Ok(updatedPlace);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlace(int id)
        {
            var deletedPlace = await _placeService.DeletePlace(id);
            return Ok(deletedPlace);
        }
    }
}
