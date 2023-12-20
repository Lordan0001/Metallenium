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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetAllTickets()
        {
            var ticketsFromService = await _ticketService.GetAllTickets();
            return Ok(ticketsFromService);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var ticketFromService = await _ticketService.GetTicketById(id);
            if (ticketFromService == null)
            {
                return NotFound();
            }
            return Ok(ticketFromService);
        }

        [HttpGet("GetTicketByUserId/{id}")]
        public async Task<ActionResult<Ticket>> GetTicketByUserId(int id)
        {
            var ticketFromService = await _ticketService.GetTicketByUserId(id);
            if (ticketFromService == null)
            {
                return NotFound();
            }
            return Ok(ticketFromService);
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(TicketDto ticketDto)
        {
            var createdTicket = await _ticketService.CreateTicket(ticketDto);
            return Ok(createdTicket);
        }

        [HttpPut]
        public async Task<ActionResult<Ticket>> UpdateTicket(TicketDto ticketDto)
        {
            var updatedTicket = await _ticketService.UpdateTicket(ticketDto);
            return Ok(updatedTicket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicket(int id)
        {
            var deletedTicket = await _ticketService.DeleteTicket(id);
            return Ok(deletedTicket);
        }
    }
}
