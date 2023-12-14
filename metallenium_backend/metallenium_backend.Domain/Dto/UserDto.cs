using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; } = String.Empty;
        public string UserSecondName { get; set; } = String.Empty;
        public string UserEmail { get; set; } = String.Empty;
        public string UserPassword { get; set; } = String.Empty;
    }
}
