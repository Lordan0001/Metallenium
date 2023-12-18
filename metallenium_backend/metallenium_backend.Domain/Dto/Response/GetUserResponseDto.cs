using metallenium_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Dto.Response
{
    public class GetUserResponseDto
    {

        public int UserId { get; set; }
        public string UserEmail { get; set; } = String.Empty;
        public string UserFirstName { get; set; } = String.Empty;
        public string UserSecondName { get; set; } = String.Empty;
        public int UserRoleId { get; set; }

    }
}
