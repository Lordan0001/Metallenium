using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Infrastructure
{
    public class ConfirmedTicketRepository : IConfirmedTicketRepository
    {
        private readonly MainDbContext _mainDbContext;

        public ConfirmedTicketRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<List<ConfirmedTicket>> GetAllConfirmedTickets()
        {
            return await _mainDbContext.ConfirmedTickets.ToListAsync();
        }

        public async Task<ConfirmedTicket> GetConfirmedTicketById(int id)
        {
            var confirmedTicket = await _mainDbContext.ConfirmedTickets.FirstOrDefaultAsync(ct => ct.ConfirmedTicketId == id);
            if (confirmedTicket == null)
            {
                throw new KeyNotFoundException($"ConfirmedTicket: {id} not found");
            }
            return confirmedTicket;
        }

        public async Task<ConfirmedTicket> CreateConfirmedTicket(ConfirmedTicket confirmedTicket)
        {
            _mainDbContext.ConfirmedTickets.Add(confirmedTicket);
            await _mainDbContext.SaveChangesAsync();
            return confirmedTicket;
        }

        public async Task<ConfirmedTicket> UpdateConfirmedTicket(ConfirmedTicket confirmedTicket)
        {
            _mainDbContext.ConfirmedTickets.Update(confirmedTicket);
            await _mainDbContext.SaveChangesAsync();
            return confirmedTicket;
        }

        public async Task<ConfirmedTicket> DeleteConfirmedTicket(int id)
        {
            var confirmedTicketToDelete = await _mainDbContext.ConfirmedTickets.FirstOrDefaultAsync(ct => ct.ConfirmedTicketId == id);
            if (confirmedTicketToDelete == null)
            {
                throw new KeyNotFoundException($"ConfirmedTicket: {id} not found");
            }
            _mainDbContext.ConfirmedTickets.Remove(confirmedTicketToDelete);
            await _mainDbContext.SaveChangesAsync();
            return confirmedTicketToDelete;
        }
    }
}
