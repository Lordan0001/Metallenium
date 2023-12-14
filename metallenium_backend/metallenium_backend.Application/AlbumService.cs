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
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<List<AlbumDto>> GetAllAlbums()
        {
            var albums = await _albumRepository.GetAllAlbums();
            return _mapper.Map<List<AlbumDto>>(albums);
        }

        public async Task<AlbumDto> GetAlbumById(int id)
        {
            var album = await _albumRepository.GetAlbumById(id);
            if (album == null)
            {
                throw new KeyNotFoundException($"Album with ID {id} not found.");
            }
            return _mapper.Map<AlbumDto>(album);
        }
        public async Task<List<AlbumDto>> GetAlbumsByBandId(int id)
        {
            var albums = await _albumRepository.GetAlbumsByBandId(id);
            return _mapper.Map<List<AlbumDto>>(albums);
        }

        public async Task<AlbumDto> CreateAlbum(AlbumDto albumDto)
        {
            var album = _mapper.Map<Album>(albumDto);
            var createdAlbum = await _albumRepository.CreateAlbum(album);
            return _mapper.Map<AlbumDto>(createdAlbum);
        }

        public async Task<AlbumDto> UpdateAlbum(AlbumDto albumDto)
        {
            var album = _mapper.Map<Album>(albumDto);
            var updatedAlbum = await _albumRepository.UpdateAlbum(album);
            return _mapper.Map<AlbumDto>(updatedAlbum);
        }

        public async Task<AlbumDto> DeleteAlbum(int id)
        {
            var deletedAlbum = await _albumRepository.DeleteAlbum(id);
            if (deletedAlbum == null)
            {
                throw new KeyNotFoundException($"Album with ID {id} not found.");
            }
            return _mapper.Map<AlbumDto>(deletedAlbum);
        }


    }

}
