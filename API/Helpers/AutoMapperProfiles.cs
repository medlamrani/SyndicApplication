<<<<<<< HEAD
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 59dd58d15ab9e8b7e28c9f5f8efca6d75640c159
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
<<<<<<< HEAD
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
        }
=======
        public AutoMapperProfiles() 
        {
            CreateMap<AppUser, MemberDto>();
        } 
>>>>>>> 59dd58d15ab9e8b7e28c9f5f8efca6d75640c159
    }
}