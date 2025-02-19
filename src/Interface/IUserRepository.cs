using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.DTOs;
using API.src.DTOs.Auth;
using API.src.Models;

namespace API.src.Interface
{
    public interface IUserRepository
    {
        Task<UserDto> CreateUser(CreateUserDto createUserDtor);
        Task<User?> GetUserByEmail(string email);
    }
}