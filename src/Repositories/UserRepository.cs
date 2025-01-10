using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.Data;
using API.src.Interface;
using API.src.Models;
using Microsoft.AspNetCore.Identity;

namespace API.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(DataContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateUser(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }
    }
}