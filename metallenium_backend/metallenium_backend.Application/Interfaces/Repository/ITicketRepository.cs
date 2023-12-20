using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Repository
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(int id);
        Task<Ticket> GetTicketByUserId(int id);
        Task<Ticket> CreateTicket(Ticket ticket);
        Task<Ticket> UpdateTicket(Ticket ticket);
        Task<Ticket> DeleteTicket(int id);
        public Task<int> GetTicketsCount(int id); 
        public Task<int> GetPlaceCapacity(int id);
    }
}
