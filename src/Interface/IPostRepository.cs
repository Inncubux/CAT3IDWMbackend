using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.DTOs;
using API.src.Models;

namespace API.src.Interface
{
    public interface IPostRepository
    {
        Task<CreatePostDto> CreatePost(Post post);
        Task<IEnumerable<Post>> GetPost();
    }
}