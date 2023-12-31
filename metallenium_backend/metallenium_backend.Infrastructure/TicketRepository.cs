﻿using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Infrastructure
{
    public class TicketRepository : ITicketRepository
    {
        private readonly MainDbContext _mainDbContext;

        public TicketRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _mainDbContext.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            var ticket = await _mainDbContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket: {id} not found");
            }
            return ticket;
        }
        public async Task<Ticket> GetTicketByUserId(int id)
        {
            var ticket = await _mainDbContext.Tickets.FirstOrDefaultAsync(t => t.UserId == id);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket: {id} not found");
            }
            return ticket;
        }
        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            _mainDbContext.Tickets.Add(ticket);
            await _mainDbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            _mainDbContext.Tickets.Update(ticket);
            await _mainDbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> DeleteTicket(int id)
        {
            var ticketToDelete = await _mainDbContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
            if (ticketToDelete == null)
            {
                throw new KeyNotFoundException($"Ticket: {id} not found");
            }
            _mainDbContext.Tickets.Remove(ticketToDelete);
            await _mainDbContext.SaveChangesAsync();
            return ticketToDelete;
        }

        public async Task<int> GetTicketsCount(int id)
        {
            int currentTicketsCount = await _mainDbContext.Tickets
               .CountAsync(t => t.PlaceId == id);
            return currentTicketsCount;
        }
        public async Task<int> GetPlaceCapacity(int id)
        {
            var place = await _mainDbContext.Places
                .Where(p => p.PlaceId == id)
                .FirstOrDefaultAsync();
            if (place == null)
            {
                throw new KeyNotFoundException($"Place: {id} not found");
            }
            int capacity = place.Capacity;
            return capacity;

        }
    }
}
