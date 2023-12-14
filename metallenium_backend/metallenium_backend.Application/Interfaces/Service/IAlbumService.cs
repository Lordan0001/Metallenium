using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Service
{
    public interface IAlbumService
    {
        Task<List<AlbumDto>> GetAllAlbums();
        Task<List<AlbumDto>> GetAlbumsByBandId(int id);
        Task<AlbumDto> GetAlbumById(int id);
        Task<AlbumDto> CreateAlbum(AlbumDto albumDto);
        Task<AlbumDto> UpdateAlbum(AlbumDto albumDto);
        Task<AlbumDto> DeleteAlbum(int id);
    }

}
