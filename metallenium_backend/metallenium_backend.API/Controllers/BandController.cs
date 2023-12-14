using AutoMapper;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace metallenium_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IBandService _bandService;
        private readonly IMapper _mapper;

        public BandController(IBandService bandService, IMapper mapper)
        {
            _bandService = bandService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Band>>> GetAllBands()
        {
            var bandsDromService = await _bandService.GetAllBands();
            return Ok(bandsDromService);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Band>> GetBandById(int id)
        {
            var bandFromService = await _bandService.GetBandById(id);
            if(bandFromService == null)
            {
                return NotFound();
            }
            return Ok(bandFromService);
        }
        [HttpPost]
        public async Task<ActionResult<Band>> CreateBand(BandDto bandDto) {
          //  var band = _mapper.Map<Band>(bandDto);
            var createdBand = await _bandService.CreateBand(bandDto);
            return Ok(createdBand);
        }
        [HttpPut]
        public async Task<ActionResult<Band>> UpdateBand(BandDto bandDto)
        {
            //var band = _mapper.Map<Band>(bandDto);
            var updatedBand = await _bandService.UpdateBand(bandDto);
            return Ok(updatedBand);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBand(int id)
        {
            var deletedBand = await _bandService.DeleteBand(id);
            return Ok(deletedBand);
        }
    }
}
