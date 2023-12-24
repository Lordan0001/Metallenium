using AutoMapper;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Band>> CreateBand([FromForm] BandDto bandDto, IFormFile image) {

            if (image != null && image.Length > 0)
            {
                // Get the original filename of the image
                var fileName = Path.GetFileName(image.FileName);

                // Save the image to the server's upload folder with the original filename
                var imagePath = Path.Combine("uploads/bands", fileName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Set the imageUrl property of the band to the saved image path
                bandDto.BandImageUrl = imagePath;
            }



            var createdBand = await _bandService.CreateBand(bandDto);
            return Ok(createdBand);
        }



        [HttpPost("Search")]
        public async Task<ActionResult<Band>> SearchBand(BandDto bandDto)
        {
            var searchedBands = await _bandService.SearchBand(bandDto);
            return Ok(searchedBands);
        }

        [HttpPut, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Band>> UpdateBand([FromForm] BandDto bandDto, IFormFile image)
        {

            if (image != null && image.Length > 0)
            {
                // Get the original filename of the image
                var fileName = Path.GetFileName(image.FileName);

                // Save the image to the server's upload folder with the original filename
                var imagePath = Path.Combine("uploads/bands", fileName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Set the imageUrl property of the band to the saved image path
                bandDto.BandImageUrl = imagePath;
            }



            var createdBand = await _bandService.UpdateBand(bandDto);
            return Ok(createdBand);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteBand(int id)
        {
            var deletedBand = await _bandService.DeleteBand(id);
            return Ok(deletedBand);
        }
    }
}
