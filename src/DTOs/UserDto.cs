using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using API.src.Models;
using API.src.ValidationAttributes;

namespace API.src.DTOs
{
    public class UserDto
    {
        [EmailAddress]
        public required string Email { get; set; } = string.Empty!;

        public required User user { get; set; } = null!;
    }
}