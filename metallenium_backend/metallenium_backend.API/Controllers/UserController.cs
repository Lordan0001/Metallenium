using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Dto.Request;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace metallenium_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto userDTO)
        {
            var newUser = await _userService.Registration(userDTO);
            return Ok(newUser);
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult> Authenticate(AuthenticateDto authenticateDto)
        {
            var token = await _userService.Login(authenticateDto);
            return Ok(token);
        }
    }
}
