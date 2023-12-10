using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Application.Interfaces.Service;
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

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task <Album> GetAlbumById(int id)
        {
           return await _albumRepository.GetAlbumById(id);
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            var  albums = await _albumRepository.GetAllAlbums();
            return albums; 
        }
        public async Task<Album> CreateAlbum(Album album)
        {
           return await _albumRepository.CreateAlbum(album);
        }

        public async Task<Album> UpdateAlbum(Album album)
        {
            return await _albumRepository.UpdateAlbum(album);
        }
        public async Task<Album> DeleteAlbum(int id)
        {
           return await _albumRepository.DeleteAlbum(id);
        }

        public async Task<List<Album>> GetAlbumsByBandId(int id)
        {
            var albums = await _albumRepository.GetAlbumsByBandId(id);
            return albums;
        }
    }
}
