using metallenium_backend.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Service
{
    public interface ICountryService
    {
        Task<List<CountryDto>> GetAllCountries();
        Task<CountryDto> GetCountryById(int id);
        Task<CountryDto> CreateCountry(CountryDto countryDto);
        Task<CountryDto> UpdateCountry(CountryDto countryDto);
        Task<CountryDto> DeleteCountry(int id);
    }
}
