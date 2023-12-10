using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Service
{
    public interface IBandService
    {
        Task<List<Band>> GetAllBands();
        Task<Band> GetBandById(int id);
        Task<Band> CreateBand(Band band);
        Task<Band> UpdateBand(Band band);
        Task<Band> DeleteBand(int id);
    }
}
