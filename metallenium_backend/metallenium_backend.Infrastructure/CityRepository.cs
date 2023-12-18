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
    public class CityRepository : ICityRepository
    {
        private readonly MainDbContext _mainDbContext;

        public CityRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<List<City>> GetAllCities()
        {
            return await _mainDbContext.Cities.ToListAsync();
        }

        public async Task<City> GetCityById(int id)
        {
            var city = await _mainDbContext.Cities.FirstOrDefaultAsync(c => c.CityId == id);
            if(city == null)
            {
                throw new KeyNotFoundException($"City: {id} not found");
            }
            return city;
        }
        public async Task<List<City>> GetCitiesByCountryId(int id)
        {
            var cities = await _mainDbContext.Cities.Where(a => a.CountryId == id).ToListAsync();
            return cities;
        }

        public async Task<City> CreateCity(City city)
        {
            _mainDbContext.Cities.Add(city);
            await _mainDbContext.SaveChangesAsync();
            return city;
        }

        public async Task<City> UpdateCity(City city)
        {
            _mainDbContext.Cities.Update(city);
            await _mainDbContext.SaveChangesAsync();
            return city;
        }

        public async Task<City> DeleteCity(int id)
        {
            var cityToDelete = await _mainDbContext.Cities.FirstOrDefaultAsync(c => c.CityId == id);
            if (cityToDelete == null)
            {
                throw new KeyNotFoundException($"City: {id} not found");

            }
            _mainDbContext.Cities.Remove(cityToDelete);
            await _mainDbContext.SaveChangesAsync();
            return cityToDelete;
        }
    }
}
