using AutoMapper;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace metallenium_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCities()
        {
            var citiesFromService = await _cityService.GetAllCities();
            return Ok(citiesFromService);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityById(int id)
        {
            var cityFromService = await _cityService.GetCityById(id);
            if (cityFromService == null)
            {
                return NotFound();
            }
            return Ok(cityFromService);
        }

        [HttpPost]
        public async Task<ActionResult<City>> CreateCity(CityDto cityDto)
        {
            var createdCity = await _cityService.CreateCity(cityDto);
            return Ok(createdCity);
        }

        [HttpPut]
        public async Task<ActionResult<City>> UpdateCity(CityDto cityDto)
        {
            var updatedCity = await _cityService.UpdateCity(cityDto);
            return Ok(updatedCity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            var deletedCity = await _cityService.DeleteCity(id);
            return Ok(deletedCity);
        }
    }
}
