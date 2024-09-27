using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;


        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Phone { get; set; }

        public int? Gender { get; set; }

        public string? Country { get; set; }
    }
}
