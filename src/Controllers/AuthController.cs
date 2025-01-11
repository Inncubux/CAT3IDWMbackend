using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.src.DTOs.Auth;
using API.src.Interface;
using API.src.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.src.Controllers
{
    public class AuthController: BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        private readonly SignInManager<User> _signInManager;
        public AuthController(IUserRepository userRepository, ITokenService tokenService, SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _signInManager = signInManager;

        }

        [HttpPost("auth/register")]

        public async Task<IActionResult> CreateUser([FromForm] CreateUserDto createUserDto)
        {
            //Validar si el usuario ya existe
            var email = createUserDto.Email;
            if(await _userRepository.GetUserByEmail(email) != null)
            {
                return Conflict("El correo electrónico ya esta registrado.");
            }
            
            //Validar contraseña con 6 carácteres
            if(createUserDto.Password.Length < 6)
            {
                return BadRequest("La contraseña debe tener al menos 6 caracteres.");
            }
            //Validar contraseña con al menos un número
            if(!Regex.IsMatch(createUserDto.Password, @"\d")){
                return BadRequest("La contraseña debe tener al menos un número.");
            }

            if(createUserDto.Password == null || createUserDto.Email == null)
            {
                return BadRequest("Rellene los campos");
            }

            await _userRepository.CreateUser(createUserDto);
            return Ok(new {Message = "Usuario registrado exitosamente"});
        }

        [HttpPost("auth/login")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            if(loginDto.Email == null || loginDto.Password == null)
            {
                return BadRequest("Rellene los campos");
            }

            var user = await _userRepository.GetUserByEmail(loginDto.Email);
            if(user == null)
            {
                return NotFound("El usuario no existe.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(user.Password != loginDto.Password)
            {
                return Unauthorized(new{Message ="Contraseña incorrecta."});
            }

            return Ok(new NewUserDTO
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                Role =  "usuario"
            });


        }
    }
}