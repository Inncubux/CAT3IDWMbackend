using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.Data;
using API.src.DTOs;
using API.src.Interface;
using API.src.Models;
using Microsoft.EntityFrameworkCore;

namespace API.src.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext dataContext){
            _context = dataContext;
        }
        public async Task<CreatePostDto> CreatePost(Post post)
        {
            _context.Posts.Add(post);

           await _context.SaveChangesAsync();
           var newPost = 
           new CreatePostDto{
                Title = post.Title,
                ImageUrl = post.ImageUrl
           };
           return newPost;
        }

        public async Task<IEnumerable<Post>> GetPost()
        {
            return await _context.Posts.ToListAsync();
        }
    }
}