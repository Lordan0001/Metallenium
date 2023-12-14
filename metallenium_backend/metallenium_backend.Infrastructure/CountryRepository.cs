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
    public class CountryRepository : ICountryRepository
    {
        private readonly MainDbContext _mainDbContext;

        public CountryRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _mainDbContext.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            var country = await _mainDbContext.Countries.FirstOrDefaultAsync(c => c.CountryId == id);
            if (country == null)
            {
                throw new KeyNotFoundException($"Country: {id} not found");
            }
            return country;
        }

        public async Task<Country> CreateCountry(Country country)
        {
            _mainDbContext.Countries.Add(country);
            await _mainDbContext.SaveChangesAsync();
            return country;
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            _mainDbContext.Countries.Update(country);
            await _mainDbContext.SaveChangesAsync();
            return country;
        }

        public async Task<Country> DeleteCountry(int id)
        {
            var countryToDelete = await _mainDbContext.Countries.FirstOrDefaultAsync(c => c.CountryId == id);
            if (countryToDelete == null)
            {
                throw new KeyNotFoundException($"Country: {id} not found");
            }
            _mainDbContext.Countries.Remove(countryToDelete);
            await _mainDbContext.SaveChangesAsync();
            return countryToDelete;
        }
    }
}
