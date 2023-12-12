using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Domain.Dto;
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
        private readonly IConfiguration _configuration;
        public UserRepository(MainDbContext mainDbContext, IConfiguration configuration)
        {
            _mainDbContext = mainDbContext;
            _configuration = configuration;
        }


        public async Task<List<User>> GetAllUsers()
        {
            return await _mainDbContext.Users.ToListAsync();
        }

        public async Task<String> Login(UserDto userDto)
        {
            var existingUser = await _mainDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == userDto.UserDtoEmail);

            var userRole = await _mainDbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == existingUser.UserRoleId);
            string role = userRole.RoleName;//null

            if (!VerifyPasswordHash(userDto.UserDtoPassword, existingUser.UserPasswordHash, existingUser.UserPasswordSalt))
            {
                throw new KeyNotFoundException();
            }

            string token = CreateToken(existingUser, role);

/*            var response = new
            {
                Token = token,
                User = existingUser
            };*/

            return token;
        }

        public async Task<User> Registration(UserDto userDTO)
        {
            var alredyExistingEmail = await _mainDbContext.Users.FirstOrDefaultAsync(u => u.UserEmail == userDTO.UserDtoEmail);
            if (alredyExistingEmail != null)
            {
                throw new KeyNotFoundException("User with this email already exist!");

            }
            CreatePasswordHash(userDTO.UserDtoPassword, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User();
            user.UserEmail = userDTO.UserDtoEmail;
            user.UserPasswordHash = passwordHash;
            user.UserPasswordSalt = passwordSalt;
            user.UserRoleId = 1;//change

            await _mainDbContext.Users.AddAsync(user);
            await _mainDbContext.SaveChangesAsync();
            return user;
        }

        private string CreateToken(User user, string userRole)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserFullName),
                new Claim(ClaimTypes.Email, user.UserEmail),
                new Claim(ClaimTypes.Role, userRole),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

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
