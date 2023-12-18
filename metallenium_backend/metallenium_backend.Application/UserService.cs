using AutoMapper;
using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Dto.Request;
using metallenium_backend.Domain.Dto.Response;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<List<UserDto>>(users);
        }
        public async Task<GetUserResponseDto> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return _mapper.Map<GetUserResponseDto>(user);
        }
        public async Task<UserDto> Registration(UserDto userDTO)
        {

            if (string.IsNullOrWhiteSpace(userDTO.UserEmail) || string.IsNullOrWhiteSpace(userDTO.UserPassword))
            {
                throw new ValidationException("Email and Password are required.");
            }
            var userLogin = await _userRepository.Registration(userDTO);
            return _mapper.Map<UserDto>(userLogin);
        }
        public async Task<String> Login(AuthenticateDto authenticateDto)
        {

            if (string.IsNullOrWhiteSpace(authenticateDto.Email) || string.IsNullOrWhiteSpace(authenticateDto.Password))
            {
                throw new ValidationException("Email and Password are required.");
            }
            var userLogin = await _userRepository.Login(authenticateDto);
            return userLogin;
        }

    }
}
