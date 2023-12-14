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
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<List<TicketDto>> GetAllTickets()
        {
            var tickets = await _ticketRepository.GetAllTickets();
            return _mapper.Map<List<TicketDto>>(tickets);
        }

        public async Task<TicketDto> GetTicketById(int id)
        {
            var ticket = await _ticketRepository.GetTicketById(id);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<TicketDto> CreateTicket(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            var createdTicket = await _ticketRepository.CreateTicket(ticket);
            return _mapper.Map<TicketDto>(createdTicket);
        }

        public async Task<TicketDto> UpdateTicket(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            var updatedTicket = await _ticketRepository.UpdateTicket(ticket);
            return _mapper.Map<TicketDto>(updatedTicket);
        }

        public async Task<TicketDto> DeleteTicket(int id)
        {
            var deletedTicket = await _ticketRepository.DeleteTicket(id);
            if (deletedTicket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }
            return _mapper.Map<TicketDto>(deletedTicket);
        }
    }

}
