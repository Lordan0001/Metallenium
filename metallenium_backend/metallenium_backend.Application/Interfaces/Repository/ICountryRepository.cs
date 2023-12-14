using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountryById(int id);
        Task<Country> CreateCountry(Country country);
        Task<Country> UpdateCountry(Country country);
        Task<Country> DeleteCountry(int id);

    }
}
