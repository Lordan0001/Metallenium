﻿using metallenium_backend.Application;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Dto.Request;
using metallenium_backend.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
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
        [HttpPost]
        [Route("GetUserByEmail")]
        public async Task<ActionResult> GetUserByEmail(GetUserByEmailRequestDto getUserByEmailRequestDto)
        {
            var user = await _userService.GetUserByEmail(getUserByEmailRequestDto.Email);
            return Ok(user);
        }
        [HttpGet("getMe"), Authorize]//need to separate logic
        public ActionResult<object> GetMe()
        {
 
            var email = User.FindFirstValue(ClaimTypes.Email);
            var role = User.FindFirstValue(ClaimTypes.Role);
            return Ok(new { email, role });
        }
    }
}
