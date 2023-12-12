using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metallenium_backend.Domain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; } = String.Empty;
        public string UserFullName { get; set; } = String.Empty;
        public int UserRoleId { get; set; }
        public byte[]? UserPasswordHash { get; set; }
        public byte[]? UserPasswordSalt { get; set; }

        public Role Role { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
