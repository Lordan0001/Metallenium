using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Repository
{
    public interface IConfirmedTicketRepository
    {
        Task<List<ConfirmedTicket>> GetAllConfirmedTickets();
        Task<ConfirmedTicket> GetConfirmedTicketById(int id);
        Task<ConfirmedTicket> CreateConfirmedTicket(ConfirmedTicket confirmedTicket);
        Task<ConfirmedTicket> UpdateConfirmedTicket(ConfirmedTicket confirmedTicket);
        Task<ConfirmedTicket> DeleteConfirmedTicket(int id);
    }
}
