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
    public class BandService : IBandService
    {
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;

        public BandService(IBandRepository bandRepository, IMapper mapper)
        {
            _bandRepository = bandRepository;
            _mapper = mapper;
        }

        public async Task<List<BandDto>> GetAllBands()
        {
            var bands = await _bandRepository.GetAllBands();
            return _mapper.Map<List<BandDto>>(bands);
        }

        public async Task<BandDto> GetBandById(int id)
        {
            var band = await _bandRepository.GetBandById(id);
            if (band == null)
            {
                throw new KeyNotFoundException($"Band with ID {id} not found.");
            }
            return _mapper.Map<BandDto>(band);
        }

        public async Task<BandDto> CreateBand(BandDto bandDto)
        {
            var band = _mapper.Map<Band>(bandDto);
            var createdBand = await _bandRepository.CreateBand(band);
            return _mapper.Map<BandDto>(createdBand);
        }

        public async Task<BandDto> UpdateBand(BandDto bandDto)
        {
            var band = _mapper.Map<Band>(bandDto);
            var updatedBand = await _bandRepository.UpdateBand(band);
            return _mapper.Map<BandDto>(updatedBand);
        }

        public async Task<List<BandDto>> SearchBand(BandDto bandDto)
        {
            var band = _mapper.Map<Band>(bandDto);
            var searchedBand = await _bandRepository.SearchBand(band);
            return _mapper.Map<List<BandDto>>(searchedBand);
        }

        public async Task<BandDto> DeleteBand(int id)
        {
            var deletedBand = await _bandRepository.DeleteBand(id);
            if (deletedBand == null)
            {
                throw new KeyNotFoundException($"Band with ID {id} not found.");
            }
            return _mapper.Map<BandDto>(deletedBand);
        }
    }

}
