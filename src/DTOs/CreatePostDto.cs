using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.src.DTOs
{
    public class CreatePostDto
    {
        [StringLength(255, MinimumLength = 5 )]
        public required string Title {get; set;}

        public required string ImageUrl {get; set;}


    }
}