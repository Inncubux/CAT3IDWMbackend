using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using API.src.ValidationAttributes;


namespace API.src.Models
{
    public class User: IdentityUser
    {
        [EmailAddress]
        public string Email {get; set;} = string.Empty!;
        [PasswordAttribute(6)]
        public string Password { get; set; } = string.Empty!;
    }
}