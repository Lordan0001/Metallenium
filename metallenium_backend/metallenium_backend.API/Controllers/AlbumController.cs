using AutoMapper;
using metallenium_backend.Application;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace metallenium_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        private readonly IMapper _mapper;

        public AlbumController(IAlbumService albumService, IMapper mapper)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Album>> GetAllAlbums()
        {
            var albums = await _albumService.GetAllAlbums();
            return Ok(albums);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbumById(int id) {
            var album = await _albumService.GetAlbumById(id); 
            return Ok(album);
        }

        [HttpGet("GetAlbumsByBandId/{id}")]
        public async Task<ActionResult<Album>> GetAlbumsByBandId(int id)
        {
            var album = await _albumService.GetAlbumsByBandId(id);
            return Ok(album);
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Album>> CreateAlbum([FromForm] AlbumDto albumDto, IFormFile image)
        {

            if (image != null && image.Length > 0)
            {
                // Get the original filename of the image
                var fileName = Path.GetFileName(image.FileName);

                // Save the image to the server's upload folder with the original filename
                var imagePath = Path.Combine("uploads/albums", fileName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Set the imageUrl property of the band to the saved image path
                albumDto.AlbumImageUrl = imagePath;
            }



            var createdAlbum = await _albumService.CreateAlbum(albumDto);
            return Ok(createdAlbum);
        }

        [HttpPut, Authorize(Roles = "Administrator")]
        public async Task<ActionResult<Album>> UpdateAlbum([FromForm] AlbumDto albumDto, IFormFile image)
        {

            if (image != null && image.Length > 0)
            {
                // Get the original filename of the image
                var fileName = Path.GetFileName(image.FileName);

                // Save the image to the server's upload folder with the original filename
                var imagePath = Path.Combine("uploads/albums", fileName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Set the imageUrl property of the band to the saved image path
                albumDto.AlbumImageUrl = imagePath;
            }



            var updatedAlbum = await _albumService.UpdateAlbum(albumDto);
            return Ok(updatedAlbum);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteAlbum(int id) { 
            var deletedAlbum = await _albumService.DeleteAlbum(id);
            return Ok(deletedAlbum);
        }


    }
}
