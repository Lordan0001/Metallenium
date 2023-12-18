using metallenium_backend.Domain.Dto;
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
        Task<List<BandDto>> GetAllBands();
        Task<BandDto> GetBandById(int id);
        Task<BandDto> CreateBand(BandDto bandDto);
        Task<BandDto> UpdateBand(BandDto bandDto);
        Task<List<BandDto>> SearchBand(BandDto bandDto);

        Task<BandDto> DeleteBand(int id);


    }
}
