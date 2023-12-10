using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application
{
    public class BandService : IBandService
    {
        private readonly IBandRepository _bandRepository;

        public BandService(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<List<Band>> GetAllBands()
        {
            var bands = await _bandRepository.GetAllBands();
            return bands;

        }

        public async Task<Band> GetBandById(int id)
        {
           return await _bandRepository.GetBandById(id);
        }
        public async Task<Band> CreateBand(Band band)
        {
            return await _bandRepository.CreateBand(band);
        }

        public async Task<Band> UpdateBand(Band band)
        {
            return await _bandRepository.UpdateBand(band);
        }
        public async Task<Band> DeleteBand(int id)
        {
            return await _bandRepository.DeleteBand(id);
        }


    }
}
