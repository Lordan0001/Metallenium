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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countriesFromService = await _countryService.GetAllCountries();
            return Ok(countriesFromService);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            var countryFromService = await _countryService.GetCountryById(id);
            if (countryFromService == null)
            {
                return NotFound();
            }
            return Ok(countryFromService);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(CountryDto countryDto)
        {
            var createdCountry = await _countryService.CreateCountry(countryDto);
            return Ok(createdCountry);
        }

        [HttpPut]
        public async Task<ActionResult<Country>> UpdateCountry(CountryDto countryDto)
        {
            var updatedCountry = await _countryService.UpdateCountry(countryDto);
            return Ok(updatedCountry);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var deletedCountry = await _countryService.DeleteCountry(id);
            return Ok(deletedCountry);
        }
    }
}
