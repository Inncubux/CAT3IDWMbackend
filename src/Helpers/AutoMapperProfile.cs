using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.src.DTOs;
using API.src.DTOs.Auth;
using API.src.Models;
using AutoMapper;

namespace API.src.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}