using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.DTOs;
using API.src.Interface;
using API.src.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.src.Controllers
{
    public class PostController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public PostController(IUserRepository userRepository, IPostRepository postRepository){
            _userRepository = userRepository;
            _postRepository = postRepository;
        }


        [HttpPost("post")]
        public async Task<ActionResult> CreatePost([FromBody]CreatePostDto createPostDto, string email)
        {
            if (createPostDto == null)
            {
                return BadRequest(new { message = "No se puede crear el post" });
            }

            if (string.IsNullOrWhiteSpace(createPostDto.Title) || createPostDto.Title.Length <= 5)
            {
                return BadRequest(new { message = "Título inválido" });
            }

            if (string.IsNullOrWhiteSpace(createPostDto.ImageUrl))
            {
                return BadRequest(new { message = "Url de la imagen inválida" });
            }


            var user = await _userRepository.GetUserByEmail(email);
            if(user == null){
                return BadRequest("El usuario no existe en el sistema");
            }

            var newpost = new Post
            {
                Title = createPostDto.Title,
                ImageUrl = createPostDto.ImageUrl,
                PublicationDate = DateTime.Now,
                UserEmail = email

            };
            await _postRepository.CreatePost(newpost);
            return Ok(new{Message = "Post creado con éxito"});

}
        [HttpGet("posts")]
        public async Task<ActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPost();
            if (posts == null || !posts.Any())
            {
                return NotFound(new { message = "No hay posts disponibles" });
            }

            return Ok(posts);
        }
    }
}