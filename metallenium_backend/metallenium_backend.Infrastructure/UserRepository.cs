using AutoMapper;
using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Dto.Request;
using metallenium_backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Infrastructure
{
    public class UserRepository : IUserRepository//Implement
    {
        private readonly MainDbContext _mainDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserRepository(MainDbContext mainDbContext,IMapper mapper, IConfiguration configuration)
        {
            _mainDbContext = mainDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<List<User>> GetAllUsers()
        {
            return await _mainDbContext.Users.ToListAsync();
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _mainDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found with the specified email.");
            }
            return user;
        }

        public async Task<String> Login(AuthenticateDto authenticateDto)
        {
            var existingUser = await _mainDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == authenticateDto.Email);

            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found with the specified email.");
            }

            var userRole = await _mainDbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == existingUser.UserRoleId);
            string role = userRole.RoleName;//null

            if (!VerifyPasswordHash(authenticateDto.Password, existingUser.UserPasswordHash, existingUser.UserPasswordSalt))
            {
                throw new KeyNotFoundException("User not found with this password");
            }

            string token = CreateToken(existingUser, role);


            return token;
        }

        public async Task<User> Registration(UserDto userDto)
        {
            var alredyExistingEmail = await _mainDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == userDto.UserEmail);
            if (alredyExistingEmail != null)
            {
                throw new KeyNotFoundException("User with this email already exist!");

            }
            CreatePasswordHash(userDto.UserPassword, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User();
            user.UserEmail = userDto.UserEmail;
            user.UserFirstName = userDto.UserFirstName;
            user.UserSecondName = userDto.UserSecondName;
            user.UserPasswordHash = passwordHash;
            user.UserPasswordSalt = passwordSalt;
            user.UserRoleId = 2;//change

            await _mainDbContext.Users.AddAsync(user);
            await _mainDbContext.SaveChangesAsync();
            return user;
        }

        private string CreateToken(User user, string userRole)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserEmail),
                new Claim(ClaimTypes.Role, userRole),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        private bool VerifyPasswordHash(string reqPassword, byte[] storedPasswordHash, byte[] storedPasswordSalt)
        {
            using (var hmac = new HMACSHA512(storedPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(reqPassword));
                return computedHash.SequenceEqual(storedPasswordHash);
            }

        }


    }
}
