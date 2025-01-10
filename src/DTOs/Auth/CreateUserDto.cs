using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.src.ValidationAttributes;

namespace API.src.DTOs.Auth
{
    public class CreateUserDto
    {
        [EmailAddress]
        public required string Email { get; set; } = string.Empty!;
        [PasswordAttribute(6)]
        public required string Password { get; set; } = string.Empty!;
    }
}