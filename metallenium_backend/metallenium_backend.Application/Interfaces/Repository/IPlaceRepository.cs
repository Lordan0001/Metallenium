using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Repository
{
    public interface IPlaceRepository
    {
        Task<List<Place>> GetAllPlaces();
        Task<List<Place>> GetPlacesByCityId(int id);

        Task<Place> GetPlaceById(int id);
        Task<Place> CreatePlace(Place place);
        Task<Place> UpdatePlace(Place place);
        Task<Place> DeletePlace(int id);
    }
}
