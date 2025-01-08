using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.src.Models
{
    public class Post
    {
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImageUrl {get; set;}
        public User User {get; set;}
    }
}