using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Repository
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAllAlbums();
        Task<Album> GetAlbumById(int id);
        Task<List<Album>> GetAlbumsByBandId(int id);
        Task<Album> CreateAlbum(Album album);
        Task<Album> UpdateAlbum(Album album);
        Task<Album> DeleteAlbum(int id);
    }
}
