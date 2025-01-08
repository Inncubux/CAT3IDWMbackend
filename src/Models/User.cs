using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace API.src.Models
{
    public class User: IdentityUser
    {
        [EmailAddress]
        public string Email {get; set;}
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}