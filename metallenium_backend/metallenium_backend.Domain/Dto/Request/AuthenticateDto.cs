using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto.Request
{
    public class AuthenticateDto
    {
        public string Email {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class GetUserByEmailRequestDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
