using AutoMapper;
using Model.Entities;
using NetWebApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // AutoMapper Club
            CreateMap<Club, ClubDto>();
            CreateMap<ClubDto, Club>();
            CreateMap<ClubPostDto, Club>();


            
        }
    }
}
