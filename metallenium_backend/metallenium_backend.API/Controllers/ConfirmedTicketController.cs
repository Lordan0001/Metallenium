using AutoMapper;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace metallenium_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmedTicketController : ControllerBase
    {
        private readonly IConfirmedTicketService _confirmedTicketService;
        private readonly IMapper _mapper;

        public ConfirmedTicketController(IConfirmedTicketService confirmedTicketService, IMapper mapper)
        {
            _confirmedTicketService = confirmedTicketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConfirmedTicket>>> GetAllConfirmedTickets()
        {
            var confirmedTicketsFromService = await _confirmedTicketService.GetAllConfirmedTickets();
            return Ok(confirmedTicketsFromService);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConfirmedTicket>> GetConfirmedTicketById(int id)
        {
            var confirmedTicketFromService = await _confirmedTicketService.GetConfirmedTicketById(id);
            if (confirmedTicketFromService == null)
            {
                return NotFound();
            }
            return Ok(confirmedTicketFromService);
        }

        [HttpPost]
        public async Task<ActionResult<ConfirmedTicket>> CreateConfirmedTicket(ConfirmedTicketDto confirmedTicketDto)
        {
            var createdConfirmedTicket = await _confirmedTicketService.CreateConfirmedTicket(confirmedTicketDto);
            return Ok(createdConfirmedTicket);
        }

        [HttpPut]
        public async Task<ActionResult<ConfirmedTicket>> UpdateConfirmedTicket(ConfirmedTicketDto confirmedTicketDto)
        {
            var updatedConfirmedTicket = await _confirmedTicketService.UpdateConfirmedTicket(confirmedTicketDto);
            return Ok(updatedConfirmedTicket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConfirmedTicket(int id)
        {
            var deletedConfirmedTicket = await _confirmedTicketService.DeleteConfirmedTicket(id);
            return Ok(deletedConfirmedTicket);
        }
    }
}
