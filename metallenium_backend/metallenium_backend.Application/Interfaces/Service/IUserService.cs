using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Dto.Request;
using metallenium_backend.Domain.Dto.Response;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Service
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> Registration(UserDto userDTO);
        Task<String> Login(AuthenticateDto authenticateDto);

        Task<GetUserResponseDto> GetUserByEmail(string email);
    }
}
