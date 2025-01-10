using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.Models;

namespace API.src.Interface
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);
        Task<bool> GetUserByEmail(string email);
    }
}