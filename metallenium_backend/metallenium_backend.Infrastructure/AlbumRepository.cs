using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Infrastructure
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MainDbContext _mainDbContext;

        public AlbumRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<Album> GetAlbumById(int id)
        {
            return await _mainDbContext.Albums.FirstOrDefaultAsync(a => a.AlbumId == id);
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            var albums = await _mainDbContext.Albums.ToListAsync();  
            return albums;
        }
        public async Task<Album> CreateAlbum(Album album)
        {
            _mainDbContext.Albums.Add(album);
            await _mainDbContext.SaveChangesAsync();
            return album;  
        }

        public async Task<Album> UpdateAlbum(Album album)
        {
            _mainDbContext.Update(album);
              await _mainDbContext.SaveChangesAsync();
            return album;
        }

        public async Task<Album> DeleteAlbum(int id)
        {
            var album = await _mainDbContext.Albums.FirstOrDefaultAsync(b =>b.AlbumId == id);
            if(album != null)
            {
                _mainDbContext.Albums.Remove(album);
               await _mainDbContext.SaveChangesAsync();
            }
            return album;
        }

        public async Task<List<Album>> GetAlbumsByBandId(int id)
        {
            var albums = await _mainDbContext.Albums.Where(a => a.BandId == id).ToListAsync();
            return albums;
        }
    }
}
