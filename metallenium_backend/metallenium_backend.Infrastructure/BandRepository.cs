﻿using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Infrastructure
{
    public class BandRepository : IBandRepository
    {
        private readonly MainDbContext _mainDbContext;

        public BandRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<List<Band>> GetAllBands()
        {
            return await _mainDbContext.Bands.ToListAsync();
        }

        public async Task<Band> GetBandById(int id)
        {
            var band = await _mainDbContext.Bands.FirstOrDefaultAsync(b => b.BandId == id);

            if(band == null)
            {
                throw new KeyNotFoundException("User not found with the specified email.");
            }
            return band;
        }
        public async Task<Band> CreateBand(Band band)
        {
            _mainDbContext.Bands.Add(band);
            await _mainDbContext.SaveChangesAsync();
            return band;
        }

        public async Task<Band> UpdateBand(Band band)
        {
            _mainDbContext.Bands.Update(band);
            await _mainDbContext.SaveChangesAsync();
            return band;
        }

        public async Task<List<Band>> SearchBand(Band band)
        {

            var matchesBands = await _mainDbContext.Bands.Where(b => b.BandName.Contains(band.BandName)).ToListAsync();
            return matchesBands;
        }

        public async Task<Band> DeleteBand(int id)
        {
            var bandToDelete = await _mainDbContext.Bands.FirstOrDefaultAsync(b => b.BandId == id);
            if (bandToDelete == null)
            {
                throw new KeyNotFoundException($"Band: {id} not found");

            }
            _mainDbContext.Bands.Remove(bandToDelete);
            await _mainDbContext.SaveChangesAsync();
            return bandToDelete;

        }
    }
}
