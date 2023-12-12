using AutoMapper;
using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
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
        public async Task<UserDto> Registration(UserDto userDTO)
        {

            if (string.IsNullOrWhiteSpace(userDTO.UserDtoEmail) || string.IsNullOrWhiteSpace(userDTO.UserDtoPassword))
            {
                throw new ValidationException("Email and Password are required.");
            }
            var userLogin = await _userRepository.Registration(userDTO);
            return _mapper.Map<UserDto>(userLogin);
        }
        public async Task<String> Login(UserDto userDTO)
        {

            if (string.IsNullOrWhiteSpace(userDTO.UserDtoEmail) || string.IsNullOrWhiteSpace(userDTO.UserDtoPassword))
            {
                throw new ValidationException("Email and Password are required.");
            }
            var userLogin = await _userRepository.Login(userDTO);
            return userLogin;
        }

    }
}
