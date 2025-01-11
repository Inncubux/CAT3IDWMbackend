using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.src.Models
{
    public class Post
    {
        public int Id { get; set; }
        [StringLength(255, MinimumLength = 5)]
        public  string Title { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string ImageUrl {get; set;} = string.Empty;
        [EmailAddress]
        public string UserEmail {get; set;} = null!;
    }
}