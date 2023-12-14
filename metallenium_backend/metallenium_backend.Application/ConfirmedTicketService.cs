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
    public class ConfirmedTicketService : IConfirmedTicketService
    {
        private readonly IConfirmedTicketRepository _confirmedTicketRepository;
        private readonly IMapper _mapper;

        public ConfirmedTicketService(IConfirmedTicketRepository confirmedTicketRepository, IMapper mapper)
        {
            _confirmedTicketRepository = confirmedTicketRepository;
            _mapper = mapper;
        }

        public async Task<List<ConfirmedTicketDto>> GetAllConfirmedTickets()
        {
            var confirmedTickets = await _confirmedTicketRepository.GetAllConfirmedTickets();
            return _mapper.Map<List<ConfirmedTicketDto>>(confirmedTickets);
        }

        public async Task<ConfirmedTicketDto> GetConfirmedTicketById(int id)
        {
            var confirmedTicket = await _confirmedTicketRepository.GetConfirmedTicketById(id);
            if (confirmedTicket == null)
            {
                throw new KeyNotFoundException($"ConfirmedTicket with ID {id} not found.");
            }
            return _mapper.Map<ConfirmedTicketDto>(confirmedTicket);
        }

        public async Task<ConfirmedTicketDto> CreateConfirmedTicket(ConfirmedTicketDto confirmedTicketDto)
        {
            var confirmedTicket = _mapper.Map<ConfirmedTicket>(confirmedTicketDto);
            var createdConfirmedTicket = await _confirmedTicketRepository.CreateConfirmedTicket(confirmedTicket);
            return _mapper.Map<ConfirmedTicketDto>(createdConfirmedTicket);
        }

        public async Task<ConfirmedTicketDto> UpdateConfirmedTicket(ConfirmedTicketDto confirmedTicketDto)
        {
            var confirmedTicket = _mapper.Map<ConfirmedTicket>(confirmedTicketDto);
            var updatedConfirmedTicket = await _confirmedTicketRepository.UpdateConfirmedTicket(confirmedTicket);
            return _mapper.Map<ConfirmedTicketDto>(updatedConfirmedTicket);
        }

        public async Task<ConfirmedTicketDto> DeleteConfirmedTicket(int id)
        {
            var deletedConfirmedTicket = await _confirmedTicketRepository.DeleteConfirmedTicket(id);
            if (deletedConfirmedTicket == null)
            {
                throw new KeyNotFoundException($"ConfirmedTicket with ID {id} not found.");
            }
            return _mapper.Map<ConfirmedTicketDto>(deletedConfirmedTicket);
        }
    }

}
