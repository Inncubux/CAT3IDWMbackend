using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.Data;
using API.src.DTOs;
using API.src.DTOs.Auth;
using API.src.Interface;
using API.src.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        public UserRepository(DataContext context, UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<UserDto> CreateUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email)!;
        }
    }
}