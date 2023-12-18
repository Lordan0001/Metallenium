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
    public class PlaceRepository : IPlaceRepository
    {
        private readonly MainDbContext _mainDbContext;

        public PlaceRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<List<Place>> GetAllPlaces()
        {
            return await _mainDbContext.Places.ToListAsync();
        }

        public async Task<Place> GetPlaceById(int id)
        {
            var place = await _mainDbContext.Places.FirstOrDefaultAsync(p => p.PlaceId == id);
            if (place == null)
            {
                throw new KeyNotFoundException($"Place: {id} not found");
            }
            return place;
        }
        public async Task<List<Place>> GetPlacesByCityId(int id)
        {
            var places = await _mainDbContext.Places.Where(a => a.CityId == id).ToListAsync();
            return places;
        }
        public async Task<Place> CreatePlace(Place place)
        {
            _mainDbContext.Places.Add(place);
            await _mainDbContext.SaveChangesAsync();
            return place;
        }

        public async Task<Place> UpdatePlace(Place place)
        {
            _mainDbContext.Places.Update(place);
            await _mainDbContext.SaveChangesAsync();
            return place;
        }

        public async Task<Place> DeletePlace(int id)
        {
            var placeToDelete = await _mainDbContext.Places.FirstOrDefaultAsync(p => p.PlaceId == id);
            if (placeToDelete == null)
            {
                throw new KeyNotFoundException($"Place: {id} not found");
            }
            _mainDbContext.Places.Remove(placeToDelete);
            await _mainDbContext.SaveChangesAsync();
            return placeToDelete;
        }
    }
}
