using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Repository
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCities();
        Task<City> GetCityById(int id);
        Task<City> CreateCity(City city);
        Task<City> UpdateCity(City city);
        Task<City> DeleteCity(int id);
    }
}
