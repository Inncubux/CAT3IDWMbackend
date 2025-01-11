using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.DTOs.Auth
{
    public class NewUserDTO
    {
        public string Email { get; set; } = string.Empty!;
        public string Token { get; set; } = string.Empty!;

        public string Role {get; set; } = string.Empty!;
    }
}