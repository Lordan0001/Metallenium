using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto
{
    public class UserDto
    {
        public int UserDtoId { get; set; }
        public string UserDtoEmail { get; set; } = string.Empty;
        public string UserDtoPassword { get; set; } = string.Empty;
    }
}
