using metallenium_backend.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace metallenium_backend.Application.Interfaces.Service
{
    public interface IConfirmedTicketService
    {
        Task<List<ConfirmedTicketDto>> GetAllConfirmedTickets();
        Task<ConfirmedTicketDto> GetConfirmedTicketById(int id);
        Task<ConfirmedTicketDto> CreateConfirmedTicket(ConfirmedTicketDto confirmedTicketDto);
   /*     Task<ConfirmedTicketDto> SendEmail(UserDto userDto);*/
        Task<ConfirmedTicketDto> UpdateConfirmedTicket(ConfirmedTicketDto confirmedTicketDto);
        Task<ConfirmedTicketDto> DeleteConfirmedTicket(int id);
    }
}
