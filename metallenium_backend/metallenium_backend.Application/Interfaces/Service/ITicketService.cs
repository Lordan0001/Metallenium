using metallenium_backend.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Service
{
    public interface ITicketService
    {
        Task<List<TicketDto>> GetAllTickets();
        Task<TicketDto> GetTicketById(int id);
        Task<TicketDto> CreateTicket(TicketDto ticketDto);
        Task<TicketDto> UpdateTicket(TicketDto ticketDto);
        Task<TicketDto> DeleteTicket(int id);
    }
}
