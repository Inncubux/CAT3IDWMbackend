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
        public new string Email {get; set;} = string.Empty!;
        [PasswordAttribute(6)]
        public new string Password { get; set; } = string.Empty!;

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}