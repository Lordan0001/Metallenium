﻿using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Dto.Request;
using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> Registration(UserDto userDTO);

        Task<User> GetUserByEmail(string email);//i need full entity
        Task<String> Login(AuthenticateDto authenticateDto);
    }
}
