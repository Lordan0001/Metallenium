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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<CountryDto>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllCountries();
            return _mapper.Map<List<CountryDto>>(countries);
        }

        public async Task<CountryDto> GetCountryById(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            if (country == null)
            {
                throw new KeyNotFoundException($"Country with ID {id} not found.");
            }
            return _mapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> CreateCountry(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            var createdCountry = await _countryRepository.CreateCountry(country);
            return _mapper.Map<CountryDto>(createdCountry);
        }

        public async Task<CountryDto> UpdateCountry(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            var updatedCountry = await _countryRepository.UpdateCountry(country);
            return _mapper.Map<CountryDto>(updatedCountry);
        }

        public async Task<CountryDto> DeleteCountry(int id)
        {
            var deletedCountry = await _countryRepository.DeleteCountry(id);
            if (deletedCountry == null)
            {
                throw new KeyNotFoundException($"Country with ID {id} not found.");
            }
            return _mapper.Map<CountryDto>(deletedCountry);
        }

        public async Task<List<CountryDto>> SearchCountry(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            var searchedCountry = await _countryRepository.SearchCountry(country);
            return _mapper.Map<List<CountryDto>>(searchedCountry);
        }
    }

}
