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
        [HttpPost]
        public async Task<ActionResult<Album>> CreateAlbum(AlbumDto albumDto)
        {
            //var album = _mapper.Map<Album>(albumDto);
            var createdAlbum = await _albumService.CreateAlbum(albumDto);
            return Ok(createdAlbum);
        }

        [HttpPut]
        public async Task<ActionResult<Album>> UpdateAlbum(AlbumDto albumDto)
        {
            //var album = _mapper.Map<Album>(albumDto);
            var updatedAlbum = await _albumService.UpdateAlbum(albumDto);
            return Ok(updatedAlbum);

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAlbum(int id) { 
            var deletedAlbum = await _albumService.DeleteAlbum(id);
            return Ok(deletedAlbum);
        }


    }
}
